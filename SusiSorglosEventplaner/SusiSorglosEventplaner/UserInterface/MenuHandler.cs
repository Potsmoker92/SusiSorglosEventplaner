using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SusiSorglosEventplaner
{
    class MenuHandler
    {
        public int selected;
        public String[] options;

        public MenuHandler(string[] args)
        {
            options = args;
            selected = 0;
        }

        public int showOptions()
        {
            int tempCounter = 1;

            Console.Clear();
            
            if(options.Length < 1)
            {
                throw new Exception("invalid arguments");
            }
            
                Console.WriteLine(options[0]);
            
            while (tempCounter < options.Length)
            {
                if( tempCounter == selected )
                {
                    Console.Write("{0,10} [*]", options[tempCounter]);
                }
                else
                {

                    Console.Write("{0,10} [ ]", options[tempCounter]);
                }
                Console.WriteLine("\n");
                tempCounter++;
            }
            return handleKeyInput();
        }

        public int handleKeyInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;

            if (key == ConsoleKey.Enter)
            {
                return selected;

            }
            if (key == ConsoleKey.DownArrow)
            {
                    if (selected < options.Length-1)
                    {
                        selected++;
                    }
                    return showOptions();
            }
            if (key == ConsoleKey.UpArrow)
            {
                if (selected > 1)
                {
                    selected--;
                }
                return showOptions();
            }
            else
            {
                selected = -1;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID KEY INPUT");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("allowed keys: arrow-up, arrow-down, enter");
                return -1;
            }
            
        }
    }
}
