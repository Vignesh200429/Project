using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlquery.Model
{
    public class Users
    {
        private string _fullname;
        public string FullName
        {
            get { return _fullname; }
            set { _fullname = value; }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _countryid;
        public int CountryId
        {
            get { return _countryid; }
            set { _countryid = value; }
        }

        private int _stateid;
        public int StateId
        {
            get { return _stateid; }
            set { _stateid = value; }
        }

        private int _cityid;
        public int CityId
        {
            get { return _cityid; }
            set { _cityid = value; }
        }


    }
}
