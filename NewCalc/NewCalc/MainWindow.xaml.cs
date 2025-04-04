using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewCalc.Model;

namespace NewCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string oper = "";
        string firstvalue = "";
        string secondvalue = "";
        MathOperation mathOperation;

        public MainWindow()
        {
            InitializeComponent();
            mathOperation = new MathOperation();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button btnnumber = (Button)sender;
            Numbers(btnnumber.Content.ToString());
            
        }

        public bool Numbers(object number)
        {
            if (oper == "")
            {
                firstvalue = firstvalue + number.ToString();
                txtresult.Text = firstvalue;
            }
            else
            {
                secondvalue = secondvalue + number.ToString();
                txtresult.Text = secondvalue;
            }
            return true;
        }


        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            firstvalue = "";
            secondvalue = "";
            oper = "";
            txtresult.Text = "";
        }

       

        private void Oper_Click(object sender, RoutedEventArgs e)
        {
            Button btnoper = (Button)sender;
            oper = btnoper.Content.ToString();
        }

        private void btneql_Click(object sender, RoutedEventArgs e)
        {
            Button btnnumber = (Button)sender;
            mathOperation.Add(firstvalue,secondvalue);
            int result = 0;

            switch (oper)
            {
                case "+":
                    result = mathOperation.Addnumbers(firstvalue , secondvalue);
                    break;
                case "-":
                    result = mathOperation.Subnumbers(firstvalue, secondvalue);
                    break;
                case "*":
                    result = mathOperation.Mulnumbers(firstvalue, secondvalue);
                    break;
                case "/":
                    result = mathOperation.Divnumbers(firstvalue, secondvalue);
                    break;
            }
            txtresult.Text = result.ToString();
        }
    }
}