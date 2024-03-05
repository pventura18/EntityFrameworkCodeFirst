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
    /// Lógica de interacción para WNDProducts.xaml
    /// </summary>
    public partial class WNDProducts : Window
    {
        private IDAO manager;
        public WNDProducts(IDAO manager)
        {
            InitializeComponent();
            this.manager = manager;
            foreach (ProductFields field in Enum.GetValues(typeof(ProductFields)))
            {
                cbField.Items.Add(field);
            }
            cbField.SelectedIndex = 0;
            cbAscending.IsChecked = true;
            lvProducts.ItemsSource = manager.GetProducts((ProductFields)cbField.SelectedValue, (bool)cbAscending.IsChecked);
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            lvProducts.ItemsSource = manager.GetProducts((ProductFields)cbField.SelectedValue, (bool)cbAscending.IsChecked);
        }
    }
}
