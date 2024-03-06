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
        #region constants
        private string EMPLOYEES_FILE = "EMPLOYEES.csv";
        private string CUSTOMERS_FILE = "CUSTOMERS.csv";
        private string OFFICES_FILE = "OFFICES.csv";
        private string ORDERDETAILS_FILE = "ORDERDETAILS.csv";
        private string ORDERS_FILE = "ORDERS.csv";
        private string PAYMENTS_FILE = "PAYMENTS.csv";
        private string PRODUCTLINES_FILE = "PRODUCTLINES.csv";
        private string PRODUCTS_FILE = "PRODUCTS.csv";
        private int BATCH_SIZE = 1000;

        #endregion

        private MODEL.BusinessDBContext context = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public DaoManager(MODEL.BusinessDBContext context)
        {
            this.context = context;
        }

        #region Imports(Part 2)
        /// <summary>
        /// Method to make the import of all the csv files
        /// </summary>
        public void ImportCsvFiles()
        {
            try
            {
                AddProductLine();
                AddProducts();
                AddOffices();
                AddEmployees();
                AddCustomers();
                AddPayments();
                AddOrders();
                AddOrderDetails();
            } catch (Exception e)
            {
                Console.WriteLine("Error al fer les importacions!");
            }
            
        }

        /// <summary>
        /// Method to add the product lines
        /// </summary>
        public void AddProductLine()
        {
            List<ProductLine> productLinesBatch = new List<ProductLine>();

            using (TextFieldParser parser = new TextFieldParser(PRODUCTLINES_FILE))
            {
                parser.ReadLine();
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] data = parser.ReadFields();
                    ProductLine productLine = new ProductLine();
                    productLine.productLine = data[0];
                    productLine.textDescription = data[1];
                    productLine.htmlDescription = data[2];
                    productLine.image = data[3];

                    productLinesBatch.Add(productLine);

                    if (productLinesBatch.Count >= BATCH_SIZE)
                    {
                        AddProductLinesBatch(productLinesBatch);
                        productLinesBatch.Clear();
                    }
                }

                if (productLinesBatch.Count > 0)
                {
                    AddProductLinesBatch(productLinesBatch);
                }
            }
        }

        /// <summary>
        /// Method to add the product lines in batch
        /// </summary>
        /// <param name="productLines"></param>
        private void AddProductLinesBatch(List<ProductLine> productLines)
        {
            context.ProductLines.AddRange(productLines);
            context.SaveChanges();
        }

        /// <summary>
        /// Method to add the products
        /// </summary>
        public void AddProducts()
        {
            List<Product> productsBatch = new List<Product>();

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

                    productsBatch.Add(product);

                    if (productsBatch.Count >= BATCH_SIZE)
                    {
                        AddProductsBatch(productsBatch);
                        productsBatch.Clear();
                    }
                }

                if (productsBatch.Count > 0)
                {
                    AddProductsBatch(productsBatch);
                }
            }
        }

        /// <summary>
        /// Method to add the products in batch
        /// </summary>
        /// <param name="products"></param>
        private void AddProductsBatch(List<Product> products)
        {
            foreach (Product product in products)
            {
                product.ProductLines = context.ProductLines.Find(product.productLine);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        /// <summary>
        /// Method to add the offices
        /// </summary>
        public void AddOffices()
        {
            List<Office> officesBatch = new List<Office>();

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

                    if (data[5] != "NULL") office.state = data[5];
                    else office.state = null;

                    office.country = data[6];
                    office.postalCode = data[7];
                    office.territory = data[8];

                    officesBatch.Add(office);

                    if (officesBatch.Count >= BATCH_SIZE)
                    {
                        AddOfficesBatch(officesBatch);
                        officesBatch.Clear();
                    }
                }

                if (officesBatch.Count > 0)
                {
                    AddOfficesBatch(officesBatch);
                }
            }
        }

        /// <summary>
        /// Method to add the offices in batch
        /// </summary>
        /// <param name="offices"></param>
        private void AddOfficesBatch(List<Office> offices)
        {
            context.Offices.AddRange(offices);
            context.SaveChanges();
        }

        /// <summary>
        /// Method to add the employees
        /// </summary>
        public void AddEmployees()
        {
            List<Employee> employeesBatch = new List<Employee>();

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

                    if (data[6] == "NULL") employee.reportsTo = null;
                    else employee.reportsTo = Convert.ToInt16(data[6]);

                    employee.jobTitle = data[7];

                    employeesBatch.Add(employee);

                    if (employeesBatch.Count >= BATCH_SIZE)
                    {
                        AddEmployeesBatch(employeesBatch);
                        employeesBatch.Clear();
                    }
                }

                if (employeesBatch.Count > 0)
                {
                    AddEmployeesBatch(employeesBatch);
                }
            }
        }

        /// <summary>
        /// Method to add the employees in batch
        /// </summary>
        /// <param name="employees"></param>
        private void AddEmployeesBatch(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                employee.offices = context.Offices.Find(employee.officeCode);
                employee.ReportsToRef = context.Employees.Find(employee.reportsTo);
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }

        /// <summary>
        /// Method to add the customers
        /// </summary>
        public void AddCustomers()
        {
            List<Customer> customersBatch = new List<Customer>();

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

                    if (data[6] != "NULL") customer.addressLine2 = data[6];
                    else customer.addressLine2 = null;

                    customer.city = data[7];

                    if (data[8] != "NULL") customer.state = data[8];
                    else customer.state = null;

                    customer.postalCode = data[9];
                    customer.country = data[10];

                    if (data[11] == "NULL")customer.salesRepEmployeeNumber = null;
                    else customer.salesRepEmployeeNumber = Convert.ToInt16(data[11]);

                    customer.creditLimit = Convert.ToDecimal(data[12]);

                    customersBatch.Add(customer);

                    if (customersBatch.Count >= BATCH_SIZE)
                    {
                        AddCustomersBatch(customersBatch);
                        customersBatch.Clear();
                    }
                }

                if (customersBatch.Count > 0)
                {
                    AddCustomersBatch(customersBatch);
                }
            }
        }

        /// <summary>
        /// Method to add the customers in batch
        /// </summary>
        /// <param name="customers"></param>
        private void AddCustomersBatch(List<Customer> customers)
        {

            foreach (Customer customer in customers)
            {
                if (customer.salesRepEmployeeNumber.HasValue)
                {
                    customer.employee = context.Employees.Find(customer.salesRepEmployeeNumber);
                }
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        /// <summary>
        /// Method to add the payments
        /// </summary>
        public void AddPayments()
        {
            List<Payment> paymentsBatch = new List<Payment>();

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

                    paymentsBatch.Add(payment);

                    if (paymentsBatch.Count >= BATCH_SIZE)
                    {
                        AddPaymentsBatch(paymentsBatch);
                        paymentsBatch.Clear();
                    }
                }

                if (paymentsBatch.Count > 0)
                {
                    AddPaymentsBatch(paymentsBatch);
                }
            }
        }

        /// <summary>
        /// Method to add the payments in batch
        /// </summary>
        /// <param name="payments"></param>
        private void AddPaymentsBatch(List<Payment> payments)
        {
            foreach (Payment payment in payments)
            {
                payment.customer = context.Customers.Find(payment.customerNumber);
            }

            context.Payment.AddRange(payments);
            context.SaveChanges();
        }

        /// <summary>
        /// Method to add the orders
        /// </summary>
        public void AddOrders()
        {
            List<Order> ordersBatch = new List<Order>();

            using (TextFieldParser parser = new TextFieldParser(ORDERS_FILE))
            {
                parser.ReadLine(); // Skip header
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

                    if (data[3] == "NULL") order.shippedDate = null;
                    else order.shippedDate = Convert.ToDateTime(data[3]);

                    order.status = data[4];

                    if (data[5] != "NULL") order.comments = data[5];
                    else order.comments = null;

                    order.customerNumber = Convert.ToInt16(data[6]);

                    ordersBatch.Add(order);

                    if (ordersBatch.Count >= BATCH_SIZE)
                    {
                        AddOrdersBatch(ordersBatch);
                        ordersBatch.Clear();
                    }
                }

                if (ordersBatch.Count > 0)
                {
                    AddOrdersBatch(ordersBatch);
                }
            }
        }

        /// <summary>
        /// Method to add the orders in batch
        /// </summary>
        /// <param name="orders"></param>
        private void AddOrdersBatch(List<Order> orders)
        {
            foreach (Order order in orders)
            {
                order.customer = context.Customers.Find(order.customerNumber);
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();
        }

        /// <summary>
        /// Method to add the order details
        /// </summary>
        public void AddOrderDetails()
        {
            List<OrderDetail> orderDetailsBatch = new List<OrderDetail>();

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

                    orderDetailsBatch.Add(orderDetail);

                    if (orderDetailsBatch.Count >= BATCH_SIZE)
                    {
                        AddOrderDetailsBatch(orderDetailsBatch);
                        orderDetailsBatch.Clear();
                    }
                }

                if (orderDetailsBatch.Count > 0)
                {
                    AddOrderDetailsBatch(orderDetailsBatch);
                }
            }
        }

        /// <summary>
        /// Method to add the order details in batch
        /// </summary>
        /// <param name="orderDetails"></param>
        private void AddOrderDetailsBatch(List<OrderDetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                orderDetail.order = context.Orders.Find(orderDetail.orderNumber);
                orderDetail.product = context.Products.Find(orderDetail.productCode);
            }

            context.OrderDetails.AddRange(orderDetails);
            context.SaveChanges();
        }

        #endregion

        #region Queries(Part 3)
        /// <summary>
        /// Method to get the customers filtered by an initial
        /// </summary>
        /// <param name="inicial"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to get the customers and what they have spent
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method to get the customer, the employee that has attended the customer
        /// and location
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method to get the products sorted by a determinated field ascending or descending
        /// </summary>
        /// <param name="productField"></param>
        /// <param name="ascending"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to get the price of the orders
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method to get the details of an order
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to get the orders numbers
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetOrdersNumbers()
        {
            return context.OrderDetails.Select(od => od.orderNumber).Distinct().ToList();
        }

        /// <summary>
        /// Method to get the orders filtered by their status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public IEnumerable GetShippedOrders(string status)
        {
            var ordersWithSelectedStatus = context.Orders
                .Where(o => o.status == status)
                .OrderBy(o => o.orderDate)
                .ToList();
            return ordersWithSelectedStatus;
        }

        /// <summary>
        /// Method to get the employees by office
        /// </summary>
        /// <param name="office"></param>
        /// <returns></returns>
        public IEnumerable GetEmployeesByOffice(string office)
        {
            var employeeOffice = context.Offices
                .Where(o => o.city == office)
                .Join(context.Employees,
                    o => o.officeCode,
                    employee => employee.officeCode,
                    (o, employee) => new
                    {
                        employeeNumber = employee.employeeNumber,
                        employeeName = $"{employee.firstName}",
                        emloyeeLastName= employee.lastName,
                        employeeExtension= employee.extension,
                        employeeEmail= employee.email,
                        employeeOfficeCode= employee.officeCode,
                        employeeReportsTo= employee.reportsTo,
                        employeeJobTitle = employee.jobTitle
                    }
                    )
                .ToList();

            return employeeOffice;
            
        }

        /// <summary>
        /// Method to get the offices
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetOffices()
        {
            var officesNames= context.Offices.Select(o => o.city).ToList(); 
            return officesNames;
        }

        /// <summary>
        /// Method to get the customer payments made
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetCustomerPayments()
        {
            var PaymentsPerCustomer = context.Customers
            .Join(context.Payment,
                  c => c.customerNumber,
                  p => p.customerNumber,
                  (c, p) => new { Customer = c, Payment = p })
            .GroupBy(cp => new { cp.Customer.customerNumber, cp.Customer.customerName })
            .Select(g => new
            {
                CustomerNumber = g.Key.customerNumber,
                CustomerName = g.Key.customerName,
                TotalPayments = g.Count()
            })
            .ToList();

            return PaymentsPerCustomer;
        }

        /// <summary>
        /// Method to get the job tittles
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetJobTittles()
        {
            var jobTittles = context.Employees.Select(e => e.jobTitle)
                .Distinct()
                .ToList();


            return jobTittles;
        }

        /// <summary>
        /// Method to get the employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetEmployees()
        {
            List<Employee> employees = context.Employees.ToList();
            return employees;
        }

        /// <summary>
        /// Method to get the employees by job tittle
        /// </summary>
        /// <param name="jobTittle"></param>
        /// <returns></returns>
        public IEnumerable GetEmployesByJobTittle(string jobTittle)
        {
            var employeesByJobTittle = context.Employees
                .Where(e => e.jobTitle == jobTittle)
                .ToList();

            return employeesByJobTittle;
        }

        /// <summary>
        /// Method to get the employees by ascending employee number
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetEmployeesByAscendingNumber()
        {
            var employeesByAscendingNumber = context.Employees
                .OrderBy(e => e.employeeNumber)
                .ToList();

            return employeesByAscendingNumber;
        }

        /// <summary>
        /// Method to get the employees by descending employee number
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetEmployeesByDescendingNumber()
        {
            var employeesByDescendingNumber = context.Employees
                .OrderByDescending(e => e.employeeNumber)
                .ToList();

            return employeesByDescendingNumber;
        }

        /// <summary>
        /// Method to get the employees related to their offices
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetEmployeesJoinOffices()
        {
            var employeeWithOffices= context.Employees
                .Include(e => e.offices)
                .ToList()
                .Select(e => new
              {
                    employeeNumber = e.employeeNumber,
                    employeeName = $"{e.firstName} {e.lastName}",
                    employeeExtension = e.extension,
                    employeeEmail = e.email,
                    employeeOfficeCode = e.officeCode,
                    employeeReportsTo = e.reportsTo,
                    employeeJobTitle = e.jobTitle,
                    officeCity = e.offices.city,
                    officeLocation = $"{e.offices.addressLine1}, {e.offices.city}, {e.offices.country}"
                });
               
             return employeeWithOffices;
        }

        /// <summary>
        /// Method to get the countries
        /// </summary>
        /// <returns></returns>
        public List<string> GetCountry()
        {
            var countries = context.Offices.Select(e => e.country)
               .Distinct()
               .ToList();

            return countries;
        }

        /// <summary>
        /// Method to get the offices filtered by countries
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public IEnumerable GetOfficesByCountries(string country)
        {
            var countriesFiltred = context.Offices
                .Where(e => e.country == country)
                .ToList();

            return countriesFiltred;
        }



        
        #endregion

        #region SpecialPrice (Part 4)

        /// <summary>
        /// Method to get the customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            return context.Customers.ToList();
        }

        /// <summary>
        /// Method to get the products
        /// </summary>
        /// <returns></returns>
        /// 
        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        /// <summary>
        /// Method to add a special price for a customer and product
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="product"></param>
        /// <param name="price"></param>
        public void AddSpecialPrice(Customer customer, Product product, decimal price)
        {
            try
            {
                SpecialPriceList specialPriceList = new SpecialPriceList();
                specialPriceList.customerId = customer.customerNumber;
                specialPriceList.productCode = product.productCode;
                specialPriceList.price = price;

                context.SpecialPriceList.Add(specialPriceList);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al afegir un preu especial!");
            }
        }
        #endregion
    }
}
