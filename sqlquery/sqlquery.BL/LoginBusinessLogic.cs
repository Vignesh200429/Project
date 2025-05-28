using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sqlquery.DL;
using Microsoft.Data.SqlClient;
using sqlquery.Model;

namespace sqlquery.BL
{
    public  class LoginBusinessLogic
    {
        public bool RegisterUser(Users users)
        {
            string sql = $"Insert into Users1(FullName,Email,PasswordHash,cid,sid,cityid) Values (@username,@email,@password,@country,@state,@city)";
            Dictionary<string, string> sqlparameters = new Dictionary<string, string>();
            sqlparameters.Add("@username", users.FullName);
            sqlparameters.Add("@email", users.Email);
            sqlparameters.Add("@password", users.Password);
            sqlparameters.Add("@country", users.CountryId.ToString());
            sqlparameters.Add("@state", users.StateId.ToString());
            sqlparameters.Add("@city", users.CityId.ToString());
            SqlDataAccess  sqlHelper = new SqlDataAccess();


            int result = sqlHelper.ExecuteData(sql, sqlparameters);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int LoginCheck(string username, string password)
        {
            string sql = $"select userid from users1 where fullname=@fullname and PasswordHash=@password ";
            Dictionary<string, string> sqlparameters = new Dictionary<string, string>();
            sqlparameters.Add("@fullname", username);
            sqlparameters.Add("@password", password);
            SqlDataAccess sqlHelper = new SqlDataAccess();

            int result = (int)sqlHelper.GetSingleRecord(sql, sqlparameters);
            return result;

        }

        public DataSet getcountry()
        {
            string sql = "SELECT * FROM COUNTRY";
            SqlDataAccess sqlHelper = new SqlDataAccess();

            DataSet ds = sqlHelper.GetDataSet(sql, null);
            return ds;
        }

        public bool isvalidemail(string email)
        {
            string sql = $"select count(*) from users1 where email=@email";
            SqlDataAccess sqlHelper = new SqlDataAccess();

            Dictionary<string, string> sqlparameter = new Dictionary<string, string>();
            sqlparameter.Add("email", email);
            int count = (int)sqlHelper.GetSingleRecord(sql, sqlparameter);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
