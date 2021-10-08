using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;

namespace Darts_matches.Controllers
{
    public class DatabaseController
    {
        private string _projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        private SqlConnection _connection;

        private string _state1;
        private string _state2;
        public string GetState1() { return _state1; }
        public string GetState2() { return _state2; }

        private bool _succes;
        public bool GetSucces() { return _succes; }

        private DatabaseController() { }

        private static DatabaseController _instance;

        public static DatabaseController GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DatabaseController();
            }
            return _instance;
        }

        public void TestConnection()
        {
            Connect();
            Close();
        }

        private void SetConnection()
        {
            _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + _projectDir.ToString() + @"\Darts-matches\DatabaseMatches.mdf';Integrated Security=True");
        }

        private void Connect()
        {
            if (_connection == null)
            {
                SetConnection();
            }

            _connection.Open();
            _state1 = _connection.State.ToString();
        }

        private void Close()
        {
            _connection.Close();
            _state2 = _connection.State.ToString();
        }

        public bool AddToDatabase(string match_name, string empty_input_field, int leg_size, string winner, string player1, string player2, string sets_won_by, string legs_won_per_set_player1, string legs_won_per_set_player2, int average_per_3_darts_total_player1, int average_per_3_darts_total_player2, string average_per_3_darts_per_set_player1, string average_per_3_darts_per_set_player2, string average_per_3_darts_per_leg_player1, string average_per_3_darts_per_leg_player2, int number_180_player1, int number_180_player2, DateTime date)
        {
            Connect();

            SqlCommand command = _connection.CreateCommand();
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
                _succes = true;
            }
            else
            {
                _succes = false;
            }

            Close();

            return _succes;
        }

        public void PullFromDatabase()
        {

        }
    }
}
