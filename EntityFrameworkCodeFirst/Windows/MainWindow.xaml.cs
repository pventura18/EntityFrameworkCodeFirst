using EntityFrameworkCodeFirst.DAO;
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
           // manager.ImportCsvFiles();
           


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
    }
}
