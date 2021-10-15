using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Darts_matches.Controllers;

namespace Darts_matches
{
    public partial class MatchScoresInputPage : Page, IKeyHandler
    {
        private Models.Match _match;
        private Models.Player _selectedPlayer;

        public MatchScoresInputPage()
        {
            InitializeComponent();

            _match = MatchController.Instance.GetMatch();
            lbl_name_player1.Text = _match.PlayerOne.Name;
            lbl_name_player2.Text = _match.PlayerTwo.Name;

            //Selected Player is always selected first.
            _selectedPlayer = _match.PlayerOne;
            lbl_name_player1.Background = Brushes.LightBlue;
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
                case Key.Right:
                    ChangePlayer();
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

        private void ChangePlayer()
        {
            if (_match.PlayerOne.Equals(_selectedPlayer))
            {
                _selectedPlayer = _match.PlayerTwo;

                lbl_name_player1.Background = Brushes.Transparent;
                lbl_name_player2.Background = Brushes.Blue;
            }
            else if (_match.PlayerTwo.Equals(_selectedPlayer))
            {
                _selectedPlayer = _match.PlayerOne;

                lbl_name_player1.Background = Brushes.Blue;
                lbl_name_player2.Background = Brushes.Transparent;
            }
        }
    }
}
