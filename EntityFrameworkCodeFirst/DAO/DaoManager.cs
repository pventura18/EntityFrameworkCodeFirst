
using EntityFrameworkCodeFirst.MODEL;
using Microsoft.VisualBasic.FileIO;
using System;
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
                    Office office = new MODEL.Office();
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

        public void AddCustomersEntry(Customer customer)
        {
            customer.employee = context.Employees.Find(customer.salesRepEmployeeNumber);

            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void AddOrderDetails()
        {
            throw new NotImplementedException();
        }

        public void AddOrderDetailsEntry(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public void AddOrders()
        {
            throw new NotImplementedException();
        }

        public void AddOrdersEntry(Order order)
        {
            throw new NotImplementedException();
        }

        
    }
}
