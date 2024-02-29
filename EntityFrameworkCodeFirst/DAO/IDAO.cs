using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.DAO
{
    public interface IDAO
    {
        void AddProductLine(MODEL.ProductLine productLine);
        void AddProducts(MODEL.Product product);
        void AddOffices(MODEL.Office office);
        void AddEmployees(MODEL.Employee employee);
        void AddCustomers(MODEL.Customer customer);
        void AddPayments(MODEL.Payment payment);
        void AddOrders(MODEL.Order order);
        void AddOrderDetails(MODEL.OrderDetail orderDetail);

        void AddProductLineEntry();
        void AddProductsEntry();
        void AddOfficesEntry();
        void AddEmployeesEntry();
        void AddCustomersEntry();
        void AddPaymentsEntry();
        void AddOrdersEntry();
        void AddOrderDetailsEntry();

        void ImportCsvFiles();
    }
}
