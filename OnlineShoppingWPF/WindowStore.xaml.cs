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
        // PLEASE NO MORE MERGE CONFLICTS
        public WindowStore()
        {
            InitializeComponent();

            //Opens window in center of screen
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Gets product data from CSV and displays in store
            listBoxProductViewer.ItemsSource = ReadDataFromCSV("asd");
        }

        private void OpenAccountFromStore_Click(object sender, RoutedEventArgs e)
        {
            WindowAccount accountWindow = new WindowAccount();
            accountWindow.Show();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowCart cart = new WindowCart();
            cart.Show();
        }

        // For reading CSV file to populate (aka display) the store with items
        private List<Product> ReadDataFromCSV(string filePath)
        {
            // read
            // return
            // populate
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // right now this is just to clear the Search box, we're gonna need actual code to search for products.
            SearchBox.Clear();
        }
        private void ButtonCloseProgram_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
