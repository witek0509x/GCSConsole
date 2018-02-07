using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GCSConsole
{
    // Class which handles comunication with server by API
    class APISql : Command
    {
        List<Argument> _aguments = new List<Argument>();
        public APISql()
        {
            name = "APISql";
            _aguments.Add(new APISqlHelp());
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

    abstract class ApiCommand : Argument
    {
        protected abstract string GenerateCommand(string command);
        private string SendToServer(string cmd, string ip, int port)
        {
            string respond;
            respond = TCP.Connect(ip, cmd, port);
            return respond;
        }
        protected override string Execute(string command, MissionStatus mission)
        {
            return (SendToServer(GenerateCommand(command), mission.IP, mission.port));
        }
    }

    class APISqlHelp : Argument
    {
        public APISqlHelp()
        {
            name = "-h";
        }
        protected override string Execute(string command, MissionStatus mission)
        {
            string help =
                "This command is handling communication with server thru API \n" +
                "-h                                       :   help for command\n" +
                "-c  [mission] [columns]                  :   creating new mission of server\n" +
                "-su [mission] [atribut] [times + values] :   sending update of atribut\n" +
                "-ru [mission] [atribut] [time]           :   downloading update of atribut from selected time and saving it to db\n" +
                "-gc [mission]                            :   checking if time of atribut is up to date\n";  
            return help;
        }
    }
}