using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Darts_matches.Views
{
    /// <summary>
    /// Interaction logic for MatchDetails.xaml
    /// </summary>
    public partial class MatchDetails : Window
    {
        public MatchDetails(object[] rowItemArray, bool bg)
        {
            InitializeComponent();

            if (bg) gbg.Opacity = 0.5;

            lbl_name_player1.Text = rowItemArray[5].ToString();
            lbl_name_player2.Text = rowItemArray[6].ToString();


            lbl_average_per_set_player1.Text = DetailsFormatter(rowItemArray[12], "Set");
            lbl_average_per_set_player2.Text = DetailsFormatter(rowItemArray[13], "Set");

            lbl_average_per_leg_player1.Text = DetailsFormatter(rowItemArray[14], "Leg");
            lbl_average_per_leg_player2.Text = DetailsFormatter(rowItemArray[15], "Leg");

            lbl_average_per_turn_player1.Text = rowItemArray[10].ToString();
            lbl_average_per_turn_player2.Text = rowItemArray[11].ToString();
        }

        public string DetailsFormatter(object input, string setOrLeg)
        {
            var input_split = input.ToString().Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
            string input_formatted = "";

            for (int i = 0; i < input_split.Length; i++)
            {
                input_formatted += $"{setOrLeg} {i + 1}: {input_split[i]}\n";
            }

            return input_formatted;
        }
    }
}
