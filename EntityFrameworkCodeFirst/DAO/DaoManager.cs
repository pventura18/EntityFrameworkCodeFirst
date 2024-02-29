using EntityFrameworkCodeFirst.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            using(StreamReader reader = new StreamReader(ORDERDETAILS_FILE))
            {
                reader.ReadLine();
                string line = reader.ReadLine();
                while(line != null)
                {
                    string[] data = line.Split(',');
                    ProductLine productLine = new ProductLine();
                    productLine.productLine = data[0];
                    productLine.textDescription = data[1];
                    productLine.htmlDescription = data[2];
                    productLine.image = data[3];

                    AddProductLineEntry(productLine);

                    line = reader.ReadLine();
                }
            }
        }

        public void AddProducts()
        {
            using(StreamReader reader = new StreamReader(PRODUCTS_FILE))
            {
                reader.ReadLine();
                string line = reader.ReadLine();
                while(line != null)
                {
                    string[] data = line.Split(',');
                    Product product = new Product();
                    product.productCode = data[0];
                    product.productName = data[1];
                    product.productLine = data[2];
                    product.productScale = data[3];
                    product.productVendor = data[4];
                    product.productDescription = data[5];
                    product.quantityInStock = short.Parse(data[6]);
                    product.BuyPrice = double.Parse(data[7]);
                    product.MSRP = double.Parse(data[8]);

                    AddProductsEntry(product);

                    line = reader.ReadLine();
                }
            }
        }

        public void AddProductsEntry(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void AddProductLineEntry(ProductLine productLine)
        {
            context.ProductLines.Add(productLine);
            context.SaveChanges();
        }

        public void AddCustomers()
        {
            
        }

        public void AddCustomersEntry(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void AddEmployees()
        {
            throw new NotImplementedException();
        }

        public void AddEmployeesEntry(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void AddOffices()
        {
            throw new NotImplementedException();
        }

        public void AddOfficesEntry(Office office)
        {
            throw new NotImplementedException();
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

        public void AddPayments()
        {
            throw new NotImplementedException();
        }

        public void AddPaymentsEntry(Payment payment)
        {
            throw new NotImplementedException();
        }

        
    }
}
