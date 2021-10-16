using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using Darts_matches.Controllers;
using System.Diagnostics;
using System.Collections.Generic;

namespace Darts_matches
{
    public partial class MatchInputPage : Page, IKeyHandler
    {
        private string _matchName;
        private DateTime _date;
        private int _pointsPerLeg;
        private int _numberOfLegsPerSet;
        private int _numberOfSets;

        public MatchInputPage()
        {
            InitializeComponent();
        }

        private void Submit(object sender, RoutedEventArgs eventArguments)
        {
            if (ValidateInputs())
            {
                MatchController.Instance.CreateMatchAndSetInputs(_matchName, _date, _pointsPerLeg, _numberOfLegsPerSet, _numberOfSets);
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
                        MatchController.Instance.CreateMatchAndSetInputs(_matchName, _date, _pointsPerLeg, _numberOfLegsPerSet, _numberOfSets);
                        break;
                    default:
                        break;
                }
            }
        }

        private bool ValidateInputs()
        {
            var nameInputValidation = ValidationController.Instance.MatchInputValidate(NameInputBox.Text);
            if (nameInputValidation.ErrorContent != null)
            {
                NameInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                NameInputBox.BorderBrush = System.Windows.Media.Brushes.Gray;
            }
            List<TextBox> setAndLegsList = new List<TextBox>();
            setAndLegsList.Add(SetsInputBox);
            setAndLegsList.Add(LegsInputBox);

            foreach (TextBox item in setAndLegsList)
            {
                var validation = ValidationController.Instance.SetsAndLegValidate(item.Text);
                if (validation.ErrorContent != null)
                {
                    item.BorderBrush = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    item.BorderBrush = System.Windows.Media.Brushes.Gray;
                }
            }
            _matchName = NameInputBox.Text;
            _numberOfSets = Convert.ToInt32(SetsInputBox.Text);
            _numberOfLegsPerSet = Convert.ToInt32(LegsInputBox.Text);

            var dateValidation = ValidationController.Instance.MatchDateValidate(DateSelector.SelectedDate);
            if (dateValidation.ErrorContent != null)
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
                DateSelector.BorderBrush = System.Windows.Media.Brushes.Gray;
            }

            if (ToggleShortMatch.IsChecked == true)
            {
                _pointsPerLeg = 301;
            }
            else
            {
                _pointsPerLeg = 501;
            }
            return _matchName != null && _date != null && _date != DateTime.MinValue && _numberOfLegsPerSet != 0 && _numberOfSets != 0;
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
