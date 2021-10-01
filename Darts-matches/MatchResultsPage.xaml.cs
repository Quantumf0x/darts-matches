using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class MatchResultsPage : Page, IKeyHandler
    {
        public MatchResultsPage()
        {
            InitializeComponent();
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.Key)
            {
                case Key.Left:
                    ApplicationWindow.Instance.SetFrame(new MatchScoresInputPage());
                    break;
                default:
                    break;
            }
        }
    }
}
