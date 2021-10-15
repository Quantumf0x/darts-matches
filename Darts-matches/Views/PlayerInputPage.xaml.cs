﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using Darts_matches.Controllers;
using System.Diagnostics;

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
            if (PlayerOneInputBox.Text == string.Empty)
            {
                PlayerOneInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                _namePlayerOne = PlayerOneInputBox.Text;
            }

            if (PlayerTwoInputBox.Text == string.Empty)
            {
                PlayerTwoInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                _namePlayerTwo = PlayerTwoInputBox.Text;
            }

            if (NotesInputBox.Text != string.Empty)
            {
                _note = NotesInputBox.Text;
            }

            return (_namePlayerOne != null && _namePlayerTwo != null);
        }

        private void MainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            ApplicationWindow.Instance.SetFrame(new MainMenuPage());
        }

        private void HelpButtonClick(object sender, RoutedEventArgs e)
        {
            HelpPage helpPage = new HelpPage();
            helpPage.SetPreviousContext(this);
            ApplicationWindow.Instance.SetFrame(helpPage);
        }
    }
}
