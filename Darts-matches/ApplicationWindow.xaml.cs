using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class ApplicationWindow : Window
    {
        public static ApplicationWindow Instance { get; private set; }

        private Page Context;

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
            Context = newPage;
        }

        private void UserControlOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Window window = GetWindow(this);
            window.KeyDown += HandleKeyPress;
        }

        private void HandleKeyPress(object sender, KeyEventArgs keyEventArgs)
        {
            if (Context is IKeyHandler) ((IKeyHandler)Context).handleKeyEvent(keyEventArgs);
        }
    }
}
