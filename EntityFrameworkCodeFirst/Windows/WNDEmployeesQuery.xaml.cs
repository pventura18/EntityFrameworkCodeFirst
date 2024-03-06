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
    /// Interaction logic for WNDEmployeesQuery.xaml
    /// </summary>
    public partial class WNDEmployeesQuery : Window
    {
        IDAO manager;
        public WNDEmployeesQuery(DAO.IDAO manager)
        {
            InitializeComponent();
            this.manager = manager;
            cbJobTittle.ItemsSource = manager.GetJobTittles();

        }

     
        private void btnOrderByEmployeeNumber_Click(object sender, RoutedEventArgs e)
        {
            lvEmployees.ItemsSource = manager.GetEmployeesByAscendingNumber();
        }

        private void btnGettAll_Click(object sender, RoutedEventArgs e)
        {
          lvEmployees.ItemsSource = manager.GetEmployees();

        }

        private void cbJobTittle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvEmployees.ItemsSource = manager.GetEmployesByJobTittle((string)cbJobTittle.SelectedValue);

        }

        private void btnOrderByDescendingEmployeeNumber_Click(object sender, RoutedEventArgs e)
        {
            lvEmployees.ItemsSource = manager.GetEmployeesByDescendingNumber();

        }
    }
}
