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
            using(StreamReader reader = new StreamReader("PRODUCTLINES.csv"))
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

        public void AddProductLineEntry(ProductLine productLine)
        {
            context.ProductLines.Add(productLine);
            context.SaveChanges();
        }

        public void AddCustomers()
        {
            throw new NotImplementedException();
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

        public void AddProducts()
        {
            throw new NotImplementedException();
        }

        public void AddProductsEntry(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
