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
    /// Interaction logic for WindowInventory.xaml
    /// </summary>
    public partial class WindowInventory : Window
    {
        public WindowInventory()
        {
            InitializeComponent();
        }

        private void InventoryStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OrderHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ViewAvaibleTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeliveryStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
