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
using System.IO;
using System.Text.Json.Serialization;
using System.Xml;
using System.Net.Http.Json;
using System.Linq.Expressions;

namespace OnlineShoppingWPF
{
    /// <summary>
    /// Interaction logic for ProductManagmentWindow.xaml
    /// </summary>
    public partial class ProductManagmentWindow : Window
    {
        private List<Product> Products;
        public ProductManagmentWindow()
        {
            Products = Store.Instance.products;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //This is a Line!!!!!

            /*products.Add(new Product("Alpha Industries", 1001, 4500, 15, "Jacket"));
            products.Add(new Product("Dickes", 1002, 2200, 10, "Sweater"));
            products.Add(new Product("Diesel", 1003, 1700, 25, "Jeans"));

            RefreshProductListView();*/
        }


        private void RefreshProductListView()
        {

            listOfProducts.Items.Clear();

            foreach (var product in Products)
            {
                listOfProducts.Items.Add($"{product.Name}- Quantity: {product.Quantity}");
            }

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = ProductName.Text;
            int productId = int.Parse(ProductID.Text);
            int productPrice = int.Parse(ProductPrice.Text);
            int productQuantity = int.Parse (ProductQuantity.Text);
            string productCategory = ProductCategory.Text;

            Product newProduct = new Product(productName, productId, productPrice, productQuantity, productCategory);
            Products.Add(newProduct);

            RefreshProductListView();

            listOfProducts.Items.Add($"{newProduct.Name}- Quantity: {newProduct.Quantity}");
        }

        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct != null)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the Quantity you want to remove:", "Remove Product", "1");
                if(int.TryParse(input, out int quantityToRemove))
                {
                    if (quantityToRemove > 0 && quantityToRemove <= selectedProduct.Quantity) 
                    {
                        selectedProduct.Quantity -= quantityToRemove;
                        RefreshProductListView();
                    }
                    else
                    {
                        MessageBox.Show("Invalid quantity to remove!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input for Quantity.");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to remove.");
            }

        }

        private Product selectedProduct = null;
        private void listOfProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selectedProduct = listOfProducts.SelectedItem as Product; 
            if (selectedProduct != null) 
            {
                ProductName.Text = selectedProduct.Name;
                ProductID.Text = selectedProduct.Id.ToString();
                ProductPrice.Text = selectedProduct.Price.ToString();
                ProductQuantity.Text = selectedProduct.Quantity.ToString();
                ProductCategory.Text = selectedProduct.Category.ToString();
            }
            if (listOfProducts.SelectedIndex >= 0 && listOfProducts.SelectedIndex < Products.Count)
            {
                selectedProduct = Products[listOfProducts.SelectedIndex];
            }
        }

        private void OpenInventory_Click(object sender, RoutedEventArgs e)
        {
            // Open as a modal window by using ShowDialog
            WindowInventory windowInventory = new WindowInventory();
            windowInventory.ShowDialog();
        }

        private void ChangeProducts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveToCSV_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "Products.csv";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Product Name,Quantity,Price,Category,Id");

                    foreach (var product in Products)
                    {
                        writer.WriteLine($"{product.Name},{product.Quantity},{product.Price},{product.Category},{product.Id}");
                    }
                }
                MessageBox.Show("Products Saved Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Saving Products: ");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
