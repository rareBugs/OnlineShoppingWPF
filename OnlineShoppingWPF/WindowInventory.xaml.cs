using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            OrderHistory.ItemsSource = Store.Instance.orders;
            InventoryStock.ItemsSource = Store.Instance.products;
            ViewAvailableTransport.ItemsSource = Store.Instance.transportVehicles;
        }

        public void RefreshLists()
        {
            OrderHistory.Items.Refresh();
            InventoryStock.Items.Refresh();
            ViewAvailableTransport.Items.Refresh();
        }

        private void InventoryStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OrderHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrderProducts.ItemsSource = null;
            Order? order = OrderHistory.SelectedItem as Order;
            if (order != null)
            {
                OrderProducts.ItemsSource = order.Products;
            }
        }

        private void ViewAvaibleTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeliveryStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PackageOrder_Click(object sender, RoutedEventArgs e)
        {
            Order? order = OrderHistory.SelectedItem as Order;
            if (order != null)
            {
                bool hasAllProducts = true;
                foreach (var orderProduct in order.Products)
                {
                    bool productFound = false;
                    foreach (var inventoryProduct in Store.Instance.products)
                    {
                        if (inventoryProduct.Id == orderProduct.Id && inventoryProduct.Name == orderProduct.Name)
                        {
                            productFound = inventoryProduct.Quantity >= orderProduct.Quantity;
                            break;
                        }
                    }
                    if (!productFound)
                    {
                        hasAllProducts = false;
                        break;
                    }
                }
                if (hasAllProducts)
                {
                    if (order.Packaged())
                    {
                        foreach (var orderProduct in order.Products)
                        {
                            foreach (var inventoryProduct in Store.Instance.products)
                            {
                                if (inventoryProduct.Id == orderProduct.Id && inventoryProduct.Name == orderProduct.Name)
                                {
                                    inventoryProduct.Quantity -= orderProduct.Quantity;
                                    break;
                                }
                            }
                        }
                        RefreshLists();
                    }
                    else
                    {
                        MessageBox.Show("Order has wrong Status");
                    }
                }
                else
                {
                    MessageBox.Show("Products not in inventory");
                }
            }
        }

        private void UpdateVehicles_Click(object sender, RoutedEventArgs e)
        {
            foreach (var vehicle in Store.Instance.transportVehicles)
            {
                int orderNumber = vehicle.OrderNumber;
                DeliverStatus status = vehicle.TryDeliverOrder();
                if (status != DeliverStatus.NoOrder)
                {
                    string progress = vehicle.Name + " " + status.ToString() + " " + orderNumber;
                    DeliveryStatus.Items.Add(progress);
                    if (vehicle.OrderNumber == 0)
                    {
                        foreach (var order in Store.Instance.orders)
                        {
                            if (order.OrderNumber == orderNumber)
                            {
                                if (status == DeliverStatus.Delivered)
                                {
                                    order.SetStatus(OrderStatus.Delivered);
                                }
                                else if (status == DeliverStatus.Lost)
                                {
                                    order.SetStatus(OrderStatus.Lost);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            RefreshLists();
        }

        private void LoadOrder_Click(object sender, RoutedEventArgs e)
        {
            Order? order = OrderHistory.SelectedItem as Order;
            TransportVehicle? vehicle = ViewAvailableTransport.SelectedItem as TransportVehicle;
            if (order != null && vehicle != null)
            {
                if (vehicle.LoadOrder(order))
                {
                    RefreshLists();
                }
                else
                {
                    MessageBox.Show("Failed to load order");
                }
            }
        }
    }
}
