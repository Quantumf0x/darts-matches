using Darts_matches.Controllers;
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
            DatabaseController databaseController = DatabaseController.GetInstance();
            databaseController.TestConnection();
            databaseController.KillInstance();
        }

        private void OpenDartMatchInputPage(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new MatchInputPage());
        }

        private void OpenMatchOverviewPage(object sender, RoutedEventArgs eventArguments)
        {
            MatchOverviewPage matchOverviewPage = new MatchOverviewPage();
            matchOverviewPage.SetPreviousContext(this);
            ApplicationWindow.Instance.SetFrame(matchOverviewPage);
        }

        private void OpenHelpPage(object sender, RoutedEventArgs eventArguments)
        {
            HelpPage helpPage = new HelpPage();
            helpPage.SetPreviousContext(this);
            ApplicationWindow.Instance.SetFrame(helpPage);
        }
    }
}
