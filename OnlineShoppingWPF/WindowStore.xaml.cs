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

namespace OnlineShoppingWPF
{
    /// <summary>
    /// Interaction logic for WindowStore.xaml
    /// </summary>
    public partial class WindowStore : Window
    {
        private Customer loggedInCustomer;
        private List<Customer> customers;

        public WindowStore(Customer loggedInCustomer, List<Customer> customers)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.loggedInCustomer = loggedInCustomer;
            this.customers = customers;
        }


        private void OpenAccountFromStore_Click(object sender, RoutedEventArgs e)
        {
            WindowAccount windowAccount = new WindowAccount(loggedInCustomer, customers);
            windowAccount.Show();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowCart cart = new WindowCart();
            cart.Show();
        }


        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void ButtonSearch(object sender, RoutedEventArgs e)
        {
            SearchBox.Clear();
        }


        private void ButtonCloseProgram_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}