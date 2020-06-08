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
    /// Логика взаимодействия для StudentsPageInfo.xaml
    /// </summary>
    public partial class StudentsPageInfo : Page
    {
        public StudentsPageInfo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StudentsPage());
        }

        /// <summary>
        /// Добавить участника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(ID_Vid.Text) &&
               !String.IsNullOrEmpty(Name_Scholarship.Text) &&
               !String.IsNullOrEmpty(Razmer.Text) &&
               !String.IsNullOrEmpty(ID_Scholarship.Text) &&
               !String.IsNullOrEmpty(Academic_Year.Text) &&
               !String.IsNullOrEmpty(ID_Semestr.Text))
            {
                AddID();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }

        }
        //2
        /// <summary>
        /// добавить студента
        /// </summary>
        private async void AddID()
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
                    CommandText = "INSERT INTO Vid_Scholarship VALUES('" + ID_Vid.Text
                    + "','" + Name_Scholarship.Text + "','" + Razmer.Text + "','" + ID_Scholarship.Text + "','" + Academic_Year.Text + "','" + ID_Semestr + "')",

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

                this.NavigationService.Navigate(new NewScholarshipPage());
            }
        }

      
    }
}

