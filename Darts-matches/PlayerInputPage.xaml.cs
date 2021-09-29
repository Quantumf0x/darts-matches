using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class PlayerInputPage : Page
    {
        public PlayerInputPage()
        {
            InitializeComponent();
        }
        private void MatchScoresInputPage(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new MatchScoresInputPage());
        }

        private void PlayerInputGridOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            PlayerInputGrid.Focus();
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArguments)
        {
            if (keyEventArguments.Key == Key.Left)
            {
                ApplicationWindow.Instance.SetFrame(new MatchInputPage());
            }
            if (keyEventArguments.Key == Key.Right)
            {
                ApplicationWindow.Instance.SetFrame(new MatchScoresInputPage());
            }
        }
    }
}
