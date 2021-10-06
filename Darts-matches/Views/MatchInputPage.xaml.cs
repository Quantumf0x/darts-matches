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

            if (this.validateInput(datetime))
            {
                this._match.setDate(datetime);
                ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
            } 
            else
            {
                DateInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
            DateTime datetime = new DateTime();

            if (this.validateInput(datetime))
            {
                this._match.setDate(datetime);
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
            else
            {
                DateInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
        }

        private bool validateInput(DateTime date)
        {
            if (DateInputBox.Text != "")
            {
                var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" };
                if (DateTime.TryParseExact(DateInputBox.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            else
            {
                return true;
            } 
        }
    }
}
