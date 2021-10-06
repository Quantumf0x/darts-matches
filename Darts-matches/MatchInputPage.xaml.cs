using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class MatchInputPage : Page, IKeyHandler
    {
        public MatchInputPage()
        {
            InitializeComponent();
        }

        private void btn_next_Click(object sender, RoutedEventArgs eventArguments)
        {
            ApplicationWindow.Instance.SetFrame(new PlayerInputPage());
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
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
