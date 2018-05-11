﻿using System;
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
    public sealed partial class PaymentPage : Page
    {
        FramePage framePage;
        public PaymentPage(FramePage _framePage)
        {
            this.InitializeComponent();
            framePage = _framePage;
        }


        private void BtnClickP1(object sender, RoutedEventArgs e)
        {
            framePage.FrameContent = new CreateOrder(framePage);
        }
        private void BtnClickP2(object sender, RoutedEventArgs e)
        {
            framePage.FrameContent = new ViewOrdersPage();
        }

        private void BtnClickP3(object sender, RoutedEventArgs e)
        {
            framePage.FrameContent = new CreateOrder(framePage);
        }

        private void ListView_ContextCanceled(UIElement sender, RoutedEventArgs args)
        {

        }
    }
}
