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
using System.Data.SqlClient;

namespace Otdelenie.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            Captcha.Content = CaptchaBuild.Refresh();
        }

        private void RefreshCaptcha_Click(object sender, RoutedEventArgs e)
        {
            Captcha.Content = CaptchaBuild.Refresh();
            CaptchaText.Text = "";
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //Возвращаем исходный контур
            LoginBox.BorderBrush = Brushes.SlateGray;
            PasswordBox.BorderBrush = Brushes.SlateGray;
            CaptchaText.BorderBrush = Brushes.SlateGray;


            //Проверяем на заполненность логин и пароль
            if (!String.IsNullOrEmpty(LoginBox.Text) && !String.IsNullOrEmpty(PasswordBox.Password))
            {
                //Проверяем капчу
                if (Captcha.Content.ToString() == CaptchaText.Text.ToUpper())
                {
                    CheckUser();
                }
                else
                {
                    CaptchaText.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                //Красим логин и пароль в красный
                LoginBox.BorderBrush = Brushes.Red;
                PasswordBox.BorderBrush = Brushes.Red;
            }

            //Рефрешим капчу
            Captcha.Content = CaptchaBuild.Refresh();
            CaptchaText.Text = "";
        }

        private async void GetStudInfo()
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
                    CommandText = "SELECT Second_Name, [Name], Last_Name, ID_Card, Status_Stipendii FROM Students WHERE ID_Student = " + User.ID,

                    Connection = connection
                };

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    CurrentStudent.LastName = dataReader[0].ToString();
                    CurrentStudent.FirstName = dataReader[1].ToString();
                    CurrentStudent.Patronom = dataReader[2].ToString();
                    CurrentStudent.CardID = dataReader[3].ToString();
                    CurrentStudent.SStatus = dataReader[4].ToString();
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

        private async void CheckUser()
        {
            //Убираем вывод ошибки
            Error.Content = "";

            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = ConnectionStr.Get;

                //Открываем подключение
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand
                {

                    //Запрос
                    CommandText = "SELECT * FROM [User] WHERE [Login] = '" + LoginBox.Text + "' AND [Password] = '" + PasswordBox.Password + "'",

                    Connection = connection
                };

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    User.Login = dataReader[0].ToString();
                    User.Password = dataReader[1].ToString();
                    User.RoleID = dataReader[2].ToString();
                    User.ID = dataReader[3].ToString();
                }

                //Если пользователь существует
                if (!String.IsNullOrEmpty(User.Login) && !String.IsNullOrEmpty(User.Password))
                {
                    switch (User.RoleID)
                    {
                        //Студент
                        case "2":
                            this.NavigationService.Navigate(new NewScholarshipPage());
                            ((MainWindow)System.Windows.Application.Current.MainWindow).LeftBar.Navigate(new StudentBar());
                            GetStudInfo();
                            break;

                        //Pуководство
                        case "1":
                            this.NavigationService.Navigate(new DirectorPage());
                            ((MainWindow)System.Windows.Application.Current.MainWindow).LeftBar.Navigate(new DirectorBar());
                            break;
                    }
                }
                else
                {
                    LoginBox.BorderBrush = Brushes.Red;
                    PasswordBox.BorderBrush = Brushes.Red;
                    Error.Content = "Неправильная комбинация логин-пароль";
                }
            }
            catch (SqlException ex)
            {
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
