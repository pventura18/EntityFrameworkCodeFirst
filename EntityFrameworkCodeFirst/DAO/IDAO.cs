using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.DAO
{
    public interface IDAO
    {
        void AddProductLine();
        void AddProducts();
        void AddOffices();
        void AddEmployees();
        void AddCustomers();
        void AddPayments();
        void AddOrders();
        void AddOrderDetails();

        void AddProductLineEntry(MODEL.ProductLine productLine);
        void AddProductsEntry(MODEL.Product product);
        void AddOfficesEntry(MODEL.Office office);
        void AddEmployeesEntry(MODEL.Employee employee);
        void AddCustomersEntry(MODEL.Customer customer);
        void AddPaymentsEntry(MODEL.Payment payment);
        void AddOrdersEntry(MODEL.Order order);
        void AddOrderDetailsEntry(MODEL.OrderDetail orderDetail);

        void ImportCsvFiles();
    }
}
