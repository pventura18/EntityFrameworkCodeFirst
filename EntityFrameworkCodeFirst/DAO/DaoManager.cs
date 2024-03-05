using EntityFrameworkCodeFirst.MODEL;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace EntityFrameworkCodeFirst.DAO
{
    public class DaoManager : IDAO
    {
        private string EMPLOYEES_FILE = "EMPLOYEES.csv";
        private string CUSTOMERS_FILE = "CUSTOMERS.csv";
        private string OFFICES_FILE = "OFFICES.csv";
        private string ORDERDETAILS_FILE = "ORDERDETAILS.csv";
        private string ORDERS_FILE = "ORDERS.csv";
        private string PAYMENTS_FILE = "PAYMENTS.csv";
        private string PRODUCTLINES_FILE = "PRODUCTLINES.csv";
        private string PRODUCTS_FILE = "PRODUCTS.csv";

        private MODEL.BusinessDBContext context = null;

        public DaoManager(MODEL.BusinessDBContext context)
        {
            this.context = context;
        }

        public void ImportCsvFiles()
        {
            AddProductLine();
            AddProducts();
            AddOffices();
            AddEmployees();
            AddCustomers();
            AddPayments();
            AddOrders();
            AddOrderDetails();
        }

        public void AddProductLine()
        {
            using(TextFieldParser parser = new TextFieldParser(PRODUCTLINES_FILE))
            {
                parser.ReadLine();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;
                while(!parser.EndOfData)
                {
                    string[] data = parser.ReadFields();
                    ProductLine productLine = new ProductLine();
                    productLine.productLine = data[0];
                    productLine.textDescription = data[1];
                    productLine.htmlDescription = data[2];
                    productLine.image = data[3];

                    AddProductLineEntry(productLine);
                }
            }
        }

        public void AddProductLineEntry(ProductLine productLine)
        {
            context.ProductLines.Add(productLine);
            context.SaveChanges();
        }

        public void AddProducts()
        {
            using (TextFieldParser parser = new TextFieldParser(PRODUCTS_FILE))
            {
                parser.ReadLine();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] data = parser.ReadFields();
                    Product product = new Product();
                    product.productCode = data[0];
                    product.productName = data[1];
                    product.productLine = data[2];
                    product.productScale = data[3];
                    product.productVendor = data[4];
                    product.productDescription = data[5];
                    product.quantityInStock = Convert.ToInt16(data[6]);
                    product.BuyPrice = Convert.ToDouble(data[7]);
                    product.MSRP = Convert.ToDouble(data[8]);

                    AddProductsEntry(product);
                }
            }
        }

        public void AddProductsEntry(Product product)
        {
            product.ProductLines = context.ProductLines.Find(product.productLine);
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void AddOffices()
        {
            using (TextFieldParser parser = new TextFieldParser(OFFICES_FILE))
            {
                parser.ReadLine();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] data = parser.ReadFields();
                    Office office = new Office();
                    office.officeCode = data[0];
                    office.city = data[1];
                    office.phone = data[2];
                    office.addressLine1 = data[3];
                    office.addressLine2 = data[4];
                    office.state = data[5];
                    office.country = data[6];
                    office.postalCode = data[7];
                    office.territory = data[8];


                     AddOfficesEntry(office);
                }
            }

        }

        public void AddOfficesEntry(Office office)
        {
            context.Offices.Add(office);
            context.SaveChanges();

            
        }

        public void AddCustomers()
        {
            using (TextFieldParser parser = new TextFieldParser(CUSTOMERS_FILE))
            {
                parser.ReadLine();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] data = parser.ReadFields();
                    Customer customer = new Customer();
                    customer.customerNumber = Convert.ToInt16(data[0]);
                    customer.customerName = data[1];
                    customer.contactLastName = data[2];
                    customer.contactFirstName = data[3];
                    customer.phone = data[4];
                    customer.addressLine1 = data[5];
                    customer.addressLine2 = data[6];
                    customer.city = data[7];
                    customer.state = data[8];
                    customer.postalCode = data[9];
                    customer.country = data[10];
                    if (data[11].Equals("NULL"))
                    {
                        customer.salesRepEmployeeNumber = null;
                    }
                    else
                    {

                        customer.salesRepEmployeeNumber = Convert.ToInt16(data[11]);
                    }
                    customer.creditLimit = Convert.ToDecimal(data[12]);

                    AddCustomersEntry(customer);
                }
            }
        }

        public void AddCustomersEntry(Customer customer)
        {
            customer.employee = context.Employees.Find(customer.salesRepEmployeeNumber);

            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void AddEmployees()
        {
            using (TextFieldParser parser = new TextFieldParser(EMPLOYEES_FILE))
            {
                parser.ReadLine();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] data = parser.ReadFields();
                    Employee employee = new Employee();
                    employee.employeeNumber = Convert.ToInt16(data[0]);
                    employee.lastName = data[1];
                    employee.firstName = data[2];
                    employee.extension = data[3];
                    employee.email = data[4];
                    employee.officeCode = data[5];

                    if (data[6].Equals("NULL"))
                    {
                        employee.reportsTo = null;
                    }
                    else
                    {

                        employee.reportsTo = Convert.ToInt16(data[6]);
                    }

                    employee.jobTitle = data[7];

                    AddEmployeesEntry(employee);
                }

            }

        }

        public void AddEmployeesEntry(Employee employee)
        {
            employee.offices = context.Offices.Find(employee.officeCode);
            employee.ReportsToRef = context.Employees.Find(employee.reportsTo);
            context.Employees.Add(employee);
            context.SaveChanges();
        }

        

        public void AddOrderDetails()
        {
            using (TextFieldParser parser = new TextFieldParser(ORDERDETAILS_FILE))
            {
                parser.ReadLine();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] data = parser.ReadFields();
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.orderNumber = Convert.ToInt16(data[0]);
                    orderDetail.productCode = data[1];
                    orderDetail.quantityOrdered = Convert.ToInt16(data[2]);
                    orderDetail.priceEach = Convert.ToDouble(data[3]);
                    orderDetail.orderLineNumber = Convert.ToInt16(data[4]);

                    AddOrderDetailsEntry(orderDetail);
                }
            }
        }

        public void AddOrderDetailsEntry(OrderDetail orderDetail)
        {
            orderDetail.order = context.Orders.Find(orderDetail.orderNumber);
            orderDetail.product = context.Products.Find(orderDetail.productCode);
            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();
        }

        public void AddOrders()
        {
            using (TextFieldParser parser = new TextFieldParser(ORDERS_FILE))
            {
                parser.ReadLine();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] data = parser.ReadFields();
                    Order order = new Order();
                    order.orderNumber = Convert.ToInt16(data[0]);
                    order.orderDate = Convert.ToDateTime(data[1]);
                    order.requiredDate = Convert.ToDateTime(data[2]);
                    if (data[3].Equals("NULL"))
                    {
                        order.shippedDate = null;
                    }
                    else
                    {
                        order.shippedDate = Convert.ToDateTime(data[3]);
                    }
                    order.status = data[4];
                    order.comments = data[5];
                    order.customerNumber = Convert.ToInt16(data[6]);

                    AddOrdersEntry(order);
                }
            }
        }

        public void AddOrdersEntry(Order order)
        {
            order.customer = context.Customers.Find(order.customerNumber);
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void AddPayments()
        {
            using (TextFieldParser parser = new TextFieldParser(PAYMENTS_FILE))
            {
                parser.ReadLine();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] data = parser.ReadFields();
                    Payment payment = new Payment();
                    payment.customerNumber = Convert.ToInt16(data[0]);
                    payment.checkNumber = data[1];
                    payment.paymentDate = Convert.ToDateTime(data[2]);
                    payment.amount = Convert.ToDouble(data[3]);

                    AddPaymentsEntry(payment);
                }
            }

        }

        public void AddPaymentsEntry(Payment payment)
        {
            payment.customer = context.Customers.Find(payment.customerNumber);
            context.Payment.Add(payment);
            context.SaveChanges();
        }

        public IEnumerable GetCustomers(char inicial)
        {
            IQueryable<Customer> query = context.Customers;

            if (inicial != '*')
            {
                query = query.Where(c => c.customerName.StartsWith(inicial.ToString()));
            }

            return query.Include(c => c.employee)
                        .ToList();
        }

        public IEnumerable GetSpentCustomers()
        {
            var query = context.Customers
            .Join(context.Payment,
                  c => c.customerNumber,
                  p => p.customerNumber,
                  (c, p) => new { Customer = c, Payment = p })
            .GroupBy(cp => new { cp.Customer.customerNumber, cp.Customer.customerName })
            .Select(g => new
            {
                CustomerNumber = g.Key.customerNumber,
                CustomerName = g.Key.customerName,
                Total = g.Sum(cp => cp.Payment.amount)
            })
            .ToList();

            return query.ToList();
        }

        public IEnumerable GetCustomerEmployeeLocation()
        {
            return context.Orders
            .Include(o => o.customer) 
            .Include(o => o.customer.employee) 
            .Include(o => o.customer.employee.offices) 
            .Select(o => new
            {
                OrderNumber = o.orderNumber,
                CustomerName = o.customer.customerName,
                EmployeeName = $"{o.customer.employee.firstName} {o.customer.employee.lastName}",
                OfficeCity = o.customer.employee.offices.city,
                OfficeLocation = $"{o.customer.employee.offices.addressLine1}, {o.customer.employee.offices.city}, {o.customer.employee.offices.country}"
            })
            .ToList();
        }

        public IEnumerable GetProducts(ProductFields productField, bool ascending)
        {
            IQueryable<Product> query = context.Products;

            switch (productField)
            {
                case ProductFields.ProductCode:
                    query = ascending ? query.OrderBy(p => p.productCode) : query.OrderByDescending(p => p.productCode);
                    break;
                case ProductFields.ProductName:
                    query = ascending ? query.OrderBy(p => p.productName) : query.OrderByDescending(p => p.productName);
                    break;
                case ProductFields.ProductLine:
                    query = ascending ? query.OrderBy(p => p.productLine) : query.OrderByDescending(p => p.productLine);
                    break;
                case ProductFields.ProductScale:
                    query = ascending ? query.OrderBy(p => p.productScale) : query.OrderByDescending(p => p.productScale);
                    break;
                case ProductFields.ProductVendor:
                    query = ascending ? query.OrderBy(p => p.productVendor) : query.OrderByDescending(p => p.productVendor);
                    break;
                case ProductFields.ProductDescription:
                    query = ascending ? query.OrderBy(p => p.productDescription) : query.OrderByDescending(p => p.productDescription);
                    break;
                case ProductFields.QuantityInStock:
                    query = ascending ? query.OrderBy(p => p.quantityInStock) : query.OrderByDescending(p => p.quantityInStock);
                    break;
                case ProductFields.BuyPrice:
                    query = ascending ? query.OrderBy(p => p.BuyPrice) : query.OrderByDescending(p => p.BuyPrice);
                    break;
                case ProductFields.MSRP:
                    query = ascending ? query.OrderBy(p => p.MSRP) : query.OrderByDescending(p => p.MSRP);
                    break;
            }

            return query.ToList();
        }

        public IEnumerable GetPriceOfOrders()
        {
            return context.OrderDetails
                .GroupBy(od => od.orderNumber)
                .Select(g => new
                {
                    OrderNumber = g.Key,
                    TotalPrice = g.Sum(od => od.quantityOrdered * od.priceEach)
                })
                .OrderBy(result => result.TotalPrice)
                .ToList();
        }

        public IEnumerable  GetDetailsOrder(int orderNumber)
        {
            return context.OrderDetails
            .Where(od => od.orderNumber == orderNumber)
            .Join(context.Products,
                  od => od.productCode,
                  p => p.productCode,
                  (od, p) => new
                  {
                      OrderNumber = od.orderNumber,
                      ProductName = p.productName,
                      QuantityOrdered = od.quantityOrdered,
                      PriceEach = od.priceEach,
                      TotalPrice = od.quantityOrdered * (decimal)od.priceEach
                  })
            .ToList<object>();
        }

        public IEnumerable GetOrdersNumbers()
        {
            return context.OrderDetails.Select(od => od.orderNumber).Distinct().ToList();
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public void AddSpecialPrice(Customer customer, Product product, decimal price)
        {
            SpecialPriceList specialPriceList = new SpecialPriceList();
            specialPriceList.customerId = customer.customerNumber;
            specialPriceList.productCode = product.productCode;
            specialPriceList.price = price;

            context.SpecialPriceList.Add(specialPriceList);
            context.SaveChanges();
        }
    }
}
