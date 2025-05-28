using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jsmvvm.Model.Helper;

namespace Jsmvvm.Model
{
    public class UserModel : NotifyProperty 
    {
        

            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; OnPropertyChanged(); }
            }

            private int _age;

            public int Age
            {
                get { return _age; }
                set { _age = value; OnPropertyChanged(); }
            }

            private string _qualification;

            public string Qualification
            {
                get { return _qualification; }
                set { _qualification = value; OnPropertyChanged(); }
            }

            private int _mark;

            public int Mark
            {
                get { return _mark; }
                set { _mark = value; OnPropertyChanged(); }
            }

        private string _experence;

        public string Experence
        {
            get { return _experence; }
            set { _experence = value;  }
        }

        public enum Exp
        {
            Yes,
            No
        }

    }

    public class UserData
    {


        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; ; }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value;  }
        }

        private string _qualification;

        public string Qualification
        {
            get { return _qualification; }
            set { _qualification = value;  }
        }

        private int _mark;

        public int Mark
        {
            get { return _mark; }
            set { _mark = value;  }
        }

    }
}

