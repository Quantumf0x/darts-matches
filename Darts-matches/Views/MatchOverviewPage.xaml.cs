using Darts_matches.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Darts_matches
{
    public partial class MatchOverviewPage : Page
    {
        public MatchOverviewPage()
        {
            InitializeComponent();

            DatabaseController dbc = DatabaseController.GetInstance();
            DataTable dt = dbc.PullAllFromDatabase();
            dg_overview.ItemsSource = dt.AsDataView();
        }

        private void btn_select_match_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)dg_overview.SelectedItems[0];

            object[] rowItemArray = selectedRow.Row.ItemArray;

            string showRow = "";
            foreach (var item in rowItemArray)
            {
                showRow += item.ToString() + "\n";
            }

            MessageBox.Show(showRow);
        }
    }
}
