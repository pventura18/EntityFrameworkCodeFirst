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

        void ImportCsvFiles();

        IEnumerable GetCustomers(char inicial);
        IEnumerable GetSpentCustomers();
        IEnumerable GetCustomerEmployeeLocation();
        IEnumerable GetProducts(ProductFields productField, bool ascending);
        IEnumerable GetPriceOfOrders();
        IEnumerable GetDetailsOrder(int orderNumber);
        IEnumerable GetOrdersNumbers();
        IEnumerable GetShippedOrders(string status);
        IEnumerable GetEmployeesByOffice(string office);
        IEnumerable GetOffices();
        IEnumerable GetJobTittles();
        IEnumerable GetEmployees();
        IEnumerable GetEmployesByJobTittle(string jobTittle); 
        IEnumerable GetEmployeesByAscendingNumber();
        IEnumerable GetEmployeesByDescendingNumber();
        IEnumerable GetEmployeesEntities();
        List<Customer> GetCustomers();
        List<Product> GetProducts();
        List<String> GetCountry();
        IEnumerable GetOfficesByCountries(string country);
        IEnumerable GetCustomerPayments();
        void AddSpecialPrice(Customer customer, Product product, decimal price);
    }
}
