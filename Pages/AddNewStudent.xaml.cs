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
    /// Логика взаимодействия для AddNewStudent.xaml
    /// </summary>
    public partial class AddNewStudent : Page
    {
        public AddNewStudent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StudentPage());
        }
        //xfg
        /// <summary>
        /// Добавить участника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(LastName.Text)&&
               !String.IsNullOrWhiteSpace(FirstName.Text) &&
               !String.IsNullOrWhiteSpace(Patronom.Text) &&
               !String.IsNullOrWhiteSpace(Serial.Text) &&
               !String.IsNullOrWhiteSpace(NumberPass.Text) &&
               !String.IsNullOrWhiteSpace(Card.Text) &&
               !String.IsNullOrWhiteSpace(Balance.Text) &&
               !String.IsNullOrWhiteSpace(StatusS.Text))
            {
                AddStudent();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        /// <summary>
        /// добавить студента
        /// </summary>
        private async void AddStudent()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = ConnectionStr.Get;

                //Открываем подключение
                await connection.OpenAsync();

                ComboBoxItem item = new ComboBoxItem();
                item = (ComboBoxItem)StatusS.SelectedItem;


                SqlCommand command = new SqlCommand
                {

                    //Запрос
                    CommandText = "INSERT INTO Students VALUES((SELECT MAX(ID_Student) FROM Students) + 1, '" + LastName.Text
                    + "','" + FirstName.Text + "','" + Patronom.Text + "','" + Serial.Text + "','" + NumberPass.Text + "','" + Card.Text + "','" + Balance.Text + "',"+item.Tag+")",

                    Connection = connection
                };

                command.ExecuteNonQuery();
            }
            //jj
            catch (SqlException ex)
            {
                connection.Close();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //В любом случае закрываем подключение
                connection.Close();

                this.NavigationService.Navigate(new StudentPage());
            }
        
        
        
        }

    }
}
