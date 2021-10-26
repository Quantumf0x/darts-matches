﻿using Darts_matches.Controllers;
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
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Darts_matches
{
    public partial class MatchOverviewPage : Page
    {
        private bool _sortingOn = false;
        ObservableCollection<object> sourceList;

        public MatchOverviewPage()
        {
            InitializeComponent();

            DatabaseController dbc = DatabaseController.GetInstance();
            DataTable dt = dbc.PullAllFromDatabase();

            sourceList = new ObservableCollection<object>();

            foreach (var item in dt.AsDataView())
            {
                sourceList.Add(item);
            }

            dg_overview.ItemsSource = sourceList;

            Loaded += MatchOverviewPage_loaded;
        }

        private void MatchOverviewPage_loaded(object sender, RoutedEventArgs e)
        {
            fixCollumns();
        }

        private void fixCollumns()
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
            try
            {
                DataRowView selectedRow = (DataRowView)dg_overview.SelectedItems[0];
                object[] rowItemArray = selectedRow.Row.ItemArray;
                MatchDetails md = new MatchDetails(rowItemArray, Keyboard.Modifiers == ModifierKeys.Control);
                md.Show();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        private void OpenHelpPage(object sender, RoutedEventArgs eventArguments)
        {
            HelpPage helpPage = new HelpPage();
            helpPage.SetPreviousContext(this);
            ApplicationWindow.Instance.SetFrame(helpPage);
        }

        private void searchMatchNameChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            Thread _sortingThread = new Thread(SortData);
            _sortingThread.Start();
        }

        private void searchPlayerNameChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            Thread _sortingThread = new Thread(SortData);
            _sortingThread.Start();
        }

        private void _datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_datePicker2.SelectedDate != null)
            {
                Thread _sortingThread = new Thread(SortData);
                _sortingThread.Start();
            }
        }

        private void _datePicker2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_datePicker1.SelectedDate != null)
            {
                Thread _sortingThread = new Thread(SortData);
                _sortingThread.Start();
            }
        }


        private void SortData()
        {
            DateTime _date1 = DateTime.Now;
            DateTime _date2 = DateTime.Now;

            Dispatcher.Invoke(() =>
            {
                bool matchNameSearch = searchMatchName.Text != "";
                bool playerNameSearch = searchPlayerName.Text != "";
                bool dateSearch = _datePicker1.SelectedDate != null && _datePicker1.SelectedDate != null;

                string matchNameFilter = searchMatchName.Text;
                string playerNameFilter = searchPlayerName.Text;

                if (_datePicker1.SelectedDate != null && _datePicker2.SelectedDate != null)
                {
                    _date1 = _datePicker1.SelectedDate.Value;
                    _date2 = _datePicker2.SelectedDate.Value;
                }

                ListCollectionView sortableCollection = new ListCollectionView(sourceList);
                sortableCollection.Filter = (e) =>
                {
                    DataRowView drv = e as DataRowView;

                    object[] row = drv.Row.ItemArray;
                    Trace.WriteLine(row);

                    string col_matchName = row[1].ToString();
                    string col_playerName1 = row[5].ToString();
                    string col_playerName2 = row[6].ToString();
                    DateTime col_date = (DateTime)row[18];

                    if (
                    (col_matchName.Contains(matchNameFilter) || !matchNameSearch) && 
                    (col_playerName1.Contains(playerNameFilter) || col_playerName2.Contains(playerNameFilter) || !playerNameSearch) &&
                    ((col_date > _date1 && col_date < _date2) || !dateSearch))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                };

                dg_overview.ItemsSource = sortableCollection;
                dg_overview.Items.Refresh();

                if (dg_overview.Items.Count > 0)
                {
                    fixCollumns();
                }
            });
        }
    }
}
