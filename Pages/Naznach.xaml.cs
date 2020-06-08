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
    /// Логика взаимодействия для Naznach.xaml
    /// </summary>
    public partial class Naznach : Page
    {
        public Naznach()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Naznach2());
        }

        /// <summary>
        /// Добавить участника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(ID_Student.Text) &&
               !String.IsNullOrEmpty(ID_Semestr.Text) &&
               !String.IsNullOrEmpty(Date_Viplat.Text) &&
               !String.IsNullOrEmpty(Date_Nznacheniya.Text) &&
               !String.IsNullOrEmpty(ID_Vid.Text))
            {
                AddNaz();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        /// <summary>
        /// добавить yновые изменени
        /// </summary>

        private async void AddNaz()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = ConnectionStr.Get;

                //Открываем подключение
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand();

                //Запрос
                command.CommandText = "INSERT INTO Scholarship VALUES ('" + ID_Student.Text
                + "','" + ID_Semestr.Text + "','" + Date_Viplat.Text + "','" + Date_Nznacheniya.Text + "','" + ID_Vid.Text + "')";



                command.Connection = connection;


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

                this.NavigationService.Navigate(new Naznach2());
            }
        }
    }

}

