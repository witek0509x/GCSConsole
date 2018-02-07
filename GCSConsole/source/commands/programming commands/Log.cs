using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GCSConsole
{
    class Log : Command
    {
        List<Argument> _aguments = new List<Argument>();
        public Log()
        {
            name = "Log";
            _aguments.Add(new LogHelp());
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

    class LogHelp : Argument
    {
        public LogHelp()
        {
            name = "-h";
        }
        protected override string Execute(string command, MissionStatus mission)
        {
            string help =
                "This command is handling Log administration\n" +
                "-h                  : help\n" +
                "-sh                 : showing all logs\n" +
                "-sc                 : showing logs of one category\n" +
                "-n [category] [log] : adding new log \n";
            return help;
        }
    }
}