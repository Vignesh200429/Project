using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using Jsmvvm.DL;
using Jsmvvm.Model;
using Jsmvvm.ViewModel.JsmvvmHelper;

namespace Jsmvvm.ViewModel
{

    
    public class UserViewModel
    {

        public RealyCommend RegisterCommend { get; set; }

        public RealyCommend ClearCommend { get; set; }


        private UserModel _usermodel;

        
        public UserModel UserModelData
        {
            get { return _usermodel; }
            set { _usermodel = value; }
        }

        public ObservableCollection<UserData> UserList { get; set; }

        public UserViewModel() 
        {
           if(UserModelData == null)
            {
                UserModelData = new UserModel();
            }
            if (UserList == null)
            {
                UserList =new  ObservableCollection<UserData>();
            }
            UserModelData = new UserModel();
            UserModelData.Name = "Vicky";
            UserModelData.Age = 21;
            UserModelData.Qualification = "BE";
            UserModelData.Mark = 99;
            UserModelData.Experence = "Yes";
            RegisterCommend = new RealyCommend(Register);
            ClearCommend = new RealyCommend(ClearData);
        }

        public void Register()
        {
            UserData val = new UserData()
            {
                Name = UserModelData.Name,
                Age = UserModelData.Age,
                Qualification = UserModelData.Qualification,
                Mark = UserModelData.Mark,
            };
            UserList.Add(val);
            
            UserDataAccess userDataAccess = new UserDataAccess();
            int value = userDataAccess.RegisterUser(UserModelData);
        }

        public void ClearData()
        {
            UserModelData.Name = string.Empty;
            UserModelData.Age = 0;
            UserModelData.Qualification = string.Empty;
            UserModelData.Mark = 0;
        }

    }
}
