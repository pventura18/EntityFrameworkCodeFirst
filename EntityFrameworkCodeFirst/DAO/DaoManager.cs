using EntityFrameworkCodeFirst.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.DAO
{
    public class DaoManager : IDAO
    {
        public void ImportCsvFiles()
        {
            AddCustomers();
            AddEmployees();
            AddOffices();
            AddOrderDetails();
            AddOrders();
            AddPayments();
            AddProductLine();
            AddProducts();
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

        public void AddProductLine()
        {
            throw new NotImplementedException();
        }

        public void AddProductLineEntry(ProductLine productLine)
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
