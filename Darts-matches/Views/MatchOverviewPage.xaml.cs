using Darts_matches.Controllers;
using Darts_matches.Views;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System;
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

            searchMatchName.GotFocus += RemoveText;
            searchMatchName.LostFocus += AddText;
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

            Thread _sortingThread = new Thread(SortData);
            _sortingThread.Start();
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
            if (searchMatchName.Text == "Zoeken")
            {
                searchMatchName.Text = "";
                _sortingOn = true;
            }
        }

        private void AddText(object sender, RoutedEventArgs eventArgument)
        {
            if (string.IsNullOrWhiteSpace(searchMatchName.Text))
            {
                searchMatchName.Text = "Zoeken";
                _sortingOn = false;
            }
        }

        private void SortData()
        {
            DatabaseController dbc = DatabaseController.GetInstance();
            DataTable dt = dbc.PullAllFromDatabase();

            bool reset = true;

            while (true)
            {
                reset = true;

                // searchPlayerName.Text

                bool matchNameSearch = searchMatchName.Text != "";
                bool playerNameSearch = searchPlayerName.Text != "";
                bool dateSearch = _datePicker1.SelectedDate != null && _datePicker1.SelectedDate != null;

                if (matchNameSearch && !playerNameSearch && !dateSearch)
                {
                    // only search match name
                    SortDataMatchName();
                }
                else if (!matchNameSearch && !playerNameSearch && dateSearch)
                {
                    // only search date
                    SortDataDate();
                }
                else if (!matchNameSearch && playerNameSearch && !dateSearch)
                {
                    SortDataPlayerName();
                }
                else if (matchNameSearch && !playerNameSearch && dateSearch)
                {
                    // search match name and date
                    SortDateMatchNameAndDate();
                }
                else if (matchNameSearch && playerNameSearch && !dateSearch)
                {
                    // search match name and playername
                    SortMatchNameAndPlayerName();
                }
                else if (!matchNameSearch && playerNameSearch && dateSearch)
                {
                    // search playername and date
                    SortPlayerNameAndDate();
                }
                else if (matchNameSearch && playerNameSearch && dateSearch)
                {
                    // search match name and date
                    SortAll();
                }

                Thread.Sleep(100);
            }
        }

        private void SortDataMatchName()
        {
            Dispatcher.Invoke(() =>
            {
                if (searchMatchName.Text != "Zoeken" && searchMatchName.Text != "" && searchMatchName.Text != null)
                {
                    int index = 0;
                    foreach (DataRowView row in dg_overview.Items)
                    {
                        if (row.Row[1].ToString().Contains(searchMatchName.Text))
                        {
                            Trace.WriteLine("test1");
                            var rowToHide = dg_overview.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                            rowToHide.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            Trace.WriteLine("test2");
                            Trace.WriteLine(row.Row[0]);
                            var rowToHide = dg_overview.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                            rowToHide.Visibility = Visibility.Collapsed;
                        }
                        index++;
                    }
                    reset = false;
                }
            });
        }

        private void SortDataPlayerName()
        {
            Dispatcher.Invoke(() =>
            {
                if (searchMatchName.Text != "Zoeken" && searchMatchName.Text != "" && searchMatchName.Text != null)
                {
                    int index = 0;
                    foreach (DataRowView row in dg_overview.Items)
                    {
                        if (row.Row[1].ToString().Contains(searchMatchName.Text))
                        {
                            Trace.WriteLine("test1");
                            var rowToHide = dg_overview.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                            rowToHide.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            Trace.WriteLine("test2");
                            Trace.WriteLine(row.Row[0]);
                            var rowToHide = dg_overview.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                            rowToHide.Visibility = Visibility.Collapsed;
                        }
                        index++;
                    }
                    reset = false;
                }
            });
        }

        private void SortDataDate()
        {
            DateTime _date1 = DateTime.Now;
            DateTime _date2 = DateTime.Now;

            Dispatcher.Invoke(() =>
            {
                if (_datePicker1.SelectedDate != null && _datePicker2.SelectedDate != null)
                {
                    if (_datePicker1.SelectedDate.Value < _datePicker2.SelectedDate.Value)
                    {
                        _date1 = _datePicker1.SelectedDate.Value;
                        _date2 = _datePicker2.SelectedDate.Value;
                    }
                    else
                    {
                        _date1 = _datePicker2.SelectedDate.Value;
                        _date2 = _datePicker1.SelectedDate.Value;
                    }

                    int index = 0;
                    foreach (DataRowView row in dg_overview.Items)
                    {
                        if (Convert.ToDateTime(row.Row[18]) < _date1 || Convert.ToDateTime(row.Row[18]) > _date2)
                        {
                            Trace.WriteLine(row.Row[0]);
                            var rowToHide = dg_overview.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                            rowToHide.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            Trace.WriteLine(row.Row[0]);
                            var rowToHide = dg_overview.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                            rowToHide.Visibility = Visibility.Visible;
                        }
                        index++;
                    }

                    reset = false;
                }
            });

            Dispatcher.Invoke(() =>
            {
                if (reset)
                {
                    int index = 0;
                    foreach (DataRowView row in dg_overview.Items)
                    {
                        Trace.WriteLine(row.Row[0]);
                        var rowToHide = dg_overview.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                        rowToHide.Visibility = Visibility.Visible;

                        index++;
                    }
                }
            });
        }

        private void SortDateMatchNameAndDate()
        {

        }

        private void SortMatchNameAndPlayerName()
        {

        }

        private void SortPlayerNameAndDate()
        {

        }

        private void SortAll()
        {

        }
    }
}
