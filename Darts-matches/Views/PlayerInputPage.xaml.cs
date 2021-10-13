using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using Darts_matches.Controllers;
using System.Diagnostics;

namespace Darts_matches
{
    public partial class PlayerInputPage : Page, IKeyHandler
    {

        private string _playerOneName;
        private string _playerTwoName;

        public PlayerInputPage()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new MatchScoresInputPage());
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.Key)
            {
                case Key.Left:
                    ApplicationWindow.Instance.SetFrame(new MatchInputPage());
                    break;
                case Key.Right:
                    ApplicationWindow.Instance.SetFrame(new MatchScoresInputPage());
                    break;
                default:
                    break;
            }
        }

        private bool ValidateInputs()
        {
            if (PlayerOneInputBox.Text == string.Empty)
            {
                PlayerOneInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                _playerOneName = PlayerOneInputBox.Text;
            }

            if (PlayerTwoInputBox.Text == string.Empty)
            {
                PlayerTwoInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                _playerTwoName = PlayerTwoInputBox.Text;
            }

            return (_playerOneName != null && _playerTwoName != null);
        }

        private void MainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            ApplicationWindow.Instance.SetFrame(new MainMenuPage());
        }

        private void HelpButtonClick(object sender, RoutedEventArgs e)
        {
            ApplicationWindow.Instance.SetFrame(new HelpPage());
        }
    }
}
