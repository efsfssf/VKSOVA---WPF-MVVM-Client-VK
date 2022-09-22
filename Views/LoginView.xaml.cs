using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для UsersListingView.xaml
    /// </summary>
    public partial class UsersListingView : UserControl
    {
        public UsersListingView()
        {
            InitializeComponent();
        }

        private void WebView_OnNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs args)
        {
            if (args.IsSuccess)
            {
                var bindingExpression =
                    webView.GetBindingExpression(WebView2.SourceProperty);
                if (webView.Source?.AbsoluteUri != null)
                    bindingExpression?.UpdateSource();
            }
        }
    }
}
