using System;
using System.Collections.Generic;
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
        public WindowAccount() // new comment for push
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void SaveChangeAddress_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddToWallet_Click(object sender, RoutedEventArgs e)
        {

        }


        private void orderInformationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void returnOrderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // Views Funds information box
        private void AddFundsButton_Click(object sender, RoutedEventArgs e)
        {
            RightSideGrid.Visibility = Visibility.Visible;
            ShowSection(AddFundsSection);
        }

        // Views Address information box
        private void ChangeAddressButton_Click(object sender, RoutedEventArgs e)
        {
            RightSideGrid.Visibility = Visibility.Visible;
            ShowSection(ChangeAddressSection);
        }

        // Views Wallet information box
        private void CheckWalletButton_Click(object sender, RoutedEventArgs e)
        {
            RightSideGrid.Visibility = Visibility.Visible;
            ShowSection(CheckWalletSection);
        }

        // Views order information box
        private void orderInformationButton_Click(object sender, RoutedEventArgs e)
        {
            RightSideGrid.Visibility = Visibility.Visible;
            ShowSection(orderInformationSection);
        }

        // Very cool fading animations
        private void ShowSection(StackPanel section)
        {
            // fade animation
            DoubleAnimation fadeOutAnimation = new DoubleAnimation(0, TimeSpan.FromSeconds(0.2));
            fadeOutAnimation.Completed += (sender, e) =>
            {
                // Hide all sections after fade
                ChangeAddressSection.Visibility = Visibility.Collapsed;
                CheckWalletSection.Visibility = Visibility.Collapsed;
                AddFundsSection.Visibility = Visibility.Collapsed;
                orderInformationSection.Visibility = Visibility.Collapsed;

                // Show the selected section with fade
                section.Visibility = Visibility.Visible;
                DoubleAnimation fadeInAnimation = new DoubleAnimation(1, TimeSpan.FromSeconds(0.5));
                section.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
            };
            // Start the fade animation
            section.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
        }

        // Closes window
        private void ButtonCloseProgram_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
