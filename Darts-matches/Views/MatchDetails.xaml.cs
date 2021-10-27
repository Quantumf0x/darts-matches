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

            // 7, 8, 9
            matchName.Text = matchName.Text + " " + rowItemArray[1];

            date.Text = date.Text + " " + rowItemArray[18];

            legSize.Text = legSize.Text + " " + rowItemArray[3];

            emptyInput.Text = emptyInput.Text + " " + rowItemArray[2];

            throw180b1.Text = rowItemArray[16].ToString();
            throw180b2.Text = rowItemArray[17].ToString();


            lbl_name_player1.Text = rowItemArray[5].ToString();

            lbl_average_per_set_player1.Text = DetailsFormatter(rowItemArray[12], "Set", rowItemArray[7], rowItemArray[8], 1);

            lbl_average_per_leg_player1.Text = DetailsFormatter(rowItemArray[14], "Leg", rowItemArray[7], null, 1);

            lbl_average_per_turn_player1.Text = rowItemArray[10].ToString();



            lbl_name_player2.Text = rowItemArray[6].ToString();

            lbl_average_per_set_player2.Text = DetailsFormatter(rowItemArray[13], "Set", rowItemArray[7], rowItemArray[9], 2);

            lbl_average_per_leg_player2.Text = DetailsFormatter(rowItemArray[15], "Leg", rowItemArray[7], null, 2);

            lbl_average_per_turn_player2.Text = rowItemArray[11].ToString();
        }

        public string DetailsFormatter(object inputScore, string setOrLeg, object inputWonBy, object legsWonThisSet, int player)
        {
            var inputScore_split = inputScore.ToString().Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var inputWonBy_split = inputWonBy.ToString().Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            string[] legsWonThisSet_split = new string[] { };
            if (legsWonThisSet != null) legsWonThisSet_split = legsWonThisSet.ToString().Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            string input_formatted = "";

            for (int i = 0; i < inputScore_split.Length; i++)
            {
                if (setOrLeg == "Set")
                {
                    if (Convert.ToInt32(inputWonBy_split[i]) == player)
                    {
                        input_formatted += $"{setOrLeg} {i + 1}: {inputScore_split[i]}  | wl: {legsWonThisSet_split[i]} | won\n";
                    }
                    else if (Convert.ToInt32(inputWonBy_split[i]) != player)
                    {
                        input_formatted += $"{setOrLeg} {i + 1}: {inputScore_split[i]}  | wl: {legsWonThisSet_split[i]}\n";
                    }
                }
                else if (setOrLeg == "Leg")
                {
                    input_formatted += $"{setOrLeg} {i + 1}: {inputScore_split[i]}\n";
                }
            }

            return input_formatted;
        }
    }
}
