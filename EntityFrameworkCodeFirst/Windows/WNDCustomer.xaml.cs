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
using System.Windows.Shapes;

namespace EntityFrameworkCodeFirst.Windows
{
    /// <summary>
    /// Lógica de interacción para WNDCustomer.xaml
    /// </summary>
    public partial class WNDCustomer : Window
    {
        IDAO manager;
        public WNDCustomer(IDAO manager)
        {
            InitializeComponent();
            cbLetter.ItemsSource = GenerateLetters();
            cbLetter.SelectedIndex = 0;
            lvCustomers.ItemsSource = manager.GetCustomers('*');
            this.manager = manager;
        }
        private List<Char> GenerateLetters()
        {
            List<Char> letters = new List<Char>();
            letters.Add('*');
            for (char c = 'A'; c <= 'Z'; c++)
            {
                letters.Add(c);
            }
            return letters;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            List<Customer> list = manager.GetCustomers((char)cbLetter.SelectedItem);

            lvCustomers.ItemsSource = manager.GetCustomers((char)cbLetter.SelectedItem);
        }


    }
}
