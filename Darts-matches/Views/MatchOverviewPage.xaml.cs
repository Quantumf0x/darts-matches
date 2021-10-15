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

            Loaded += MatchOverviewPage_loaded;
        }

        private void MatchOverviewPage_loaded(object sender, RoutedEventArgs e)
        {
            dg_overview.Columns[0].Visibility = Visibility.Collapsed;
            dg_overview.Columns[3].Visibility = Visibility.Collapsed;
            dg_overview.Columns[4].Visibility = Visibility.Collapsed;
            dg_overview.Columns[7].Visibility = Visibility.Collapsed;
            dg_overview.Columns[8].Visibility = Visibility.Collapsed;
            dg_overview.Columns[9].Visibility = Visibility.Collapsed;
            dg_overview.Columns[10].Visibility = Visibility.Collapsed;
            dg_overview.Columns[11].Visibility = Visibility.Collapsed;
            dg_overview.Columns[12].Visibility = Visibility.Collapsed;
            dg_overview.Columns[13].Visibility = Visibility.Collapsed;
            dg_overview.Columns[14].Visibility = Visibility.Collapsed;
            dg_overview.Columns[15].Visibility = Visibility.Collapsed;
            dg_overview.Columns[16].Visibility = Visibility.Collapsed;
            dg_overview.Columns[17].Visibility = Visibility.Collapsed;

            dg_overview.Columns[2].DisplayIndex = 17;

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
