using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class MatchScoresInputPage : Page, IKeyHandler
    {
        public MatchScoresInputPage()
        {
            InitializeComponent();
        }
        private void MatchResultsPage(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new MatchResultsPage());
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.Key)
            {
                case Key.Left:
                    ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
                    break;
                case Key.Right:
                    ApplicationWindow.Instance.SetFrame(new MatchResultsPage());
                    break;
                default:
                    break;
            }
        }
    }
}
