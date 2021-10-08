using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using Darts_matches.Models;
using System.Globalization;

namespace Darts_matches
{
    public partial class MatchInputPage : Page, IKeyHandler
    {
        private Match _match;
        private Player _playerOne;
        private Player _playerTwo;

        public MatchInputPage()
        {
            InitializeComponent();
            this._playerOne = new Player("");
            this._playerTwo = new Player("");
            this._match = new Match("", "", "", this._playerOne, this._playerTwo, -1, -1);
        }

        private void btn_next_Click(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
        }

        private void PlayerInputPage(object sender, RoutedEventArgs eventArguments)
        {
            DateTime datetime = new DateTime();
            int numberOfSets = 0;

            if (this.validateInput(datetime) && this.validateInputSets(numberOfSets))
            {
                this._match.Date = datetime;
                this._match.NumberOfSets = numberOfSets;
                ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
            }
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
            DateTime datetime = new DateTime();
            int numberOfSets = 0;

            if (this.validateInput(datetime) && this.validateInputSets(numberOfSets))
            {
                this._match.Date = datetime;
                this._match.NumberOfSets = numberOfSets;
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

        private bool validateInput(DateTime date)
        {
            //if (DateInputBox.Text != "")
            //{
            //    var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };
            //    if (DateTime.TryParseExact(DateInputBox.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            //    {
            //        DateInputBox.BorderBrush = System.Windows.Media.Brushes.Gray;
            //        return true;
            //    }
            //    else
            //    {
            //        DateInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            //        return false;
            //    }
            //}
            //else
            //{
            //    DateInputBox.BorderBrush = System.Windows.Media.Brushes.Gray;
            //    return true;
            //}
            return true;
        }

        private bool validateInputSets(int sets)
        {
            if (int.TryParse(lbl_nr_of_sets.Text, out sets))
            {
                lbl_nr_of_sets.BorderBrush = System.Windows.Media.Brushes.Gray;
                return true;
            }
            else
            {
                lbl_nr_of_sets.BorderBrush = System.Windows.Media.Brushes.Red;
                return false;
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

        private void btn_add_leg_Click(object sender, RoutedEventArgs e)
        {
            int currentNrOfLegs = int.Parse(lbl_nr_of_legs.Text);
            currentNrOfLegs++;
            lbl_nr_of_legs.Text = currentNrOfLegs.ToString();
        }

        private void btn_del_leg_Click(object sender, RoutedEventArgs e)
        {
            int currentNrOfLegs = int.Parse(lbl_nr_of_legs.Text);
            currentNrOfLegs--;
            if (currentNrOfLegs > 0) lbl_nr_of_legs.Text = currentNrOfLegs.ToString();
            else lbl_nr_of_legs.Text = "0";
        }

        private void btn_add_set_Click(object sender, RoutedEventArgs e)
        {
            int currentNrOfSets = int.Parse(lbl_nr_of_sets.Text);
            currentNrOfSets++;
            lbl_nr_of_sets.Text = currentNrOfSets.ToString();
        }

        private void btn_del_set_Click(object sender, RoutedEventArgs e)
        {
            int currentNrOfSets = int.Parse(lbl_nr_of_sets.Text);
            currentNrOfSets--;
            if (currentNrOfSets > 0) lbl_nr_of_sets.Text = currentNrOfSets.ToString();
            else lbl_nr_of_sets.Text = "0";
        }
    }
}
