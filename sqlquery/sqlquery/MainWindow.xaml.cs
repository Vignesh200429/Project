using System.Windows;
using Microsoft.Data.SqlClient;
namespace sqlquery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string value = Properties.Settings.Default.Conn;
            if (!string.IsNullOrWhiteSpace(value))
            {
                Login login = new Login();
                this.Close();
                login.Show();
            }
        }

        private void btnconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string value = Properties.Settings.Default.Conn;
                if (string.IsNullOrWhiteSpace(value))
                { 
                    string conn = $"Data Source={txtserver.Text};Initial Catalog={txtdatabase.Text};Integrated Security=True;Encrypt=False";
                    SqlConnection sqlconnection = new SqlConnection(conn);
                    sqlconnection.Open();
                    if (sqlconnection.State == System.Data.ConnectionState.Open)
                    {
                        Properties.Settings.Default.Conn = conn;
                        Properties.Settings.Default.Save();
                    }
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}