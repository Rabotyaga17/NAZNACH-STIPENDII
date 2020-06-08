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
using System.Data.SqlClient;
using Otdelenie.Logic;


namespace Otdelenie.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentBar.xaml
    /// </summary>
    public partial class StudentBar : Page
    {
        public StudentBar()
        {
            InitializeComponent();
        }

        private void Authorization_Selected(object sender, RoutedEventArgs e)
        {
            //((MainWindow)System.Windows.Application.Current.MainWindow).Center.Navigate(new StudentsPage());
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

        private void Messages_Selected_1(object sender, RoutedEventArgs e)
        {
            if (CurrentStudent.SStatus == "1")
                ((MainWindow)System.Windows.Application.Current.MainWindow).Center.Navigate(new MessagesssPage());
            else
                MessageBox.Show("Вы не получаете стипендию");
        }
    }
}
