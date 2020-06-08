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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();
            GetStudents();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Center.Navigate(new AddNewStudent());
        }



        /// <summary>
        /// Обработчик нажатия правой кнопкой мыши для вызова контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = sender as ListViewItem;

            CurrentStudent.ID = item.Tag.ToString();
        }




        private async void GetStudents()
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
                    CommandText = "SELECT * FROM Students",

                    Connection = connection
                };

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    ListViewItem item = new ListViewItem
                    {
                        Tag = dataReader[0].ToString(),
                        Content = new StudentElement(dataReader[0].ToString(),
                        dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(),
                        dataReader[4].ToString(), dataReader[5].ToString(), dataReader[6].ToString(), dataReader[7].ToString(), dataReader[8].ToString() == "1" ? "Получает" : "Не получает")
                    };
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

        /// <summary>
        /// Редактировать данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UpdateStudent());
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new  Naznach2());
        }
    }
}
