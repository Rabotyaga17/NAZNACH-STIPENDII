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
    /// Логика взаимодействия для UpdateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : Page
    {
        public UpdateStudent()
        {
            InitializeComponent();
            GetStudent();
        }

        private async void GetStudent()
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
                    CommandText = "SELECT * FROM Students WHERE ID_Student = " + CurrentStudent.ID,

                    Connection = connection
                };

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    LastName.Text = dataReader[1].ToString();
                    FirstName.Text = dataReader[2].ToString();
                    Patronom.Text = dataReader[3].ToString();
                    Serial.Text = dataReader[4].ToString();
                    NumberPass.Text = dataReader[5].ToString(); 
                    Card.Text = dataReader[6].ToString();
                    Balance.Text = dataReader[7].ToString();
                    StatusS.SelectedIndex = Convert.ToInt32(dataReader[8]);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StudentPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (!String.IsNullOrWhiteSpace(LastName.Text) &&
              !String.IsNullOrWhiteSpace(FirstName.Text) &&
              !String.IsNullOrWhiteSpace(Patronom.Text) &&
              !String.IsNullOrWhiteSpace(Serial.Text) &&
              !String.IsNullOrWhiteSpace(NumberPass.Text) &&
              !String.IsNullOrWhiteSpace(Card.Text) &&
              !String.IsNullOrWhiteSpace(Balance.Text) &&
              !String.IsNullOrWhiteSpace(StatusS.Text)
              )
            {
                SaveChang();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }

        }

        private async void SaveChang()
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
                    CommandText = "UPDATE Students SET Second_Name = '" + LastName.Text +
                    "', [Name] = '" + FirstName.Text + "', Last_Name = '" + Patronom.Text +
                    "', Series_Passport = '" + Serial.Text + "', ID_Passport = '" + NumberPass.Text + "', ID_Card = '" + Card.Text + "', Balance = '" + Balance.Text + "', Status_Stipendii = " + item.Tag+" WHERE ID_Student = " + CurrentStudent.ID,

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

                this.NavigationService.Navigate(new StudentPage());
            }
        }
    }
}
