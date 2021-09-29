using System.Windows;
using System.Windows.Controls;

namespace Darts_matches
{
    public partial class ApplicationWindow : Window
    {
        public static ApplicationWindow Instance { get; private set; }
        
        static ApplicationWindow()
        {
            Instance = new ApplicationWindow();
        }

        private ApplicationWindow()
        {
            InitializeComponent();
            Loaded += LoadNewWindow;
        }

        private void LoadNewWindow(object sender, RoutedEventArgs eventArguments)
        {
            SetFrame(new MainMenuPage());
        }

        public void SetFrame(Page newPage)
        {
            frame.NavigationService.Navigate(newPage);
        }
    }
}
