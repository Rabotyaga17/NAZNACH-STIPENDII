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
//ы
namespace Otdelenie.Pages
{
    /// <summary>
    /// Логика взаимодействия для MessagesssPage.xaml
    /// </summary>
    public partial class MessagesssPage : Page
    {
        public MessagesssPage()
        {
            InitializeComponent();
            CheckSumm();
        }

        public bool CheckSumm()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = ConnectionStr.Get;

                //Открываем подключение
                connection.Open();

                SqlCommand command = new SqlCommand
                {

                    //Запрос
                    CommandText = "SELECT Balance FROM Students WHERE ID_Student = " + User.ID,

                    Connection = connection
                };

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Money.Content = dataReader[0].ToString();
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

            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Summa.Text))
            {
                if (Convert.ToDouble(Summa.Text) > Convert.ToDouble(Money.Content))
                    MessageBox.Show("Баланс не сообветствует введенной сумме", "ОШИБКА");
                else
                {
                    SqlConnection connection = new SqlConnection();

                    double res = 0;

                    try
                    {
                        connection.ConnectionString = ConnectionStr.Get;

                        //Открываем подключение
                        connection.Open();

                        SqlCommand command = new SqlCommand();

                        res = Convert.ToDouble(Money.Content) - Convert.ToDouble(Summa.Text);

                        //Запрос
                        command.CommandText = "UPDATE Students SET Balance = " + res + " WHERE ID_Student = " + User.ID;

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

                        MessageBox.Show("Вы получили свою стипендию", "НАЗНАЧЕНИЕ СТИПЕНДИИ");

                        CurrentCheque.Get = Summa.Text;
                        CurrentCheque.Balance = Money.Content.ToString();
                        CurrentCheque.Ostatok = res.ToString();

                        this.NavigationService.Navigate(new ChequePage());
                    }
                }
            }
        }

        private void Summa_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
