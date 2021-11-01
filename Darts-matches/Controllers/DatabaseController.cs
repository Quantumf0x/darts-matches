using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Windows;

namespace Darts_matches.Controllers
{
    public class DatabaseController
    {
        private string _projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        private SqlConnection _connection;

        private string _testConnectionOpen;
        private string _testConnectionClose;
        public string GetTestConnectionOpen() { return _testConnectionOpen; }
        public string GetTestConnectionClose() { return _testConnectionClose; }

        private bool _succes;
        public bool GetSucces() { return _succes; }

        private DatabaseController() { }

        private static DatabaseController _instance;

        public static DatabaseController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseController();
            }
            return _instance;
        }

        public void KillInstance()
        {
            _instance = null;
        }

        public void TestConnection()
        {
            Connect();
            Close();
        }

        private void SetConnection()
        {
            Trace.WriteLine(Environment.CurrentDirectory);
            string databasePath = Environment.CurrentDirectory + "\\DatabaseMatches.mdf";
            string databaseLogPath = Environment.CurrentDirectory + "\\DatabaseMatches_log.ldf";


            // search for exsisting database
            if (!File.Exists(databasePath))
            {
                SetupDatabase(databasePath, databaseLogPath);

                var process = Process.GetCurrentProcess();
                string path = process.MainModule.FileName;

                ProcessStartInfo startInfo = new ProcessStartInfo(path);
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;
                Process.Start(startInfo);

                process.Kill();

            }
            _connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + Environment.CurrentDirectory + @"\DatabaseMatches.mdf';Integrated Security=False;");

        }

        private void SetupDatabase(string databasePath, string databaseLogPath)
        {
            // create database
            _connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=master;Integrated security=False;");
            string createDatabaseString =
                "DROP DATABASE DatabaseMatches;" +
                "CREATE DATABASE DatabaseMatches ON PRIMARY " +
                "(NAME = DatabaseMatches_Data, " +
                "FILENAME = '" + databasePath + "', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
                "LOG ON (NAME = DatabaseMatches_Log, " +
                "FILENAME = '" + databaseLogPath + "', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseString, _connection);
            try
            {
                _connection.Open();
                createDatabaseCommand.ExecuteNonQuery();
                Trace.WriteLine("Database created successfully!");
            }
            catch (System.Exception ex)
            {
                if (ex.ToString().Contains("Unable to open the physical file"))
                {
                    Trace.WriteLine("Database creation succeeded! Previous bugging file deleted " + ex.ToString());
                }
                else
                {
                    Trace.WriteLine("Database creation failed! " + ex.ToString());
                }
            }
            finally
            {
                Trace.WriteLine(_connection.Database);
                _connection.ChangeDatabase("DatabaseMatches");
                Trace.WriteLine(_connection.Database);
                SetupDatabaseTables();
            }
        }

        private void SetupDatabaseTables()
        {
            string createTableString =
                @"
                CREATE TABLE dbo.matches (
                Id INT IDENTITY(1, 1) NOT NULL,
                match_name TEXT NOT NULL,
                empty_input_field TEXT NULL,
                leg_size INT NOT NULL,
                winner TEXT NOT NULL,
                player1 TEXT NOT NULL,
                player2 TEXT NOT NULL,
                sets_won_by TEXT NOT NULL,
                legs_won_per_set_player1 TEXT NOT NULL,
                legs_won_per_set_player2 TEXT NOT NULL,
                average_per_3_darts_total_player1 INT NOT NULL,
                average_per_3_darts_total_player2 INT NOT NULL,
                average_per_3_darts_per_set_player1 TEXT NOT NULL,
                average_per_3_darts_per_set_player2 TEXT NOT NULL,
                average_per_3_darts_per_leg_player1 TEXT NOT NULL,
                average_per_3_darts_per_leg_player2 TEXT NOT NULL,
                number_180_player1 INT NOT NULL,
                number_180_player2 INT NOT NULL,
                datum DATE NOT NULL,
                PRIMARY KEY CLUSTERED(Id ASC)
            );
            ";
            SqlCommand createTableCommand = new SqlCommand(createTableString, _connection);

            try
            {
                createTableCommand.ExecuteNonQuery();
                Trace.WriteLine("Database table created successfully!");
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("Database table creation failed! " + ex.ToString());

            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    ClearTables();
                    _connection.Close();
                    _connection = null;
                }
            }
        }

        private void ClearTables()
        {
            string createTableString = "TRUNCATE TABLE dbo.matches";

            SqlCommand createTableCommand = new SqlCommand(createTableString, _connection);

            try
            {
                createTableCommand.ExecuteNonQuery();
                Trace.WriteLine("Database table cleared successfully!");
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("Database table clear failed! " + ex.ToString());

            }
        }

        private void Connect()
        {
            if (_connection == null)
            {
                SetConnection();
            }

            _connection.Open();
        }

        private void Close()
        {
            _connection.Close();
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

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    _succes = true;
                }
                else
                {
                    _succes = false;
                }
            }
            catch (Exception err)
            {
                Trace.WriteLine("ERR: " + err);
            }

            Close();

            return _succes;
        }

        public DataTable PullAllFromDatabase()
        {
            Connect();
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.matches;";

            SqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            Close();

            return dataTable;
        }

        public object[] PullOneFromDatabase(int id)
        {
            Connect();
            SqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM dbo.matches WHERE id = " + id + ";";

            SqlDataReader reader = command.ExecuteReader();

            object[] data = new object[19];
            while (reader.Read())
            {
                reader.GetValues(data);
            }

            reader.Close();

            Close();

            return data;
        }
    }
}