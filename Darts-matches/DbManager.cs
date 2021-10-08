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
        private string projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        private SqlConnection connection;

        private string state1;
        private string state2;
        public string getState1() { return state1; }
        public string getState2() { return state2; }

        private bool succes;
        public bool getSucces() { return succes; }

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

        public void testConnection()
        {
            connect();
            close();
        }

        private void setConnection()
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + projectDir.ToString() + @"\Darts-matches\DatabaseMatches.mdf';Integrated Security=True");
        }

        private void connect()
        {
            if (connection == null)
            {
                setConnection();
            }

            connection.Open();
            state1 = connection.State.ToString();
        }

        private void close()
        {
            connection.Close();
            state2 = connection.State.ToString();
        }

        public bool addToDatabase(string match_name, string empty_input_field, int leg_size, string winner, string player1, string player2, string sets_won_by, string legs_won_per_set_player1, string legs_won_per_set_player2, int average_per_3_darts_total_player1, int average_per_3_darts_total_player2, string average_per_3_darts_per_set_player1, string average_per_3_darts_per_set_player2, string average_per_3_darts_per_leg_player1, string average_per_3_darts_per_leg_player2, int number_180_player1, int number_180_player2, DateTime date)
        {
            connect();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO dbo.matches (" +
                "match_name, empty_input_field, leg_size, winner, " +
                "player1, player2, sets_won_by, legs_won_per_set_player1, " +
                "legs_won_per_set_player2, average_per_3_darts_total_player1, average_per_3_darts_total_player2, " +
                "average_per_3_darts_per_set_player1, average_per_3_darts_per_set_player2, average_per_3_darts_per_leg_player1, " +
                "average_per_3_darts_per_leg_player2, number_180_player1, number_180_player2, " +
                "datum) " +
                "VALUES ('" + match_name + "', '" + empty_input_field + "', '" + leg_size + "', '" + winner + "'," +
                " '" + player1 + "', '" + player2 + "', '" + sets_won_by + "'," +
                " '" + legs_won_per_set_player1 + "', '" + legs_won_per_set_player2 + "', '" + average_per_3_darts_total_player1 + "'," +
                " '" + average_per_3_darts_total_player2 + "', '" + average_per_3_darts_per_set_player1 + "', '" + average_per_3_darts_per_set_player2 + "'," +
                " '" + average_per_3_darts_per_leg_player1 + "', '" + average_per_3_darts_per_leg_player2 + "', '" + number_180_player1 + "'," +
                " '" + number_180_player2 + "', '" + date + "')";
            if (command.ExecuteNonQuery() == 1)
            {
                succes = true;
            }
            else
            {
                succes = false;
            }

            close();

            return succes;
        }

        public void pullFromDatabase()
        {
            
        }
    }
}
