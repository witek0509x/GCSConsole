using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MissionStatus status = new MissionStatus();
            ChainGenerator generator = new ChainGenerator();
            while(true)
            {
                string command = Console.ReadLine();
                Console.WriteLine(generator.ExecuteCommand(command, status));
            }
            
        }
    }
}
