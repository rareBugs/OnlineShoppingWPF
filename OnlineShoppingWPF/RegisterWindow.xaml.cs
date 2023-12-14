using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public MainWindow mainWindow { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public List<Customer> CustomerList { get; set; }

        string customerPath = "SavedCustomers.csv";
        string employeePath = "SavedEmployees.csv";


        public RegisterWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            EmployeeList = new List<Employee>();
            CustomerList = new List<Customer>();
        }


        private void customerButton_Click(object sender, RoutedEventArgs e)
        {
            customerRegistration.Visibility = Visibility.Visible;
        }


        private void employeeButton_Click(object sender, RoutedEventArgs e)
        {
            employeeRegistration.Visibility = Visibility.Visible;
        }


        private void employeeFinalRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string employeeName = employeeNameTextBox.Text;
            string employeePassword = employeePasswordTextBox.Text;
            if (string.IsNullOrWhiteSpace(employeeName) || string.IsNullOrWhiteSpace(employeePassword))
            {
                MessageBox.Show("Please enter a valid employee name and password.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                mainWindow.RegisterEmployee(employeeNameTextBox.Text, employeePasswordTextBox.Text);
                using (StreamWriter writer = new StreamWriter(employeePath))
                {
                    foreach (Employee employee in EmployeeList)
                    {
                        writer.WriteLine(employee.GetCSV());
                    }
                }
            }
            Close();
        }


        private void customerFinalRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string postalCodeText = customerPostalCodeTextBox.Text;
            string moneyText = customerMoneyTextBox.Text;

            if (string.IsNullOrWhiteSpace(postalCodeText) || !int.TryParse(postalCodeText, out int postalCode))
            {
                MessageBox.Show("Please enter a valid postal code.", "Invalid Postal Code", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (string.IsNullOrWhiteSpace(moneyText) || !int.TryParse(moneyText, out int money))
            {
                MessageBox.Show("Please enter your amount of money in numbers", "Invalid money amount input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string customerName = customerNameTextBox.Text;
                string customerPassword = customerPasswordTextBox.Text;
                string customerEmail = customerEmailTextBox.Text;
                string customerAddress = customerAddressTextBox.Text;

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(customerPassword) ||
                    string.IsNullOrWhiteSpace(customerEmail) || string.IsNullOrWhiteSpace(customerAddress))
                {
                    MessageBox.Show("Please enter valid information for all fields.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    mainWindow.RegisterCustomer(
                        customerName,
                        customerPassword,
                        customerEmail,
                        customerAddress,
                        postalCode,
                        money);

                    using (StreamWriter writer = new StreamWriter(customerPath))
                    {
                        foreach (Customer customer in CustomerList)
                        {
                            writer.WriteLine(customer.GetCSV());
                        }
                    }
                    Close();
                }
            }
        }
    }
}