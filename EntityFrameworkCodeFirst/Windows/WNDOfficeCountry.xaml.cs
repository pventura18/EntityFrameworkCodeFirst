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
    /// Interaction logic for WNDOfficeCountry.xaml
    /// </summary>
    public partial class WNDOfficeCountry : Window
    {
        IDAO manager;
        public WNDOfficeCountry(IDAO manager)
        {
            InitializeComponent();
            this.manager = manager; 
            cmbOfficeCountry.ItemsSource = manager.GetCountry();
        }

        private void cmbOfficeCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvOfficeCountry.ItemsSource = manager.GetOfficesByCountries((string)cmbOfficeCountry.SelectedValue);

        }
    }
}
