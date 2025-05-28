using System.Data;
using Microsoft.Data.SqlClient;

namespace sqlquery.DL
{
    public class SqlDataAccess
    {
        public int ExecuteData(string sql, Dictionary<string, string> sqlparameter)
        {
            int result = 0;
            SqlConnection sqlConnection = new SqlConnection(Common.Connectionstring);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                foreach (KeyValuePair<string, string> param in sqlparameter)
                {
                    sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                }
                result = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = -2;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;
        }

        public object GetSingleRecord(string sql, Dictionary<string, string> sqlparameters)
        {
            object result = null;
            SqlConnection sqlConnection = new SqlConnection(Common.Connectionstring);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                foreach (KeyValuePair<string, string> param in sqlparameters)
                {
                    sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                }
                result = sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                result = -2;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;
        }

        public Dictionary<string, string> GetSingleRow(string sql, Dictionary<string, string> sqlparameter)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            SqlConnection sqlConnection = new SqlConnection(Common.Connectionstring);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                if (sqlparameter != null)
                {
                    foreach (KeyValuePair<string, string> param in sqlparameter)
                    {
                        sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                    }

                }
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    foreach (var item in reader)
                    {
                        result.Add(reader.GetName(0), reader[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                result = null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return result;
        }

        public DataSet GetDataSet(string sql, Dictionary<string, string> sqlparameter)
        {
            DataSet dataset = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(Common.Connectionstring);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                if (sqlparameter != null)
                {
                    foreach (KeyValuePair<string, string> param in sqlparameter)
                    {
                        sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                    }

                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.Fill(dataset);

            }
            catch (Exception ex)
            {
                dataset = null;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataset;
        }
    }
}
