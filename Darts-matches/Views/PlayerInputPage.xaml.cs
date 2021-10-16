using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using Darts_matches.Controllers;
using System.Diagnostics;
using System.Collections.Generic;

namespace Darts_matches
{
    public partial class PlayerInputPage : Page, IKeyHandler
    {
        private string _namePlayerOne;
        private string _namePlayerTwo;
        private string _note;

        public PlayerInputPage()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs eventArguments)
        {
            if (ValidateInputs())
            {
                MatchController.Instance.SetPlayersAndNotes(_namePlayerOne, _namePlayerTwo, _note);
                ApplicationWindow.Instance.SetFrame(new MatchScoresInputPage());
            }
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
                switch (keyEventArgs.Key)
                {
                    case Key.Left:
                        ApplicationWindow.Instance.SetFrame(new MatchInputPage());
                        break;
                    case Key.Right:
                        if (ValidateInputs())
                        {
                            ApplicationWindow.Instance.SetFrame(new MatchScoresInputPage());
                            MatchController.Instance.SetPlayersAndNotes(_namePlayerOne, _namePlayerTwo, "test");
                        }
                        break;
                    default:
                        break;
                }
        }

        private bool ValidateInputs()
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(PlayerOneInputBox);
            textBoxList.Add(PlayerTwoInputBox);

            foreach (TextBox item in textBoxList)
            {
                var validation = ValidationController.Instance.PlayerInputValidate(item.Text);
                if (validation.ErrorContent != null)
                {
                    item.BorderBrush = System.Windows.Media.Brushes.Red;
                } 
                else
                {
                    item.BorderBrush = System.Windows.Media.Brushes.Gray;
                }
            }
            _namePlayerOne = PlayerOneInputBox.Text;
            _namePlayerTwo = PlayerTwoInputBox.Text;
            _note = NotesInputBox.Text;

            return (_namePlayerOne != string.Empty && _namePlayerTwo != string.Empty);
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
