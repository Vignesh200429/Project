using System.Data;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using Microsoft.Data.SqlClient;
using sqlquery.Model;
using Business = sqlquery.Business;
using sqlquery.BL;
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
            LoginBusinessLogic login = new LoginBusinessLogic();
            cmbcountry.DisplayMemberPath = "COUNTRYNAME";
            cmbcountry.SelectedValuePath = "COUNTRYID";
            cmbcountry.ItemsSource = login.getcountry().Tables[0].DefaultView;
            
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.FullName = txtusername.Text;
            users.Email = txtemail.Text;
            users.Password = pwpassword.Password;
            users.CountryId = Convert.ToInt32 (cmbcountry.SelectedValue);
            users.StateId = Convert.ToInt32 (cmbstate.SelectedValue);
            users.CityId = Convert.ToInt32 (cmbcity.SelectedValue);
            LoginBusinessLogic login = new LoginBusinessLogic();
            bool value = login.RegisterUser(users);
            if(value )
            {
                MessageBox.Show("Register Successfull");
            }
            else
            {
                MessageBox.Show("Register UnSuccessfull");
            }
        }

        public bool isinvalidemailid(string email)
        {
            if (email.Contains("@") && email.Contains("."))
            {
                SqlConnection sqlConnection = new SqlConnection();
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
            if(string.IsNullOrEmpty(txtLoginusername.Text ) || string.IsNullOrEmpty(pwLoginpassword.Password ))
            {
                MessageBox.Show("Please Enter username and Password");
            }
            else
            {
                LoginBusinessLogic login = new LoginBusinessLogic();
                int output = login.LoginCheck(txtLoginusername.Text, pwLoginpassword.Password);
                if(output > 0)
                {
                    MessageBox.Show("Login Sucess");
                }
                else
                {
                    MessageBox.Show("Invalid Username and Password");
                }
            }
        }

        private void cmbcountry_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cmbcountry.SelectedValue != null)
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.Open();
                    string sql = $"Select * From STATE Where COUNTRYID = @country";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
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
            }
        }

        private void cmbstate_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cmbstate.SelectedValue != null)
            {
                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    sqlConnection.Open();
                    string sql = $"Select * From PLACES Where STATEID = @state";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
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
    }
}
