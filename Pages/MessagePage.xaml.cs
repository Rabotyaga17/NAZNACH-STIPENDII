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

namespace Otdelenie.Pages
{
    /// <summary>
    /// Логика взаимодействия для MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        public MessagePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddMessage();
        }

        private async void AddMessage()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = ConnectionStr.Get;

                //Открываем подключение
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand
                {

                    //Запрос
                    CommandText = "INSERT INTO Messages VALUES('" + Message.Text + "')",

                    Connection = connection
                };

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                connection.Close();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //В любом случае закрываем подключение
                connection.Close();
                MessageBox.Show("Сообщение отправлено");
                this.NavigationService.Navigate(new AuthorizationPage());
            }
        }
    }
}
