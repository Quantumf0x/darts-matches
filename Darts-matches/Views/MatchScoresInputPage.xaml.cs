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
        private static readonly Brush _selectedThrowBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0078D7"));
        private static readonly Brush _unSelectedThrowBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2497F1"));
        private static readonly Brush _unSelectedInactiveThrowBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#552497F1"));
        #endregion

        #region [Fields]: Models
        private Match _match;
        private Player _selectedPlayer;
        private Player _startingPlayer;
        private TextBox _selectedThrow;
        #endregion


        #region [Constructors]
        public MatchScoresInputPage()
        {
            InitializeComponent();

            _match = MatchController.Instance.getMatch();
            lbl_name_player1.Text = _match.PlayerOne.Name;
            lbl_name_player2.Text = _match.PlayerTwo.Name;

            _selectedPlayer = _match.PlayerOne;
            _startingPlayer = _match.PlayerOne;
            
            lbl_throw1_player1.Focus();

            lbl_name_player1.Background = _selectedPlayerBrush;
            lbl_name_player2.Background = Brushes.Transparent;

            

            
        }
        #endregion

        #region [Methods]: Pages
        private void MatchResultsPage(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new MatchResultsPage());
        }
        #endregion

        #region [Methods]: Key Handling
        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.Key)
            {
                case Key.Left:
                    if (_selectedPlayer.Equals(_match.PlayerTwo)){
                        ChangePlayer();
                    }
                    break;
                case Key.Right:
                    if (_selectedPlayer.Equals(_match.PlayerOne))
                    {
                        ChangePlayer();
                    }
                    break;
                case Key.Tab:
                   
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region [Methods]: View Event Listeners
        private void btn_main_Click(object sender, RoutedEventArgs e)
        {
            ApplicationWindow.Instance.SetFrame(new MainMenuPage());
        }

        private void btn_help_Click(object sender, RoutedEventArgs e)
        {
            ApplicationWindow.Instance.SetFrame(new HelpPage());
        }
        #endregion

        #region [Methods]: Players
        private void ChangePlayer()
        {
            if (_match.PlayerOne.Equals(_selectedPlayer))
            {
                _selectedPlayer = _match.PlayerTwo;

                lbl_throw1_player1.Focusable = false;
                lbl_throw2_player1.Focusable = false;
                lbl_throw3_player1.Focusable = false;

                lbl_name_player1.Background = Brushes.Transparent;
                lbl_name_player2.Background = _selectedPlayerBrush;

                lbl_header_throw1_player2.Background = _selectedThrowBrush;
                lbl_header_throw2_player2.Background = _unSelectedThrowBrush;
                lbl_header_throw3_player2.Background = _unSelectedThrowBrush;

                lbl_throw1_player2.Background = _selectedThrowBrush;
                lbl_throw2_player2.Background = _unSelectedThrowBrush;
                lbl_throw3_player2.Background = _unSelectedThrowBrush;

                lbl_header_throw1_player1.Background = _unSelectedInactiveThrowBrush;
                lbl_header_throw2_player1.Background = _unSelectedInactiveThrowBrush;
                lbl_header_throw3_player1.Background = _unSelectedInactiveThrowBrush;

                lbl_throw1_player1.Background = _unSelectedInactiveThrowBrush;
                lbl_throw2_player1.Background = _unSelectedInactiveThrowBrush;
                lbl_throw3_player1.Background = _unSelectedInactiveThrowBrush;
            }
            else if (_match.PlayerTwo.Equals(_selectedPlayer))
            {
                _selectedPlayer = _match.PlayerOne;

                lbl_throw1_player2.Focusable = false;
                lbl_throw2_player2.Focusable = false;
                lbl_throw3_player2.Focusable = false;

                lbl_name_player1.Background = _selectedPlayerBrush;
                lbl_name_player2.Background = Brushes.Transparent;

                lbl_header_throw1_player1.Background = _selectedThrowBrush;
                lbl_header_throw2_player1.Background = _unSelectedThrowBrush;
                lbl_header_throw3_player1.Background = _unSelectedThrowBrush;

                lbl_throw1_player1.Background = _selectedThrowBrush;
                lbl_throw2_player1.Background = _unSelectedThrowBrush;
                lbl_throw3_player1.Background = _unSelectedThrowBrush;

                lbl_header_throw1_player2.Background = _unSelectedInactiveThrowBrush;
                lbl_header_throw2_player2.Background = _unSelectedInactiveThrowBrush;
                lbl_header_throw3_player2.Background = _unSelectedInactiveThrowBrush;

                lbl_throw1_player2.Background = _unSelectedInactiveThrowBrush;
                lbl_throw2_player2.Background = _unSelectedInactiveThrowBrush;
                lbl_throw3_player2.Background = _unSelectedInactiveThrowBrush;
            }
        }

        #endregion

        private void lbl_throw1_player1_GotFocus(object sender, RoutedEventArgs e)
        {
            _selectedPlayer = _match.PlayerOne;
            _selectedThrow = lbl_throw1_player1;
            lbl_throw1_player2.Focusable = false;
            lbl_throw2_player2.Focusable = false;
            lbl_throw3_player2.Focusable = false;

            lbl_name_player1.Background = _selectedPlayerBrush;
            lbl_name_player2.Background = Brushes.Transparent;

            lbl_header_throw1_player1.Background = _selectedThrowBrush;
            lbl_header_throw2_player1.Background = _unSelectedThrowBrush;
            lbl_header_throw3_player1.Background = _unSelectedThrowBrush;
            lbl_throw1_player1.Background = _selectedThrowBrush;
            lbl_throw2_player1.Background = _unSelectedThrowBrush;
            lbl_throw3_player1.Background = _unSelectedThrowBrush;

            lbl_header_throw1_player2.Background = _unSelectedInactiveThrowBrush;
            lbl_header_throw2_player2.Background = _unSelectedInactiveThrowBrush;
            lbl_header_throw3_player2.Background = _unSelectedInactiveThrowBrush;
            lbl_throw1_player2.Background = _unSelectedInactiveThrowBrush;
            lbl_throw2_player2.Background = _unSelectedInactiveThrowBrush;
            lbl_throw3_player2.Background = _unSelectedInactiveThrowBrush;
        }

        private void lbl_throw2_player1_GotFocus(object sender, RoutedEventArgs e)
        {
            _selectedThrow = lbl_throw2_player1;

            lbl_header_throw2_player1.Background = _selectedThrowBrush;
            lbl_throw2_player1.Background = _selectedThrowBrush;

            lbl_header_throw1_player1.Background = _unSelectedThrowBrush;
            lbl_throw1_player1.Background = _unSelectedThrowBrush;
        }

        private void lbl_throw3_player1_GotFocus(object sender, RoutedEventArgs e)
        {
            _selectedThrow = lbl_throw3_player1;
            if (_selectedPlayer.Equals(_startingPlayer)){
                lbl_throw1_player2.Focusable = true;
                lbl_throw2_player2.Focusable = true;
                lbl_throw3_player2.Focusable = true;
            }

            lbl_header_throw3_player1.Background = _selectedThrowBrush;
            lbl_throw3_player1.Background = _selectedThrowBrush;

            lbl_header_throw2_player1.Background = _unSelectedThrowBrush;
            lbl_throw2_player1.Background = _unSelectedThrowBrush;
        }

        private void lbl_throw1_player2_GotFocus(object sender, RoutedEventArgs e)
        {
            _selectedPlayer = _match.PlayerTwo;
            _selectedThrow = lbl_throw1_player2;
            lbl_throw1_player1.Focusable = false;
            lbl_throw2_player1.Focusable = false;
            lbl_throw3_player1.Focusable = false;

            lbl_name_player2.Background = _selectedPlayerBrush;
            lbl_name_player1.Background = Brushes.Transparent;

            lbl_header_throw1_player2.Background = _selectedThrowBrush;
            lbl_header_throw2_player2.Background = _unSelectedThrowBrush;
            lbl_header_throw3_player2.Background = _unSelectedThrowBrush;

            lbl_throw1_player2.Background = _selectedThrowBrush;
            lbl_throw2_player2.Background = _unSelectedThrowBrush;
            lbl_throw3_player2.Background = _unSelectedThrowBrush;

            lbl_header_throw1_player1.Background = _unSelectedInactiveThrowBrush;
            lbl_header_throw2_player1.Background = _unSelectedInactiveThrowBrush;
            lbl_header_throw3_player1.Background = _unSelectedInactiveThrowBrush;

            lbl_throw1_player1.Background = _unSelectedInactiveThrowBrush;
            lbl_throw2_player1.Background = _unSelectedInactiveThrowBrush;
            lbl_throw3_player1.Background = _unSelectedInactiveThrowBrush;

            
        }

        private void lbl_throw2_player2_GotFocus(object sender, RoutedEventArgs e)
        {
            _selectedThrow = lbl_throw2_player2;

            lbl_header_throw2_player2.Background = _selectedThrowBrush;
            lbl_throw2_player2.Background = _selectedThrowBrush;

            lbl_header_throw1_player2.Background = _unSelectedThrowBrush;
            lbl_throw1_player2.Background = _unSelectedThrowBrush;
        }

        private void lbl_throw3_player2_GotFocus(object sender, RoutedEventArgs e)
        {
            _selectedThrow = lbl_throw3_player2;
            if (_selectedPlayer.Equals(_startingPlayer))
            {
                lbl_throw1_player1.Focusable = true;
                lbl_throw2_player1.Focusable = true;
                lbl_throw3_player1.Focusable = true;
            }

            lbl_header_throw3_player2.Background = _selectedThrowBrush;
            lbl_throw3_player2.Background = _selectedThrowBrush;

            lbl_header_throw2_player2.Background = _unSelectedThrowBrush;
            lbl_throw2_player2.Background = _unSelectedThrowBrush;
        }
    }
}
