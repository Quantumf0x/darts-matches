using System.Windows.Controls;
using System.Windows.Input;

namespace Darts_matches
{
    public partial class HelpPage : Page, IKeyHandler
    {
        private Page _previousContext;

        public HelpPage()
        {
            InitializeComponent();
        }

        public void SetPreviousContext(Page context)
        {
            _previousContext = context;
        }

        void IKeyHandler.handleKeyEvent(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.Key == Key.Escape)
            {
                ApplicationWindow.Instance.SetFrame(_previousContext);
            }
        }
    }
}
