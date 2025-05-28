using System.Data;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;

namespace sqlquery
{
    /// <summary>
    /// Interaction logic for NewBilling.xaml
    /// </summary>
    public partial class NewBilling : Window
    {
        string useridvalue;
        int caid = 0;
        decimal total;
        public NewBilling(string userid)
        {
            InitializeComponent();
            useridvalue = userid;
            SqlConnection sqlConnection = new SqlConnection("Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False");
            sqlConnection.Open();
            string sql = "SELECT * FROM Products";
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataset = new DataSet();
            sqlDataAdapter.Fill(dataset, "Products");
            cmbproducts.DisplayMemberPath = "ProductName";
            cmbproducts.SelectedValuePath = "ProductId";
            cmbproducts.ItemsSource = dataset.Tables["Products"].DefaultView;
            sqlConnection.Close();
        }

        private void cmbproducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbproducts.SelectedValue != null)
            {
                SqlConnection sqlConnection = new SqlConnection("Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False");
                sqlConnection.Open();
                string sql = $"select stockquantity,price from products where productid=@products";
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@products", cmbproducts.SelectedValue);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if(sqlDataReader.HasRows )
                {
                    if(sqlDataReader.Read ())
                    {
                        txtprice.Text = sqlDataReader["Price"].ToString();
                        txtunit.Text = sqlDataReader["StockQuantity"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Data not found");
                }
                sqlConnection.Close();
            }
        }

        private void btnaddtobill_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("USP_ADDITEM", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@USERID", useridvalue);
            sqlCommand.Parameters.AddWithValue("@PRODUCTID", cmbproducts.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@QUANTITY", txtquantity.Text);
            sqlCommand.Parameters.AddWithValue("@CAID", caid);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataset = new DataSet();
            sqlDataAdapter.Fill(dataset, "Products");
            caid = Convert.ToInt32(dataset.Tables["Products"].Rows[0]["CartId"]);
            dggrid.ItemsSource = dataset.Tables["Products"].DefaultView;
            int totalrow = dataset.Tables["Products"].Rows.Count-1;
            total += Convert.ToDecimal(dataset.Tables["Products"].Rows[totalrow]["Total"].ToString());
            txttotal.Text = total.ToString();
            sqlConnection.Close();
        }

        //private void btnaddtobill_Click(object sender, RoutedEventArgs e)
        //{
        //    SqlConnection sqlConnection = new SqlConnection("Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False");
        //    sqlConnection.Open();
        //    string sql = $"EXEC USP_ADDITEM {useridvalue},{cmbproducts.SelectedValue} , {txtquantity.Text},{caid}";
        //    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //    DataSet dataset = new DataSet();
        //    sqlDataAdapter.Fill(dataset, "Products");
        //    caid = sqlCommand.ExecuteScalar() as int?;
        //    dggrid.ItemsSource  = dataset.Tables["Products"].DefaultView;
        //    sqlConnection.Close();
        //}
    }
}
