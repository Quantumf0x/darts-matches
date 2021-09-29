using System.Windows;

namespace Darts_matches
{
    public partial class App : Application
    {
        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            Window applicationWindow = Darts_matches.ApplicationWindow.Instance;
            applicationWindow.Show();
        }
    }
}
