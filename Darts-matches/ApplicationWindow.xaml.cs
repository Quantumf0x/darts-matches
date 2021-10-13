using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class ApplicationWindow : Window
    {
        public static ApplicationWindow Instance { get; private set; }

        private Page _context;

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
            _context = newPage;
        }

        private void UserControlOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Window window = GetWindow(this);
            window.KeyDown += HandleKeyPress;
        }

        private void HandleKeyPress(object sender, KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.Key)
            {
                case Key.F1:
                case Key.H:
                    if(!(_context is HelpPage))
                    {
                        HelpPage helpPage = new HelpPage();
                        helpPage.SetPreviousContext(_context);
                        SetFrame(helpPage);
                    }
                    break;
                case Key.F2:
                case Key.M:
                    if(!(_context is MainMenuPage))
                    {
                        SetFrame(new MainMenuPage());
                    }
                    break;
                default:
                    if (_context is IKeyHandler)
                    {
                        ((IKeyHandler)_context).handleKeyEvent(keyEventArgs);
                    }
                    break;
            }
        }
    }
}
