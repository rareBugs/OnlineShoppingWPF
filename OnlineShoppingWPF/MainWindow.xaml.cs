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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnlineShoppingWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> customers = new List<Customer>();
        List<Employee> employees = new List<Employee>();
        string username = "NBI";
        string password = "password";
        public MainWindow()
        {
            InitializeComponent();
        }
        string customerPath = "SavedCustomers.csv";
        string employeePath = "SavedEmployees.csv";
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            frontPage.Visibility = Visibility.Collapsed;
            loginScreenGrid.Visibility = Visibility.Visible;
            LoadCustomers();
            LoadEmployees();
        }

        private void loginButton2_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;
            foreach (Customer customer in customers)
            {
                if (customer.Name == username && customer.Password == password)
                {
                    ProductManagmentWindow productManagmentWindow = new ProductManagmentWindow();
                    productManagmentWindow.Show();
                }
                else
                    foreach (Employee employee in employees)
                    {
                        if (employee.Name == username && employee.Password == password)
                        {
                            ProductManagmentWindow productManagmentWindow = new ProductManagmentWindow();
                            productManagmentWindow.Show();
                        }
                    }
            }
        }
        private void browseAsGuestButton_Click(object sender, RoutedEventArgs e)
        {
            ProductManagmentWindow productManagmentWindow = new ProductManagmentWindow();
            productManagmentWindow.Show();
        }

        private void showAvailableCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            availableCustomersListBox.Visibility = Visibility.Visible;
            removeCustomerButton.Visibility = Visibility.Visible;
            availableEmployeesListBox.Visibility = Visibility.Collapsed;
            removeEmployeeButton.Visibility = Visibility.Collapsed;
            removeEmployeeLabel.Visibility = Visibility.Collapsed;
        }

        private void AvailableCustomersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer selectedCustomer = availableCustomersListBox.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                usernameTextBox.Text = selectedCustomer.Name;
                passwordBox.Password = selectedCustomer.Password;
            }
            else
            {
                usernameTextBox.Text = string.Empty;
                passwordBox.Password = string.Empty;
            }
        }
        private void removeCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            Customer selectedCustomer = availableCustomersListBox.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                customers.Remove(selectedCustomer);
                availableCustomersListBox.Items.Remove(selectedCustomer);

                removeCustomerLabel.Content = "Customer removed";
            }
            else
            {
                removeCustomerLabel.Content = "No customer selected";
            }
        }
        private void LoadCustomers()
        {

            customers.Clear();
            availableCustomersListBox.Items.Clear();
            using (StreamReader reader = new StreamReader(customerPath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] strings = line.Split(",");
                    string name = strings[0];
                    string password = strings[1];
                    string email = strings[2];
                    string address = strings[3];
                    if (int.TryParse(strings[4], out int postalCode))
                    {
                        Customer customer = new Customer(name, password, email, address, postalCode);
                        customers.Add(customer);
                        availableCustomersListBox.Items.Add(customer);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid postal code: {strings[4]}");
                    }
                    line = reader.ReadLine();
                }
            }
        }
        private void LoadEmployees()
        {
            employees.Clear();
            availableEmployeesListBox.Items.Clear();
            using (StreamReader reader = new StreamReader(employeePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                   string[] strings = line.Split(",");
                   string name = strings[0];
                   string password = strings[1];
                   Employee employee = new Employee(name, password);
                   employees.Add(employee);
                   availableEmployeesListBox.Items.Add(employee);
                   line = reader.ReadLine();
                }
            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerwindow = new RegisterWindow();
            registerwindow.mainWindow = this;
            registerwindow.EmployeeList = employees;
            registerwindow.CustomerList = customers;
            LoadCustomers();
            LoadEmployees();
            registerwindow.Show();
        }
        public void RegisterEmployee(string name, string password)
        {
            this.Name = name;
            this.password = password;
            Employee newEmployee = new Employee(name, password);
            employees.Add(newEmployee);
            availableEmployeesListBox.Items.Add(newEmployee);
            availableEmployeesListBox.Items.Refresh();
        }
        public void RegisterCustomer(string name, string password, string email, string address, int postalCode)
        {
            this.Name = name;
            this.password = password;

            Customer newCustomer = new Customer(name, password, email, address, postalCode);
            customers.Add(newCustomer);
            availableCustomersListBox.Items.Add(newCustomer);
            availableCustomersListBox.Items.Refresh();
        }

        private void AvailableEmployeesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = availableEmployeesListBox.SelectedItem as Employee;
            if (selectedEmployee != null)
            {
                usernameTextBox.Text = selectedEmployee.Name;
                passwordBox.Password = selectedEmployee.Password;
            }
            else
            {
                usernameTextBox.Text = string.Empty;
                passwordBox.Password = string.Empty;
            }
        }

        private void showAvailableEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            availableEmployeesListBox.Visibility = Visibility.Visible;
            removeEmployeeButton.Visibility = Visibility.Visible;
            availableCustomersListBox.Visibility = Visibility.Collapsed;
            removeCustomerButton.Visibility = Visibility.Collapsed;
            removeCustomerLabel.Visibility = Visibility.Collapsed;
        }

        private void removeEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = availableEmployeesListBox.SelectedItem as Employee;
            if (selectedEmployee != null)
            {
                employees.Remove(selectedEmployee);
                availableEmployeesListBox.Items.Remove(selectedEmployee);

                removeEmployeeLabel.Content = "Employee removed";
            }
            else
            {
                removeEmployeeLabel.Content = "No employee selected";
            }
        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            loginScreenGrid.Visibility = Visibility.Collapsed;
            frontPage.Visibility = Visibility.Visible;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
