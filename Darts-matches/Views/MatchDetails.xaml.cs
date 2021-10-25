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

            lbl_name_player1.Text = (string)rowItemArray[5];
            lbl_name_player2.Text = (string)rowItemArray[6];

            lbl_average_per_set_player1.Text = (string)rowItemArray[12];
            lbl_average_per_set_player2.Text = (string)rowItemArray[13];

            lbl_average_per_leg_player1.Text = (string)rowItemArray[14];
            lbl_average_per_leg_player2.Text = (string)rowItemArray[15];

            lbl_average_per_turn_player1.Text = rowItemArray[10].ToString();
            lbl_average_per_turn_player2.Text = rowItemArray[11].ToString();
        }
    }
}
