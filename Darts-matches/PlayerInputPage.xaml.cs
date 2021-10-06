using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class PlayerInputPage : Page, IKeyHandler
    {
        public PlayerInputPage()
        {
            InitializeComponent();
        }

        private void btn_next_Click(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new MatchScoresInputPage());
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.Key)
            {
                case Key.Left:
                    ApplicationWindow.Instance.SetFrame(new MatchInputPage());
                    break;
                case Key.Right:
                    ApplicationWindow.Instance.SetFrame(new MatchScoresInputPage());
                    break;
                default:
                    break;
            }
        }

        private void btn_main_Click(object sender, RoutedEventArgs e)
        {
            ApplicationWindow.Instance.SetFrame(new MainMenuPage());
        }

        private void btn_help_Click(object sender, RoutedEventArgs e)
        {
            ApplicationWindow.Instance.SetFrame(new HelpPage());
        }
    }
}
