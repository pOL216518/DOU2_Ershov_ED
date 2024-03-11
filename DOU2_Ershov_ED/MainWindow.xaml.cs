using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace DOU2_Ershov_ED
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Автопарк;Integrated Security=True";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Registr_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var reg = new Registr();
            reg.Show();
            this.Close();

        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Error_message.Text = "Please enter both username and password.";
                return;
            }

            if (ValidateUser(email, password))
            {
                // Получаем id_status пользователя
                int userStatus = GetUserStatus(email);

                Error_message.Text = "Login successful!";
                if (userStatus == 1)
                {
                    // Перенаправить пользователя на окно Client
                    Client clientWindow = new Client();
                    clientWindow.Show();
                }
                else if (userStatus == 2)
                {
                    // Перенаправить пользователя на окно Admin
                    Admin adminWindow = new Admin();
                    adminWindow.Show();
                }

                // Закрыть текущее окно
                this.Close();
            }
            else
            {
                Error_message.Text = "Invalid username or password.";
            }
        }

        private bool ValidateUser(string email, string password)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
            int count = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    count = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while connecting to the database: " + ex.Message);
                }
            }

            return count > 0;
        }

        private int GetUserStatus(string email)
        {
            string query = "SELECT id_status FROM Users WHERE Email = @Email";
            int idStatus = -1; // По умолчанию устанавливаем значение -1, чтобы указать, что пользователь не найден.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        idStatus = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while connecting to the database: " + ex.Message);
                }
            }

            return idStatus;
        }
    }
   

}
