using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace TestMission
{
    class DB
    {
        public SQLiteConnection m_dbConnection;
        public DB(string source)
        {
            try
            {
                m_dbConnection = new SQLiteConnection("Data Source=" + source + ";Version=3;");
                m_dbConnection.Open();
            }
            catch
            {

            }
        }

        public string Query(string sql)
        {
            try
            {
                string wynik = "";
                int i = 0;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    while (reader.FieldCount > i)
                    {
                        wynik += reader[i].ToString();
                        wynik += " ";
                        i++;
                    }
                    i = 0;
                    wynik += Environment.NewLine;
                }
                return wynik;
            }
            catch
            {
                return "something went wrong";
            }
        }
        public List<float> QueryFloat(string sql)
        {
            List<float> wynik = new List<float>();
            try
            {
                int i = 0;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    while (reader.FieldCount > i)
                    {
                        wynik.Add(reader.GetFloat(i));
                        i++;
                    }
                    i = 0;
                }
                return wynik;
            }
            catch
            {
                wynik.Clear();
                wynik.Add(-1);
                return wynik;
            }
        }

        public int getsize()
        {
            int i = 0;
            SQLiteCommand command = new SQLiteCommand("get * from structure", m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                i++;
            }
            return i;
        }

        public int CountResults(string sql)
        {
                int i = 0;
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    i++;
                }
                return i;
        }

    }


}

