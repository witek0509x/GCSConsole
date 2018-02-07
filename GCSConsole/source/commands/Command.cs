
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GCSConsole
{
    abstract class Command
    {
        Command _next;
        
        protected string name;
        protected abstract string Execute(string command, MissionStatus mission);
        public string Run(string command, MissionStatus mission)
        {
            var splited = command.Split();

            if (splited[0].ToLower() == name.ToLower()) return Execute(command, mission);
            return _next == null ? "No such command. Type list for list of commands." : _next.Run(command, mission);
        }
        public void SetParent(Command next)
        {
            _next = next;
        }
    }
    abstract class Argument
    {
        Argument _next;
        protected string name;
        protected abstract string Execute(string command, MissionStatus mission);
        public string Run(string command, MissionStatus mission)
        {
            var splited = command.Split();
            if (splited.Length == 1)
            {
                return name == "-h" ? Execute(command, mission) : _next.Run(command, mission);
            }
            if (splited[1].ToLower() == name.ToLower()) return Execute(command, mission);
            return _next == null ? "No such argument. Type -h to find help." : _next.Run(command, mission);
        }
        public void SetParent(Argument next)
        {
            _next = next;
        }
    }

    class ChainGenerator
    {
        List<Command> commands = new List<Command>();
        public ChainGenerator()
        {
            commands.Add(new SQL());
            commands.Add(new APISql());
            commands.Add(new Log());
            commands.Add(new List());
            for (int i = 0; i < commands.Count() - 1; i++)
            {
                commands[i].SetParent(commands[i + 1]);
            }
        }
        public string ExecuteCommand(string command, MissionStatus mission)
        {
            return commands[0].Run(command, mission);
        }
    }

}