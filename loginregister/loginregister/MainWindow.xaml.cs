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

namespace loginregister
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> liststudent;
        Student student;
        Register register;
        public MainWindow()
        {
            InitializeComponent();
            liststudent = new List<Student>();
            student = new Student();
            register = new Register();
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            string studentfile = register.GetStudentPath();
            liststudent = register.GetStudent(studentfile);
            student.Sname = txtusername.Text;
            student.Spassword = pwpassword.Password;
            student.SCpassword = pwconformpassword.Password;
            student.Semail = txtemail.Text;
            student.Sphone = txtphonenumber.Text;
            liststudent.Add(student);
            register.SaveStudent(liststudent , studentfile);
        }

        private void btnlog_Click(object sender, RoutedEventArgs e)
        {
            string studentfile = register.GetStudentPath();
            liststudent = register.GetStudent(studentfile);
            bool isvalid = false;
            foreach(Student student in liststudent)
            {
                if(student.Sname == txtloginusername .Text && student.Spassword == pwloginpassword .Password )
                {
                    MessageBox.Show("Login Successfully");
                    isvalid = true;
                    break;
                }
            }
            if(!isvalid)
            {
                MessageBox.Show("Invalid");
            }
        }
    }
}