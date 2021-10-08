using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();

            DatabaseController dbc = DatabaseController.GetInstance();
            dbc.PullFromDatabase();
        }

        private void OpenDartMatchInputPage(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new MatchInputPage());
        }

        private void OpenMatchOverviewPage(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new MatchOverviewPage());
        }

        private void OpenHelpPage(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new HelpPage());
        }
    }
}
