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

        private void SortData()
        {
            DatabaseController dbc = DatabaseController.GetInstance();
            DataTable dt = dbc.PullAllFromDatabase();

            DateTime _date1 = DateTime.Now;
            DateTime _date2 = DateTime.Now;

            while (true)
            {
                //date
                {
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
                            Trace.WriteLine(_date1);
                            Trace.WriteLine(_date2);
                        }
                    });

                    List<int> correctDates = new List<int>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToDateTime(dt.Rows[i][18]) >= _date1 && Convert.ToDateTime(dt.Rows[i][18]) <= _date2)
                        {
                            correctDates.Add(Convert.ToInt32(dt.Rows[i][0]));
                        }
                    }

                    Dispatcher.Invoke(() =>
                    {
                        if (_datePicker1.SelectedDate != null && _datePicker2.SelectedDate != null)
                        {
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
                        }
                        else
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

                Thread.Sleep(100);
            }
        }
    }
}
