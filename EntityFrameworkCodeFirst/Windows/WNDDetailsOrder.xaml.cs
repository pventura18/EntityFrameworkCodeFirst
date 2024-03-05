using EntityFrameworkCodeFirst.DAO;
using EntityFrameworkCodeFirst.MODEL;
using System;
using System.Collections;
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
    /// Lógica de interacción para WNDDetailsOrder.xaml
    /// </summary>
    public partial class WNDDetailsOrder : Window
    {
        IDAO manager;
        public WNDDetailsOrder(IDAO manager)
        {
            InitializeComponent();
            this.manager = manager;
            cbOrders.ItemsSource = manager.GetOrdersNumbers();
            cbOrders.SelectedIndex = 0;
            lvDetailsOrder.ItemsSource = manager.GetDetailsOrder((int)cbOrders.SelectedValue);
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            lvDetailsOrder.ItemsSource = manager.GetDetailsOrder((int)cbOrders.SelectedValue);
        }
    }
}
