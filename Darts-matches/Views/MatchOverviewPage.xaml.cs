using Darts_matches.Controllers;
using Darts_matches.Views;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class MatchOverviewPage : Page
    {
        private bool _sortingOn = false;

        public MatchOverviewPage()
        {
            InitializeComponent();

            DatabaseController dbc = DatabaseController.GetInstance();
            DataTable dt = dbc.PullAllFromDatabase();
            dg_overview.ItemsSource = dt.AsDataView();

            Loaded += MatchOverviewPage_loaded;

            zoekTextBox.GotFocus += RemoveText;
            zoekTextBox.LostFocus += AddText;
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
            MatchDetails md = new MatchDetails(rowItemArray, Keyboard.Modifiers == ModifierKeys.Control);
            md.Show();
        }

        private void OpenHelpPage(object sender, RoutedEventArgs eventArguments)
        {
            HelpPage helpPage = new HelpPage();
            helpPage.SetPreviousContext(this);
            ApplicationWindow.Instance.SetFrame(helpPage);
        }

        private void RemoveText(object sender, RoutedEventArgs eventArgument)
        {
            if (zoekTextBox.Text == "Zoeken")
            {
                zoekTextBox.Text = "";
                _sortingOn = true;
            }
        }

        private void AddText(object sender, RoutedEventArgs eventArgument)
        {
            if (string.IsNullOrWhiteSpace(zoekTextBox.Text))
            {
                zoekTextBox.Text = "Zoeken";
                _sortingOn = false;
            }
        }
    }
}
