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
using System.Windows.Shapes;

namespace DOU2_Ershov_ED
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(First_name.Text) || string.IsNullOrEmpty(Last_name.Text) || string.IsNullOrEmpty(Phone_number.Text) || string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(Password.Text))
            {
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; Database=Автопарк; Integrated Security=True");
                con.Open();
                string add_data = "INSERT INTO [dbo].[Users] (First_Name, Last_Name, Phone_number, Email, id_status,Password ) VALUES (@First_Name, @Last_Name, @Phone_number, @Email, 1, @Password)";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@First_Name", First_name.Text);
                cmd.Parameters.AddWithValue("@Last_Name", Last_name.Text);
                cmd.Parameters.AddWithValue("@Phone_number", Phone_number.Text);
                cmd.Parameters.AddWithValue("@Email", Email.Text);
                cmd.Parameters.AddWithValue("@Password", Password.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                First_name.Text = "";
                Last_name.Text = "";
                Phone_number.Text = "";
                Email.Text = "";
                Password.Text = "";
                MainWindow mw = new MainWindow();
                this.Close();
                mw.Show();
            }
            catch
            {

            }
        }
    }
}
