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
    public sealed partial class FramePage : Page
    {
        public FramePage()
        {
            this.InitializeComponent();

            Frame1.Content = new CreateOrder();
        }

        public Frame FrameContent
        {
            set { Frame1.Content = value; }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }

        #region NavigationButtons
        private void BtnClickP1(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new CreateOrder();
        }

        private void BtnClickP2(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new ViewOrdersPage();
        }

        private void BtnClickP3(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new ViewCustomerPage();
        }
        private void BtnClickP4(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new DeliveryPage();
        }

        private void BtnClickP5(object sender, RoutedEventArgs e)
        {
            Frame1.Content = new PaymentPage();
        }
        #endregion

    }
}
