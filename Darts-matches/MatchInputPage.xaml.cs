using System.Windows;
using System.Windows.Controls;

namespace Darts_matches
{
    public partial class MatchInputPage : Page
    {
        public MatchInputPage()
        {
            InitializeComponent();
        }
        
        private void PlayerInputPage(object sender, RoutedEventArgs eventArguments)
        {
            MainWindow.Instance.SetFrame(new PlayerInputPage());
        }
    }
}
