using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Darts_matches.Controllers;
using Darts_matches.Models;

namespace Darts_matches
{
    public partial class MatchScoresInputPage : Page, IKeyHandler
    {
        #region [Fields]: UI
        private static readonly Brush _selectedPlayerBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0078D7"));
        #endregion

        #region [Fields]: Models
        private Match _match;
        private Player _selectedPlayer;
        #endregion



        #region [Constructors]
        public MatchScoresInputPage()
        {
            InitializeComponent();

            _match = MatchController.Instance.GetMatch();
            lbl_name_player1.Text = _match.PlayerOne.Name;
            lbl_name_player2.Text = _match.PlayerTwo.Name;

            _selectedPlayer = _match.PlayerOne;
            lbl_name_player1.Background = _selectedPlayerBrush;

            playerTwoColumn.Background.Opacity = 0.5;
        }
        #endregion


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
                    break;
                case Key.Tab:
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
                lbl_name_player2.Background = _selectedPlayerBrush;

                playerOneColumn.Background.Opacity = 1.0;
                playerTwoColumn.Background.Opacity = 0.5;
            }
            else if (_match.PlayerTwo.Equals(_selectedPlayer))
            {
                _selectedPlayer = _match.PlayerOne;

                lbl_name_player1.Background = _selectedPlayerBrush;
                lbl_name_player2.Background = Brushes.Transparent;

                playerOneColumn.Background.Opacity = 0.5;
                playerTwoColumn.Background.Opacity = 1.0;
            }
        }
    }
}
