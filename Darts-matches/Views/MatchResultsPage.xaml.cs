using Darts_matches.Controllers;
using Darts_matches.Models;
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
            var match = MatchController.Instance.getMatch();
            DisplayWinnerBorder(match);
            DisplayPlayer1Info(match);
            DisplayPlayer2Info(match);            
        }

        private void DisplayWinnerBorder(Match match)
        {
            if(match.Winner != null)
            {
                if (match.Winner.Name == match.PlayerOne.Name)
                {
                    winner_announcer_textblock.Text = string.Format($"{0} is de winnaar!", match.PlayerOne.Name);
                    player1_border.BorderBrush = System.Windows.Media.Brushes.Gold;
                    player1_border.BorderThickness = new Thickness(5, 5, 5, 5);
                    player2_border.BorderBrush = System.Windows.Media.Brushes.Silver;
                    player2_border.BorderThickness = new Thickness(2, 2, 2, 2);
                }
                winner_announcer_textblock.Text = string.Format($"{0} is de winnaar!", match.PlayerTwo.Name);
                player2_border.BorderBrush = System.Windows.Media.Brushes.Gold;
                player2_border.BorderThickness = new Thickness(5, 5, 5, 5);
                player1_border.BorderBrush = System.Windows.Media.Brushes.Silver;
                player1_border.BorderThickness = new Thickness(2, 2, 2, 2);
            }
        }
        private void DisplayPlayer1Info(Match match)
        {
            lbl_name_player1.Text = match.PlayerOne.Name;
            lbl_average_set_player1.Text = match.PlayerOne.AveragePerSet.ToString();
            lbl_average_leg_player1.Text = match.PlayerOne.AveragePerLeg.ToString();
            lbl_average_turn_player1.Text = match.PlayerOne.AveragePerTurn.ToString();
            lbl_amount_of_180s_player1.Text = match.PlayerOne.NumberOfMaxScores.ToString();
        }
        private void DisplayPlayer2Info(Match match)
        {
            lbl_name_player2.Text = match.PlayerTwo.Name;
            lbl_average_set_player2.Text = match.PlayerTwo.AveragePerSet.ToString();
            lbl_average_leg_player2.Text = match.PlayerTwo.AveragePerSet.ToString();
            lbl_average_turn_player2.Text = match.PlayerTwo.AveragePerSet.ToString();
            lbl_amount_of_180s_player2.Text = match.PlayerTwo.AveragePerSet.ToString();
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
        private void btn_main_Click(object sender, RoutedEventArgs e)
        {
            ApplicationWindow.Instance.SetFrame(new MainMenuPage());
        }

        private void btn_help_Click(object sender, RoutedEventArgs e)
        {
            HelpPage helpPage = new HelpPage();
            helpPage.SetPreviousContext(this);
            ApplicationWindow.Instance.SetFrame(helpPage);
        }
    }
}
