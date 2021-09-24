using System.Windows;
using System.Windows.Controls;

namespace Darts_matches
{
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void OpenDartMatchInputPage(object sender, RoutedEventArgs eventArguments)
        {
            MainWindow.Instance.SetFrame(new MatchInputPage());
        }

        private void OpenMatchOverviewPage(object sender, RoutedEventArgs eventArguments)
        {
            MainWindow.Instance.SetFrame(new MatchOverviewPage());
        }

        private void OpenHelpPage(object sender, RoutedEventArgs eventArguments)
        {
            MainWindow.Instance.SetFrame(new HelpPage());
        }
    }
}
