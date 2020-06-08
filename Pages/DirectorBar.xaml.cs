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
    /// Логика взаимодействия для DirectorBar.xaml
    /// </summary>
    public partial class DirectorBar : Page
    {
        public DirectorBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Студенты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Authorization_Selected(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Center.Navigate(new StudentPage());
        }

        private void Messages_Selected(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Center.Navigate(new MessagesPage());
        }

        private void Exit_Selected(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Вы уверены, что хотите выйти из учетной записи?", "Выход из учетной записи", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                User.Clear();
                ((MainWindow)System.Windows.Application.Current.MainWindow).Center.Navigate(new AuthorizationPage());
                this.NavigationService.Navigate(new StartBar());
            }
        }

        private void Stipendii_Selected(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Center.Navigate(new StudentsPage());
        }

    }
}
