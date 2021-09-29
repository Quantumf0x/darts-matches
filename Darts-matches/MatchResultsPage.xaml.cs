using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class MatchResultsPage : Page
    {
        public MatchResultsPage()
        {
            InitializeComponent();
        }

        private void MatchResultsGridOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            MatchResultsGrid.Focus();
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArguments)
        {
            if (keyEventArguments.Key == Key.Left)
            {
                ApplicationWindow.Instance.SetFrame(new MatchScoresInputPage());
            }
        }
    }
}
