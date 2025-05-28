using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Jsmvvm.DL.SQLHelper;
using Jsmvvm.Model;

namespace Jsmvvm.DL
{
    public class UserDataAccess : Common 
    {
        public int RegisterUser(UserModel user)
        {
            string sql = $"Insert into EMPUSERS1(NAME,AGE,QUALIFICATION,MARK) Values (@name,@age,@qualification,@mark)";
            Dictionary<string, string> sqlparameter = new Dictionary<string, string>();
            sqlparameter.Add("@name", user.Name);
            sqlparameter.Add("@age", user.Age.ToString());
            sqlparameter.Add("@qualification", user.Qualification);
            sqlparameter.Add("@mark", user.Mark.ToString());
            int result = ExecuteNonQuery (sql , sqlparameter);
            return result;
        }
    }
}
