using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using Register.Properties;

namespace Register
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Settings os = new Settings();
            CultureInfo cultureinfo = CultureInfo.GetCultureInfo(os.Language);
            Thread.CurrentThread.CurrentUICulture = cultureinfo;
        }
    }

}
