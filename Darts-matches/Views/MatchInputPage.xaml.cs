﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using Darts_matches.Controllers;
using System.Diagnostics;

namespace Darts_matches
{
    public partial class MatchInputPage : Page, IKeyHandler
    {
        private string _matchName;
        private DateTime _date;

        public string MatchName { get => _matchName; }
        public DateTime Date { get => _date; }

        public MatchInputPage()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs eventArguments)
        {
            if (ValidateInputs())
            {
                ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
            }
            else
            {
                _matchName = null;
            }
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
            if (ValidateInputs())
            {
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

                MatchController.Instance.SetNameAndDate(_matchName, _date);
            }
        }

        private bool ValidateInputs()
        {
            if (NameInputBox.Text == "")
            {
                NameInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                _matchName = NameInputBox.Text;
            }

            if (DateSelector.SelectedDate == null || DateSelector.Text == "")
            {
                DateSelector.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                try
                {
                    _date = Convert.ToDateTime(DateSelector.SelectedDate.Value.ToShortDateString());
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }

            // TODO: check for valid input for sets and legs and change bordercolor to red when invalid

            return _matchName != null && _date != null && _date != DateTime.MinValue;
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
