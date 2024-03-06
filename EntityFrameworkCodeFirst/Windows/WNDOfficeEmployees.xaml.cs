using EntityFrameworkCodeFirst.DAO;
using EntityFrameworkCodeFirst.Migrations;
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
    /// Interaction logic for WNDOfficeEmployees.xaml
    /// </summary>
    public partial class WNDOfficeEmployees : Window
    {
        IDAO manager;
        public WNDOfficeEmployees(IDAO manager)
        {
            InitializeComponent();
            this.manager = manager;
            cbOffices.ItemsSource = manager.GetOffices();
            lvEmployees.SelectedIndex = 0;


        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void cbOffices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvEmployees.ItemsSource = manager.GetEmployeesByOffice((string)cbOffices.SelectedValue);

        }
    }
}
