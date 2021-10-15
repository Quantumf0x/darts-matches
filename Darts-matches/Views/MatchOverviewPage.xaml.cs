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
            for (int i = 0; i < rowItemArray.Length; i++)
            {
                showRow += dg_overview.Columns[i].Header + ":\t\t" + rowItemArray[i].ToString() + "\n";
            }

            MessageBox.Show(showRow);
        }

        private void OpenHelpPage(object sender, RoutedEventArgs eventArguments)
        {
            HelpPage helpPage = new HelpPage();
            helpPage.SetPreviousContext(this);
            ApplicationWindow.Instance.SetFrame(helpPage);
        }
    }
}
