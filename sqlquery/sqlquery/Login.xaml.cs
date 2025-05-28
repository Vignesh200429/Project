using System.Data;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using Microsoft.Data.SqlClient;
namespace sqlquery
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            SqlConnection sqlConnection = new SqlConnection("Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False");
            sqlConnection.Open();
            string sql = "SELECT * FROM COUNTRY";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataset = new DataSet();
            sqlDataAdapter.Fill(dataset,"COUNTRY");
            cmbcountry.DisplayMemberPath = "COUNTRYNAME";
            cmbcountry.SelectedValuePath = "COUNTRYID";
            cmbcountry.ItemsSource = dataset.Tables["COUNTRY"].DefaultView;
            sqlConnection.Close();
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isinvalidemailid(txtemail.Text) == false)
                {
                    SqlConnection sqlConnection = new SqlConnection("Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False");
                    sqlConnection.Open();
                    string sql = $"Insert into Users1(FullName,Email,PasswordHash,COUNTRYID,STATEID,PID) Values (@username,@email,@password,@country,@state,@city)";
                       
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@username", txtusername .Text);
                    sqlCommand.Parameters.AddWithValue("@email", txtemail .Text);
                    sqlCommand.Parameters.AddWithValue("@password", pwpassword.Password);
                    sqlCommand.Parameters.AddWithValue("@country", cmbcountry.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@state", cmbstate.SelectedValue);
                    sqlCommand.Parameters.AddWithValue("@city", cmbcity.SelectedValue);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                else
                {
                    MessageBox.Show("Already Exsits");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool isinvalidemailid(string email)
        {
            if (email.Contains("@") && email.Contains("."))
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False");
                sqlConnection.Open();
                string sql = $"select count(*) from users1 where email=@email";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@email", email);
                int count = (int) sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private void btnlog_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False");
            sqlConnection.Open();
            //string sql = $"select userid from users1 where fullname='{txtLoginusername.Text}' and PasswordHash='{pwLoginpassword.Password}' ";
            string sql = $"select userid from users1 where fullname=@fullname and PasswordHash=@password ";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@fullname", txtLoginusername.Text);
            sqlCommand.Parameters.AddWithValue("@password", pwLoginpassword .Password);
            int userid = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();
            if(userid > 0)
            {
                NewBilling newBilling = new NewBilling(userid.ToString());
                newBilling.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void cmbcountry_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cmbcountry.SelectedValue != null)
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False");
                sqlConnection.Open();
                string sql = $"Select * From STATE Where COUNTRYID = @country";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@country", cmbcountry.SelectedValue);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataset = new DataSet();
                sqlDataAdapter.Fill(dataset, "STATE");
                cmbstate.DisplayMemberPath = "STATENAME";
                cmbstate.SelectedValuePath = "STATEID";
                cmbstate.ItemsSource = dataset.Tables["STATE"].DefaultView;
                sqlConnection.Close();
            }
        }

        private void cmbstate_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cmbstate.SelectedValue != null)
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False");
                sqlConnection.Open();
                string sql = $"Select * From PLACES Where STATEID = @state";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@state", cmbstate.SelectedValue);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataset = new DataSet();
                sqlDataAdapter.Fill(dataset, "PLACES");
                cmbcity.DisplayMemberPath = "PNAME";
                cmbcity.SelectedValuePath = "PID";
                cmbcity.ItemsSource = dataset.Tables["PLACES"].DefaultView;
                sqlConnection.Close();
            }
        }
    }
}
