using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Darts_matches
{
    interface IKeyHandler
    {
        void handleKeyEvent(KeyEventArgs keyEventArgs);
    }
}
