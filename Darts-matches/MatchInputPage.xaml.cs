using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class MatchInputPage : Page
    {
        public MatchInputPage()
        {
            InitializeComponent();
        }

        private void PlayerInputPage(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
        }

        private void MatchInputGridOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            MatchInputGrid.Focus();
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArguments)
        {
            if (keyEventArguments.Key == Key.Left)
            {
                ApplicationWindow.Instance.SetFrame(new MainMenuPage());
            }
            if (keyEventArguments.Key == Key.Right)
            {
                ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
            }
        }
    }
}
