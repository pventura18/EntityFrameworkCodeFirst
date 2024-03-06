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
using System.Windows.Shapes;

namespace EntityFrameworkCodeFirst.Windows
{
    /// <summary>
    /// Interaction logic for WNDShippedOrders.xaml
    /// </summary>
    public partial class WNDShippedOrders : Window
    {
        IDAO manager;
        public WNDShippedOrders(DAO.IDAO manager)
        {
            InitializeComponent();
            this.manager = manager;
            List<String>lstStatus= new List<string>();
            lstStatus.Add("Shipped");
            lstStatus.Add("In Process");
            lstStatus.Add("Cancelled");
            cbOrderDetails.ItemsSource = lstStatus;
               

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            lvOrderShipped.ItemsSource = manager.GetShippedOrders((string)cbOrderDetails.SelectedValue);

        }
    }
}
