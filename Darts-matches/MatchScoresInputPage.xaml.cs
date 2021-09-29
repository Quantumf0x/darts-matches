using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class MatchScoresInputPage : Page
    {
        public MatchScoresInputPage()
        {
            InitializeComponent();
        }
        private void MatchResultsPage(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new MatchResultsPage());
        }

        private void MatchScoresInputGridOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            MatchScoresInputGrid.Focus();
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArguments)
        {
            if (keyEventArguments.Key == Key.Left)
            {
                ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
            }
            if (keyEventArguments.Key == Key.Right)
            {
                ApplicationWindow.Instance.SetFrame(new MatchResultsPage());
            }
        }
    }
}
