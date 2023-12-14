using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OnlineShoppingWPF
{
    /// <summary>
    /// Interaction logic for WindowAccount.xaml
    /// </summary>
    public partial class WindowAccount : Window
    {
        private Customer loggedInCustomer;
        private List<Customer> customers; // Add this field

        public WindowAccount(Customer customer, List<Customer> customers)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Below for loading details for current logged in customer, passed through WindowStore to here
            loggedInCustomer = customer;
            this.customers = customers;
            LoadUserDetails();
        }

        // Save button code for saving eventuella changes
        private void saveChanges_Click(object sender, RoutedEventArgs e)
        {
            // Get updated details from text boxes
            string name = textBoxName.Text;
            string password = textBoxPassword.Text;
            string email = textBoxEmail.Text;
            string address = textBoxAddress.Text;

            if (int.TryParse(textBoxPostalCode.Text, out int postalCode) &&
                int.TryParse(textBoxMoney.Text, out int money))
            {
                // Update customer details
                loggedInCustomer.UpdateDetails(name, password, email, address, postalCode, money);

                // Save the updated details to the CSV file
                SaveUpdatedDetailsToCSV();

                MessageBox.Show("Changes saved successfully.");
            }
            else
            {
                MessageBox.Show("Invalid postal code or money format.");
            }
        }


        // CSV code for updating details, any details.
        private void SaveUpdatedDetailsToCSV()
        {
            try
            {
                // path of the CSV file
                string customerPath = "SavedCustomers.csv";

                // create a list to store updated customer details
                List<string> updatedCustomerDetails = new List<string>();

                // to avoid overwriting and deleting all other customers.
                foreach (Customer customer in customers)
                {
                    if (customer == loggedInCustomer)
                    {
                        updatedCustomerDetails.Add(loggedInCustomer.GetCSV());  // Use updated details
                    }
                    else
                    {
                        updatedCustomerDetails.Add(customer.GetCSV());  // Keep other customers as is
                    }
                }

                // saves all fields to CSV, overwriting previous details
                File.WriteAllLines(customerPath, updatedCustomerDetails);

                MessageBox.Show("Changes saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving updated details: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // details for current logged in customer  filled in to the account textboxes
        private void LoadUserDetails()
        {
            textBoxName.Text = loggedInCustomer.Name;
            textBoxPassword.Text = loggedInCustomer.Password;
            textBoxEmail.Text = loggedInCustomer.Email;
            textBoxAddress.Text = loggedInCustomer.Address;
            textBoxPostalCode.Text = loggedInCustomer.PostalCode.ToString();
            textBoxMoney.Text = loggedInCustomer.Money.ToString();
        }


        // Closes window
        private void ButtonCloseProgram_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}