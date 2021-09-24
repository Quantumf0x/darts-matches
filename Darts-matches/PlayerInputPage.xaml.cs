using System.Windows;
using System.Windows.Controls;

namespace Darts_matches
{
    public partial class PlayerInputPage : Page
    {
        public PlayerInputPage()
        {
            InitializeComponent();
        }
        private void MatchScoresInputPage(object sender, RoutedEventArgs eventArguments)
        {
            MainWindow.Instance.SetFrame(new MatchScoresInputPage());
        }
    }
}
