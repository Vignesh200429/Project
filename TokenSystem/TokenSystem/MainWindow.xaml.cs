using System.Collections;
using System.Windows;

namespace TokenSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Using Queue Collections 
        Queue queue = new Queue();
        public MainWindow()
        {
            InitializeComponent();
        }

        //Save data using Save button
        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtname.Text.Trim();
            queue.Enqueue(name);
        }

        //call data using Call Button
        private void btncall_Click(object sender, RoutedEventArgs e)
        {
            string CallNamed = queue.Dequeue().ToString();
            MessageBox.Show(CallNamed);
        }

        //Clear data from Textbox
        private void btnclear_Click(object sender, RoutedEventArgs e)
        {
            txtname.Text = " ";
        }
    }
}