using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;

namespace Register
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            ResourceManager lab = new ResourceManager("Register.Properties.Resources", Assembly.GetExecutingAssembly());
            string display = lab.GetString("save");
            MessageBox.Show(display);

            Properties.Settings os = new Properties.Settings();
            RadioButton first = (RadioButton)stlan.Children[0];
            RadioButton second = (RadioButton)stlan.Children[1];
            if (first.IsChecked == true)
            {
                os.Language = first.Tag.ToString();
                os.Save();
            }
            if (second.IsChecked == true)
            {
                os.Language = second.Tag.ToString();
                os.Save();
            }
        }
    }
}
