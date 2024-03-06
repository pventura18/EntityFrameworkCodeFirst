using EntityFrameworkCodeFirst.DAO;
using EntityFrameworkCodeFirst.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityFrameworkCodeFirst.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MODEL.BusinessDBContext context = new MODEL.BusinessDBContext();
        private IDAO manager;
        public MainWindow()
        {
            InitializeComponent();
            DaoFactory daoFactory = new DaoFactory();
            manager = daoFactory.GetDaoManager(context);

            //manager.ImportCsvFiles();
            //List<Customer> customers = manager.GetCustomers();
            //List<Product> products = manager.GetProducts();

            //for (int i = 0; i < 10; i++)
            //{
            //    Random r = new Random();
            //    int indexCustomer = r.Next(customers.Count);
            //    int indexProduct1 = r.Next(products.Count);
            //    int indexProduct2 = r.Next(products.Count);

            //    manager.AddSpecialPrice(customers[indexCustomer], products[indexProduct1], GetRandomPrice());
            //    manager.AddSpecialPrice(customers[indexCustomer], products[indexProduct2], GetRandomPrice());
            //}
        }

        private static decimal GetRandomPrice()
        {
            Random rand = new Random();
            return Math.Round((decimal)rand.NextDouble() * 10000, 2);
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            WNDCustomer wndCustomers = new WNDCustomer(manager);
            wndCustomers.ShowDialog();

        }

        private void btnAmountSpent_Click(object sender, RoutedEventArgs e)
        {
            WNDSpentCustomer spentCustomer = new WNDSpentCustomer(manager);
            spentCustomer.ShowDialog();
        }

        private void btnCustomerEmployeeLocation_Click(object sender, RoutedEventArgs e)
        {
            WNDCustomerEmployeeLocation customerEmployeeLocation = new WNDCustomerEmployeeLocation(manager);
            customerEmployeeLocation.ShowDialog();
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            WNDProducts wndProducts = new WNDProducts(manager);
            wndProducts.ShowDialog();
        }

        private void btnPriceOrders_Click(object sender, RoutedEventArgs e)
        {
            WNDPriceOfOrders wndPriceOfOrders = new WNDPriceOfOrders(manager);
            wndPriceOfOrders.ShowDialog();
        }

        private void btnDetailsOrder_Click(object sender, RoutedEventArgs e)
        {
            WNDDetailsOrder wndDetailsOrder = new WNDDetailsOrder(manager);
            wndDetailsOrder.ShowDialog();
        }

        private void btnShippedStatus_Click(object sender, RoutedEventArgs e)
        {
            WNDShippedOrders wndShippedOrders = new WNDShippedOrders(manager);
            wndShippedOrders.ShowDialog();

        }

        private void btnemployeesOffice_Click(object sender, RoutedEventArgs e)
        {
            WNDOfficeEmployees wndOfficeEmployees = new WNDOfficeEmployees(manager);
            wndOfficeEmployees.ShowDialog();
        }

        private void btnPaymentsCustomers_Click(object sender, RoutedEventArgs e)
        {
           WNDPaymentsCustomer wNDPaymentsCustomer = new WNDPaymentsCustomer(manager);
            wNDPaymentsCustomer.ShowDialog();   


        }

        private void btnEmployeeQuery_Click(object sender, RoutedEventArgs e)
        {
            WNDEmployeesQuery wndEmployeesQuery = new WNDEmployeesQuery(manager);
            wndEmployeesQuery.ShowDialog();

        }

        private void btnCountryOffice_Click(object sender, RoutedEventArgs e)
        {
            WNDOfficeCountry wndOfficeCountry = new WNDOfficeCountry(manager);
            wndOfficeCountry.ShowDialog();

        }

        private void btnEmployeeOficeRelated_Click(object sender, RoutedEventArgs e)
        {
            WNDEmployeeJoinOffice wndEmployeeOfficeRelated = new WNDEmployeeJoinOffice(manager);
            wndEmployeeOfficeRelated.ShowDialog();

        }
    }
}
