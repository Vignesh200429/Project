using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewCalc.Model
{
    public class MathOperation
    {
         /// <summary>
         /// used for checking nullorwhitespace and also call the method IsNumeric
         /// </summary>
         /// <param name="a"></param>
         /// <param name="b"></param>
         /// <returns></returns>         
        public int Add(string a, string b)
        {
            if(string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace (b))
            {
                return 0;
            }
            if(!IsNumeric (a) || !IsNumeric (b))
            {
                return 0;
            }
            return 0;
        }


        /// <summary>
        ///  Used for Add Two Numbers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Addnumbers<T>(T a, T b)
        {
            
            return Convert.ToInt32(a) + Convert.ToInt32(b);
            
            
        }
        /// <summary>
        /// Used for Sub Two Numbers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Subnumbers<T>(T a, T b)
        {

            return Convert.ToInt32(a) - Convert.ToInt32(b);

        }
        /// <summary>
        /// Used for Mul Two Numbers
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Mulnumbers<T>(T a, T b)
        {

            return Convert.ToInt32(a) * Convert.ToInt32(b);

        }
        /// <summary>
        /// Used for Div Two Numbers
        /// </summary>
        /// <typeparam name="T"> Accept any type</typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Divnumbers<T>(T a, T b)
        {

            return Convert.ToInt32(a) / Convert.ToInt32(b);

        }
        /// <summary>
        /// Used for Checking Digit or Letter or Both
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
