using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Jsmvvm.DL.SQLHelper
{
    public class Common
    {
        public const string sqlconn = $"Data Source=VIGNESH\\SQLEXPRESS  ;Initial Catalog=VjHotel  ;Integrated Security=True;Encrypt=False";

        public int ExecuteNonQuery(string query, Dictionary<string, string> sqlparameter)
        {
            int result = 0;
            using (SqlConnection sqlConnection = new SqlConnection(sqlconn))
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                if (sqlparameter != null)
                {
                    foreach (var item in sqlparameter)
                    {
                        sqlCommand.Parameters.AddWithValue (item.Key, item.Value);
                    }
                }
                result = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return result; 
        }
    }
}
