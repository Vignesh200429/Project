using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlquery.DL
{
   public class Common : IDisposable 
    {
        public const string Connectionstring = "Data Source=VIGNESH\\SQLEXPRESS;Initial Catalog=VjHotel;Integrated Security=True;Encrypt=False";
        public Common()
        {
            
        }

        ~Common()
        {

        }

        public void Dispose()
        {

        }
    }
}
