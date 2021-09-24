using System.Windows;
using System.Windows.Controls;

namespace Darts_matches
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }

        static MainWindow()
        {
            Instance = new MainWindow();
        }
        private MainWindow()
        {
            InitializeComponent();
            Loaded += LoadNewWindow;
        }

        private void LoadNewWindow(object sender, RoutedEventArgs eventArguments)
        {
            SetFrame(new MainMenuPage());
        }

        public void SetFrame(Page newWindow)
        {
            frame.NavigationService.Navigate(newWindow);
        }
    }
}
