using System;
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

            lbl_score_remain_player1.Text = _match.PointsPerLeg.ToString();
            lbl_score_remain_player2.Text = _match.PointsPerLeg.ToString();

            //Starting Player:
            _startingPlayer = _match.PlayerOne;            
            lbl_throw1_player1.Focus();

            //Second Player:
            lbl_name_player2.Background = Brushes.Transparent;

            lbl_throw1_player2.Focusable = false;
            lbl_throw2_player2.Focusable = false;
            lbl_throw3_player2.Focusable = false;

            //Throw 1:
            lbl_header_throw1_player2.Background = _unSelectedInactiveThrowBrush;
            lbl_throw1_player2.Background = _unSelectedInactiveThrowBrush;

            //Throw 2:
            lbl_header_throw2_player2.Background = _unSelectedInactiveThrowBrush;
            lbl_throw2_player2.Background = _unSelectedInactiveThrowBrush;

            //Throw 3:
            lbl_header_throw3_player2.Background = _unSelectedInactiveThrowBrush;
            lbl_throw3_player2.Background = _unSelectedInactiveThrowBrush;
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
                    break;
                case Key.Right:
                    break;
                case Key.Tab:
                    break;
                case Key.Enter:
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

        #region [Methods]: Match
        private void NextTurn()
        {
            Area throwOneArea;
            int throwOne = 0;

            Area throwTwoArea;
            int throwTwo = 0;

            Area throwThreeArea;
            int throwThree = 0;

            int score = 0;

            if (_selectedPlayer.Equals(_match.PlayerOne))
            {
                //Player 1:
                lbl_throw1_player1.Focusable = false;
                lbl_throw2_player1.Focusable = false;
                lbl_throw3_player1.Focusable = false;

                //Throw 1:
                lbl_header_throw1_player1.Background = _unSelectedInactiveThrowBrush;
                lbl_throw1_player1.Background = _unSelectedInactiveThrowBrush;

                //Throw 2:
                lbl_header_throw2_player1.Background = _unSelectedInactiveThrowBrush;
                lbl_throw2_player1.Background = _unSelectedInactiveThrowBrush;

                //Throw 3:
                lbl_header_throw3_player1.Background = _unSelectedInactiveThrowBrush;
                lbl_throw3_player1.Background = _unSelectedInactiveThrowBrush;

                if (lbl_throw1_player1.Text.Contains('d') && lbl_throw1_player1.Text.Substring(0, 1).Equals("d"))
                {
                    throwOneArea = Area.Double;
                    try
                    {
                        throwOne = Int32.Parse(lbl_throw1_player1.Text.Substring(1));
                        score += throwOne * 2;
                        _match.PlayerOne.ThrowDart(throwOneArea, throwOne);
                    }
                    catch (Exception) { }
                }
                else if (lbl_throw1_player1.Text.Contains('t') && lbl_throw1_player1.Text.Substring(0, 1).Equals("t"))
                {
                    throwOneArea = Area.Triple;
                    try
                    {
                        throwOne = Int32.Parse(lbl_throw1_player1.Text.Substring(1));
                        score += throwOne * 3;
                        _match.PlayerOne.ThrowDart(throwOneArea, throwOne);
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        throwOne = Int32.Parse(lbl_throw1_player1.Text);
                        if (throwOne == 25)
                        {
                            throwOneArea = Area.OuterBullseye;
                        }
                        else if (throwOne == 50)
                        {
                            throwOneArea = Area.InnerBullseye;
                        }
                        else
                        {
                            throwOneArea = Area.Single;
                        }

                        score += throwOne;
                        _match.PlayerOne.ThrowDart(throwOneArea, throwOne);
                    }
                    catch (Exception) { }
                }

                if (lbl_throw2_player1.Text.Contains('d') && lbl_throw2_player1.Text.Substring(0, 1).Equals("d"))
                {
                    throwTwoArea = Area.Double;
                    try
                    {
                        throwTwo = Int32.Parse(lbl_throw2_player1.Text.Substring(1));
                        score += throwTwo * 2;
                        _match.PlayerOne.ThrowDart(throwTwoArea, throwTwo);
                    }
                    catch (Exception) { }
                }
                else if (lbl_throw2_player1.Text.Contains('t') && lbl_throw2_player1.Text.Substring(0, 1).Equals("t"))
                {
                    throwTwoArea = Area.Triple;
                    try
                    {
                        throwTwo = Int32.Parse(lbl_throw2_player1.Text.Substring(1));
                        score += throwTwo * 3;
                        _match.PlayerOne.ThrowDart(throwTwoArea, throwTwo);
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        throwTwo = Int32.Parse(lbl_throw2_player1.Text);
                        if (throwTwo == 25)
                        {
                            throwTwoArea = Area.OuterBullseye;
                        }
                        else if (throwTwo == 50)
                        {
                            throwTwoArea = Area.InnerBullseye;
                        }
                        else
                        {
                            throwTwoArea = Area.Single;
                        }

                        score += throwTwo;
                        _match.PlayerOne.ThrowDart(throwTwoArea, throwTwo);
                    }
                    catch (Exception) { }
                }

                if (lbl_throw3_player1.Text.Contains('d') && lbl_throw3_player1.Text.Substring(0, 1).Equals("d"))
                {
                    throwThreeArea = Area.Double;
                    try
                    {
                        throwThree = Int32.Parse(lbl_throw3_player1.Text.Substring(1));
                        score += throwThree * 2;
                        _match.PlayerOne.ThrowDart(throwThreeArea, throwThree);
                    }
                    catch (Exception) { }
                }
                else if (lbl_throw3_player1.Text.Contains('t') && lbl_throw3_player1.Text.Substring(0, 1).Equals("t"))
                {
                    throwThreeArea = Area.Triple;
                    try
                    {
                        throwThree = Int32.Parse(lbl_throw3_player1.Text.Substring(1));
                        score += throwThree * 3;
                        _match.PlayerOne.ThrowDart(throwThreeArea, throwThree);
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        throwThree = Int32.Parse(lbl_throw3_player1.Text);
                        if (throwThree == 25)
                        {
                            throwThreeArea = Area.OuterBullseye;
                        }
                        else if (throwThree == 50)
                        {
                            throwThreeArea = Area.InnerBullseye;
                        }
                        else
                        {
                            throwThreeArea = Area.Single;
                        }

                        score += throwThree;
                        _match.PlayerOne.ThrowDart(throwThreeArea, throwThree);
                    }
                    catch (Exception) { }
                }

                lbl_current_turn_player1.Text = score.ToString();
                lbl_score_remain_player1.Text = (Int32.Parse(lbl_score_remain_player1.Text) - score).ToString();

                //Player 2:
                lbl_throw1_player2.Focusable = true;
                lbl_throw2_player2.Focusable = true;
                lbl_throw3_player2.Focusable = true;

                lbl_throw1_player2.Focus();
            }
            else
            {
                //Player 2:
                lbl_throw1_player2.Focusable = false;
                lbl_throw2_player2.Focusable = false;
                lbl_throw3_player2.Focusable = false;

                //Throw 1:
                lbl_header_throw1_player2.Background = _unSelectedInactiveThrowBrush;
                lbl_throw1_player2.Background = _unSelectedInactiveThrowBrush;

                //Throw 2:
                lbl_header_throw2_player2.Background = _unSelectedInactiveThrowBrush;
                lbl_throw2_player2.Background = _unSelectedInactiveThrowBrush;

                //Throw 3:
                lbl_header_throw3_player2.Background = _unSelectedInactiveThrowBrush;
                lbl_throw3_player2.Background = _unSelectedInactiveThrowBrush;

                if (lbl_throw1_player2.Text.Contains('d') && lbl_throw1_player2.Text.Substring(0, 1).Equals("d"))
                {
                    throwOneArea = Area.Double;
                    try
                    {
                        throwOne = Int32.Parse(lbl_throw1_player2.Text.Substring(1));
                        score += throwOne * 2;
                        _match.PlayerTwo.ThrowDart(throwOneArea, throwOne);
                    }
                    catch (Exception) { }
                }
                else if (lbl_throw1_player2.Text.Contains('t') && lbl_throw1_player2.Text.Substring(0, 1).Equals("t"))
                {
                    throwOneArea = Area.Triple;
                    try
                    {
                        throwOne = Int32.Parse(lbl_throw1_player2.Text.Substring(1));
                        score += throwOne * 3;
                        _match.PlayerTwo.ThrowDart(throwOneArea, throwOne);
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        throwOne = Int32.Parse(lbl_throw1_player2.Text);
                        if (throwOne == 25)
                        {
                            throwOneArea = Area.OuterBullseye;
                        }
                        else if (throwOne == 50)
                        {
                            throwOneArea = Area.InnerBullseye;
                        }
                        else
                        {
                            throwOneArea = Area.Single;
                        }

                        score += throwOne;
                        _match.PlayerTwo.ThrowDart(throwOneArea, throwOne);
                    }
                    catch (Exception) { }
                }

                if (lbl_throw2_player2.Text.Contains('d') && lbl_throw2_player2.Text.Substring(0, 1).Equals("d"))
                {
                    throwTwoArea = Area.Double;
                    try
                    {
                        throwTwo = Int32.Parse(lbl_throw2_player2.Text.Substring(1));
                        score += throwTwo * 2;
                        _match.PlayerTwo.ThrowDart(throwTwoArea, throwTwo);
                    }
                    catch (Exception) { }
                }
                else if (lbl_throw2_player2.Text.Contains('t') && lbl_throw2_player2.Text.Substring(0, 1).Equals("t"))
                {
                    throwTwoArea = Area.Triple;
                    try
                    {
                        throwTwo = Int32.Parse(lbl_throw2_player2.Text.Substring(1));
                        score += throwTwo * 3;
                        _match.PlayerTwo.ThrowDart(throwTwoArea, throwTwo);
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        throwTwo = Int32.Parse(lbl_throw2_player2.Text);
                        if (throwTwo == 25)
                        {
                            throwTwoArea = Area.OuterBullseye;
                        }
                        else if (throwTwo == 50)
                        {
                            throwTwoArea = Area.InnerBullseye;
                        }
                        else
                        {
                            throwTwoArea = Area.Single;
                        }

                        score += throwTwo;
                        _match.PlayerTwo.ThrowDart(throwTwoArea, throwTwo);
                    }
                    catch (Exception) { }
                }

                if (lbl_throw3_player2.Text.Contains('d') && lbl_throw3_player2.Text.Substring(0, 1).Equals("d"))
                {
                    throwThreeArea = Area.Double;
                    try
                    {
                        throwThree = Int32.Parse(lbl_throw3_player2.Text.Substring(1));
                        score += throwThree * 2;
                        _match.PlayerTwo.ThrowDart(throwThreeArea, throwThree);
                    }
                    catch (Exception) { }
                }
                else if (lbl_throw3_player2.Text.Contains('t') && lbl_throw3_player2.Text.Substring(0, 1).Equals("t"))
                {
                    throwThreeArea = Area.Triple;
                    try
                    {
                        throwThree = Int32.Parse(lbl_throw3_player2.Text.Substring(1));
                        score += throwThree * 3;
                        _match.PlayerTwo.ThrowDart(throwThreeArea, throwThree);
                    }
                    catch (Exception) { }
                }
                else
                {
                    try
                    {
                        throwThree = Int32.Parse(lbl_throw3_player2.Text);
                        if (throwThree == 25)
                        {
                            throwThreeArea = Area.OuterBullseye;
                        }
                        else if (throwThree == 50)
                        {
                            throwThreeArea = Area.InnerBullseye;
                        }
                        else
                        {
                            throwThreeArea = Area.Single;
                        }

                        score += throwThree;
                        _match.PlayerTwo.ThrowDart(throwThreeArea, throwThree);
                    }
                    catch (Exception) { }
                }

                lbl_current_turn_player2.Text = score.ToString();

                lbl_score_remain_player2.Text = (Int32.Parse(lbl_score_remain_player2.Text) - score).ToString();

                //Player 1:
                lbl_throw1_player1.Focusable = true;
                lbl_throw2_player1.Focusable = true;
                lbl_throw3_player1.Focusable = true;

                lbl_throw1_player1.Focus();
            }


        }

        #endregion

        private void lbl_throw1_player1_GotFocus(object sender, RoutedEventArgs e)
        {
            //Player 1:
            _selectedPlayer = _match.PlayerOne;
            _selectedThrow = lbl_throw1_player1;
            lbl_name_player1.Background = _selectedPlayerBrush;

            //Player 2:
            lbl_name_player2.Background = Brushes.Transparent;

            //Throw 1:
            lbl_header_throw1_player1.Background = _selectedThrowBrush;
            lbl_throw1_player1.Background = _selectedThrowBrush;

            //Throw 2:
            lbl_header_throw2_player1.Background = _unSelectedThrowBrush;
            lbl_throw2_player1.Background = _unSelectedThrowBrush;

            //Throw 3:
            lbl_header_throw3_player1.Background = _unSelectedThrowBrush;
            lbl_throw3_player1.Background = _unSelectedThrowBrush;
        }
        private void lbl_throw2_player1_GotFocus(object sender, RoutedEventArgs e)
        {
            //Throw 1:
            lbl_header_throw1_player1.Background = _unSelectedThrowBrush;
            lbl_throw1_player1.Background = _unSelectedThrowBrush;

            //Throw 2:
            _selectedThrow = lbl_throw2_player1;

            lbl_header_throw2_player1.Background = _selectedThrowBrush;
            lbl_throw2_player1.Background = _selectedThrowBrush;
        }
        private void lbl_throw3_player1_GotFocus(object sender, RoutedEventArgs e)
        {
            //Throw 2:
            lbl_header_throw2_player1.Background = _unSelectedThrowBrush;
            lbl_throw2_player1.Background = _unSelectedThrowBrush;

            //Throw 3:
            _selectedThrow = lbl_throw3_player1;

            lbl_header_throw3_player1.Background = _selectedThrowBrush;
            lbl_throw3_player1.Background = _selectedThrowBrush;
        }

        private void lbl_throw1_player2_GotFocus(object sender, RoutedEventArgs e)
        {
            //Player 1:
            lbl_name_player1.Background = Brushes.Transparent;

            //Player 2:
            _selectedPlayer = _match.PlayerTwo;
            _selectedThrow = lbl_throw1_player2;
            lbl_name_player2.Background = _selectedPlayerBrush;

            //Throw 1:
            lbl_header_throw1_player2.Background = _selectedThrowBrush;
            lbl_throw1_player2.Background = _selectedThrowBrush;

            //Throw 2:
            lbl_header_throw2_player2.Background = _unSelectedThrowBrush;
            lbl_throw2_player2.Background = _unSelectedThrowBrush;

            //Throw 3:
            lbl_header_throw3_player2.Background = _unSelectedThrowBrush;
            lbl_throw3_player2.Background = _unSelectedThrowBrush;
        }
        private void lbl_throw2_player2_GotFocus(object sender, RoutedEventArgs e)
        {
            //Throw 1:
            lbl_header_throw1_player2.Background = _unSelectedThrowBrush;
            lbl_throw1_player2.Background = _unSelectedThrowBrush;

            //Throw 2:
            _selectedThrow = lbl_throw2_player2;

            lbl_header_throw2_player2.Background = _selectedThrowBrush;
            lbl_throw2_player2.Background = _selectedThrowBrush;
        }
        private void lbl_throw3_player2_GotFocus(object sender, RoutedEventArgs e)
        {
            //Throw 2:
            lbl_header_throw2_player2.Background = _unSelectedThrowBrush;
            lbl_throw2_player2.Background = _unSelectedThrowBrush;

            //Throw 3:
            _selectedThrow = lbl_throw3_player2;

            lbl_header_throw3_player2.Background = _selectedThrowBrush;
            lbl_throw3_player2.Background = _selectedThrowBrush;
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                NextTurn();
            }
        }
    }
}
