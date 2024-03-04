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
<<<<<<< HEAD:EntityFrameworkCodeFirst/Windows/MainWindow.xaml.cs
            //manager.ImportCsvFiles();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            WNDCustomers wndCustomers = new WNDCustomers();
            wndCustomers.Show();
=======
            manager.AddProductLine();
            manager.AddProducts();
            manager.AddOffices();
            manager.AddEmployees();
            manager.AddCustomers();
            manager.AddPayments();
            manager.AddOrders();
            manager.AddOrderDetails();
>>>>>>> origin/master:EntityFrameworkCodeFirst/MainWindow.xaml.cs
        }
    }
}
