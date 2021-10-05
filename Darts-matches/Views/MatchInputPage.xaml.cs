using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class MatchInputPage : Page, IKeyHandler
    {
        public MatchInputPage()
        {
            InitializeComponent();
        }

        private void PlayerInputPage(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.Key)
            {
                case Key.Left:
                    ApplicationWindow.Instance.SetFrame(new MainMenuPage());
                    break;
                case Key.Right:
                    ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
                    break;
                default:
                    break;
            }
        }
    }
}
