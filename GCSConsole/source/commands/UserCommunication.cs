using System.Collections.Generic;
using System.Linq;


namespace GCSConsole
{
    class List : Command
    {
        List<Argument> _aguments = new List<Argument>();
        public List()
        {
            name = "List";
            _aguments.Add(new ListHelp());
            _aguments.Add(new ListCategory());
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


    class ListHelp : Argument
    {
        public ListHelp()
        {
            name = "-h";
        }
        protected override string Execute(string command, MissionStatus mission)
        {
            string help = "To look for specyfic category of commands type -c \n" +
                "APISql \n" +
                "SQL \n" +
                "Log \n";
            return help;
        }
    }


    class ListCategory : Argument
    {
        public ListCategory()
        {
            name = "-c";
        }
        protected override string Execute(string command, MissionStatus mission)
        {
            var splited = command.Split(' ');
            string res;
            if (splited.Length < 3) return "Wrong syntax. Type list -c [category].";
            if (splited[2] == "programming")
            {
                res = "APISql \n" +
                "SQL \n" +
                "Log \n";
            }
            else if (splited[2] ==  "engineer")
            {
                res = "n/a";
            }
            else if (splited[2] == "scientist")
            {
                res = "n/a";
            }
            else
            {
                res = "there is no ctegory " + splited[2] + " type programming, engineer or scientist";
            }
            return res;
        }
    }

}