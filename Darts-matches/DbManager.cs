using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Darts_matches
{
    class DbManager
    {
        private DbManager() { }

        private static DbManager _instance;

        public static DbManager getInstance()
        {
            if(_instance == null)
            {
                _instance = new DbManager();
            }
            return _instance;
        }

        public void addToDatabase()
        {

        }

        public void pullFromDatabase()
        {
            
        }
    }
}
