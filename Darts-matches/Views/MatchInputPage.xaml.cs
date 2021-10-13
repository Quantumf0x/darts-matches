using System.Windows;
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
        private int _pointsPerLeg;
        private int _numberOfLegsPerSet;
        private int _numberOfSets;

        public string MatchName { get => _matchName; }
        public DateTime Date { get => _date; }
        public int PointsPerLeg { get => _pointsPerLeg; }
        public int NumberOfLegsPerSet { get => _numberOfLegsPerSet; set => _numberOfLegsPerSet = value; }
        public int NumberOfSets { get => _numberOfSets; set => _numberOfSets = value; }

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
            if (NameInputBox.Text == string.Empty)
            {
                NameInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                _matchName = NameInputBox.Text;
            }

            if (DateSelector.SelectedDate == null || DateSelector.Text == string.Empty)
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

            if (ToggleShortMatch.IsChecked == true)
            {
                _pointsPerLeg = 301;
            }
            else
            {
                _pointsPerLeg = 501;
            }
            if (SetsInputBox.Text == "0")
            {
                SetsInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                if (SetsInputBox.Text != string.Empty)
                {
                    _numberOfSets = Convert.ToInt32(SetsInputBox.Text);
                }
            }
            if (LegsInputBox.Text == "0")
            {
                LegsInputBox.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                if (LegsInputBox.Text != string.Empty)
                {
                    _numberOfLegsPerSet = Convert.ToInt32(LegsInputBox.Text);
                }
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
