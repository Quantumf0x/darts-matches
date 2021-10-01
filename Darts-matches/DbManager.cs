using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace Darts_matches
{
    public class DbManager
    {
        private string state;
        public string getState() { return state; }

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

        private void connect()
        {
            string projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + projectDir.ToString() + @"\Darts-matches\DatabaseMatches.mdf';Integrated Security=True"))
            {
                connection.Open();
                state = connection.State.ToString();
            }
        }

        public void addToDatabase()
        {
            connect();
        }

        public void pullFromDatabase()
        {
            
        }
    }
}
