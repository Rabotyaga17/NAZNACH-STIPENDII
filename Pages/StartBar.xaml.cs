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
using Otdelenie.Logic;

namespace Otdelenie.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartBar.xaml
    /// </summary>
    public partial class StartBar : Page
    {
        public StartBar()
        {
            InitializeComponent();
        }

        private void Authorization_Selected(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Center.Navigate(new AuthorizationPage());
        }

        private void Messages_Selected(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Center.Navigate(new MessagePage());
        }
    }
}
