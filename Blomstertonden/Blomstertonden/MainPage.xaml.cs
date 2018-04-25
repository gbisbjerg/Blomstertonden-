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

using Windows.ApplicationModel.Core;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Blomstertonden
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //ApplicationView.GetForCurrentView().Title = "TEST";
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            // Set the BackgroundElement instead of the entire Titlebar grid
            // so that we can add clickable element in title bar.
            Window.Current.SetTitleBar(BackgroundElement);

            String path = Directory.GetCurrentDirectory() + @"\FlipView";
            LoginFV.ItemsSource = Directory.GetFiles(path).Select(p => "ms-appx:///" + p);
            int change = 1;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(7);
            timer.Tick += (o, a) =>
            {
                // If we'd go out of bounds then reverse
                int newIndex = LoginFV.SelectedIndex + change;
                if (newIndex >= LoginFV.Items.Count || newIndex < 0)
                {
                    change *= -1;
                }

                LoginFV.SelectedIndex += change;
            };

            timer.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Template), null);
        }
    }
}
