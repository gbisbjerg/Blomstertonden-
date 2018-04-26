using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Blomstertonden
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewCustomerPage : Page
    {
        public ViewCustomerPage()
        {
            this.InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateOrder), null);
        }

        private void AllOrders_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewOrdersPage), null);
        }

        private void AllCustomers_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewCustomerPage), null);
        }

        private void Delivery_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DeliveryPage), null);
        }

        private void Summary_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(StatisticPage), null);
        }
    }
}
