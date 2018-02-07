using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GCSConsole
{
    // Class resposible for manualy comunicate with database on public server
    class SQL : Command
    {
        List<Argument> _aguments = new List<Argument>();
        public SQL()
        {
            name = "SQL";
            _aguments.Add(new SqlHelp());
            _aguments.Add(new SqlList());
            for (int i = 0; i < _aguments.Count() - 1; i++)
            {
                _aguments[i].SetParent(_aguments[i + 1]);
            }
        }
        protected override string Execute(string command, MissionStatus mission)
        {
            return _aguments[0].Run(command, mission);
        }
    }


    // SQL Argument which show help for command
    class SqlHelp : Argument
    {
        public SqlHelp()
        {
            name = "-h";
        }
        protected override string Execute(string command, MissionStatus mission)
        {
            return "This command is sending SQL command to server and returning it's respond \n" +
                "-h           : help\n" +
                "-l           : list of sql commands with short description \n" +
                "-s [command] : sending command";
        }
    }
    // SQL Argument which shows list of sql commands and how to use them
    class SqlList : Argument
    {
        public SqlList()
        {
            name = "-l";
        }
        protected override string Execute(string command, MissionStatus mission)
        {
            return "Select \nCreate";
        }
    }
}