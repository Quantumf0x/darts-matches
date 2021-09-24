using System.Windows;
using System.Windows.Controls;

namespace Darts_matches
{
    public partial class MatchScoresInputPage : Page
    {
        public MatchScoresInputPage()
        {
            InitializeComponent();
        }
        private void MatchResultsPage(object sender, RoutedEventArgs eventArguments)
        {
            MainWindow.Instance.SetFrame(new MatchResultsPage());
        }
    }
}
