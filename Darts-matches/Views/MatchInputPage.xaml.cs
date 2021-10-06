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
            if (DateInputBox.Text != "")
            {
                var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };
                if (DateTime.TryParseExact(DateInputBox.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    DateInputBox.BorderBrush = System.Windows.Media.Brushes.Gray;
                    return true;
                }
                else
                {
                    DateInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
                    return false;
                }
            }
            else
            {
                DateInputBox.BorderBrush = System.Windows.Media.Brushes.Gray;
                return true;
            }
        }

        private bool validateInputSets(int sets)
        {
            if (Int32.TryParse(SetsInputBox.Text, out sets))
            {
                SetsInputBox.BorderBrush = System.Windows.Media.Brushes.Gray;
                return true;
            }
            else
            {
                SetsInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
                return false;
            }
        }
    }
}
