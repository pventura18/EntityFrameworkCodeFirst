using EntityFrameworkCodeFirst.MODEL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst.DAO
{
    public interface IDAO
    {
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

        IEnumerable GetCustomers(char inicial);
        IEnumerable GetSpentCustomers();
        IEnumerable GetCustomerEmployeeLocation();
        IEnumerable GetProducts(ProductFields productField, bool ascending);
        IEnumerable GetPriceOfOrders();
        IEnumerable GetDetailsOrder(int orderNumber);
        IEnumerable GetOrdersNumbers();
        IEnumerable GetShippedOrders(string status);

        IEnumerable GetEmployeesByOffice(string? v);
        IEnumerable GetOffices();
        List<Customer> GetCustomers();
        List<Product> GetProducts();
        void AddSpecialPrice(Customer customer, Product product, decimal price);
    }
}
