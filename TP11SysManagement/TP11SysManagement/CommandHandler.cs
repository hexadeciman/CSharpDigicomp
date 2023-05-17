using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP11SysManagement
{

    class CommandHandler
    {
        public CommandHandler()
        {

        }

        public Tuple<int, string> handleCommand(string command)
        {
            if (command == "exit")
            {
                return new Tuple<int, string>(-1, "bye");
            }
            string[] commandElements = command.Split(' ');
            string arg = commandElements[1];
            string value = commandElements[0];

            switch (arg)
            {
                case "-k": return new Tuple<int, string>(-1, "bye");
                case "-S": return new Tuple<int, string>(0, value);
                case "-s": return new Tuple<int, string>(1, value);
                case "-r": return new Tuple<int, string>(2, value);
                default: return new Tuple<int, string>(-2, "invalid command, try again");

            }
        }
    }
}
