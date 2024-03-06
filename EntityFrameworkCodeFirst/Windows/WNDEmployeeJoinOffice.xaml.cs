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
    /// Interaction logic for WNDEmployeeJoinOffice.xaml
    /// </summary>
    public partial class WNDEmployeeJoinOffice : Window
    {
        IDAO manager;
        public WNDEmployeeJoinOffice(IDAO manager)
        {
            InitializeComponent();
            this.manager = manager;

            lvEmployeesOffices.ItemsSource = manager.GetEmployeesEntities();


        }
    }
}
