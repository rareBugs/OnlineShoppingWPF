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
    /// Interaction logic for ProductManagmentWindow.xaml
    /// </summary>
    public partial class ProductManagmentWindow : Window
    {
        private List<Product> products;
        public ProductManagmentWindow()
        {
            products = Store.Instance.products;
            InitializeComponent();

            //This is a Line!!!!!

            /*products.Add(new Product("Alpha Industries", 1001, 4500, 15, "Jacket"));
            products.Add(new Product("Dickes", 1002, 2200, 10, "Sweater"));
            products.Add(new Product("Diesel", 1003, 1700, 25, "Jeans"));

            RefreshProductListView();*/
        }


        private void RefreshProductListView()
        {

            listOfProducts.Items.Clear();

            foreach (var product in products)
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
            products.Add(newProduct);

            RefreshProductListView();
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

        private Product selectedProduct;
        private void listOfProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listOfProducts.SelectedIndex >= 0 && listOfProducts.SelectedIndex < products.Count)
            {
                selectedProduct = products[listOfProducts.SelectedIndex];
            }
        }

        private void OpenInventory_Click(object sender, RoutedEventArgs e)
        {
            // Open as a modal window by using ShowDialog
            WindowInventory windowInventory = new WindowInventory();
            windowInventory.ShowDialog();
        }
    }
}
