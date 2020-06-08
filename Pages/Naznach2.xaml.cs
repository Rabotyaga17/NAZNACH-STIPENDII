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
    /// Логика взаимодействия для Naznach2.xaml
    /// </summary>
    public partial class Naznach2 : Page
    {
        public Naznach2()
        {
            InitializeComponent();
            Naznach();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Center.Navigate(new Naznach());
        }

        private async void Naznach()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = ConnectionStr.Get;

                //Открываем подключение
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand();

                //Запрос
                command.CommandText = "SELECT * FROM Scholarship";

                command.Connection = connection;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = dataReader[0].ToString();
                    item.Content = new NaznachElement(dataReader[0].ToString(),
                        dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(),
                        dataReader[4].ToString());
                    StudentsList.Items.Add(item);
                }
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
            }
        }
    }
}
