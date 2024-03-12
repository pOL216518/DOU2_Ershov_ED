using System;
using DevExpress.XtraReports.UI;
using DevExpress.Xpf.Printing;
using System.Windows;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Printing;
using System.IO;
using System.Windows.Xps.Packaging;
using OxyPlot.Wpf;

namespace DOU2_Ershov_ED
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            DGridHotels.ItemsSource = AutoparkEntities.GetContext().Users.ToList();
            DGridCars.ItemsSource = AutoparkEntities.GetContext().Cars.ToList();
            DGridAgreement.ItemsSource = AutoparkEntities.GetContext().Agreement.ToList();
        }
        private void CheckUsers_Click(object sender, RoutedEventArgs e)
        {
            border_admin.Visibility = Visibility.Hidden;
            border_user.Visibility = Visibility.Hidden;
            border_pechat.Visibility = Visibility.Hidden;
            border_checkUsers.Visibility = Visibility.Visible;

        }

        private void Pechat_Click(object sender, RoutedEventArgs e)
        {
            
            // Создаем экземпляр вашего заранее созданного отчета XtraReport2
                XtraReport2 report = new XtraReport2();

                // Создаем окно для предварительного просмотра отчета
                DocumentPreviewWindow previewWindow = new DocumentPreviewWindow();

                // Устанавливаем отчет как источник документа для окна предварительного просмотра
                previewWindow.PreviewControl.DocumentSource = report;

                // Показываем окно предварительного просмотра отчета
                previewWindow.ShowDialog();
            
        }
        private void addAdminButton_Click(object sender, RoutedEventArgs e)
        {
            border_user.Visibility = Visibility.Hidden;
            border_checkUsers.Visibility = Visibility.Hidden;
            border_pechat.Visibility = Visibility.Hidden;
            border_admin.Visibility = Visibility.Visible;
        }
        private void myBorder2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }

        }
        private bool IsMaximized = false;

        private void myBorder2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)

            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }

        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            border_admin.Visibility = Visibility.Hidden;
            border_checkUsers.Visibility = Visibility.Hidden;
            border_user.Visibility = Visibility.Visible;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            border_user.Visibility = Visibility.Hidden;
            border_admin.Visibility = Visibility.Hidden;
            border_checkUsers.Visibility = Visibility.Hidden;
            //обновление таблицы
            //SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tour_Base;Integrated Security=True");
            //connection.Open();
            //string cmd = "SELECT * FROM User"; // Из какой таблицы нужен вывод
            //SqlCommand createCommand = new SqlCommand(cmd, connection);
            //createCommand.ExecuteNonQuery();
            //SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            //DataTable dt = new DataTable("User");
            //dataAdp.Fill(dt);
            //DGridHotels.ItemsSource = dt.DefaultView;
            //connection.Close();
        }

        private void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Автопарк;Integrated Security=True");
            connection.Open();
            string cmd = "SELECT * FROM [Users]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("User");
            dataAdp.Fill(dt);
            DGridHotels.ItemsSource = dt.DefaultView;
            connection.Close();


        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void Delete_User(int Id)
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Автопарк;Integrated Security=True");
            string cmd = "DELETE FROM [Users] WHERE Id = @Id";
            SqlCommand deleteCommand = new SqlCommand(cmd, connection);
            deleteCommand.Parameters.AddWithValue("@Id", Id);

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DGridHotels.SelectedItem != null && DGridHotels.SelectedItem is DataRowView)
            {
                DataRowView row = (DataRowView)DGridHotels.SelectedItem;
                int userId = Convert.ToInt32(row["Id"]);
                Delete_User(userId);
            }
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            this.Close();
            mw.Show();

        }

       
    }
}
