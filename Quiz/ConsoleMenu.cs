using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class ConsoleMenu
    {
        private string[] menuItems;
        private int counter = 0;

        public ConsoleMenu(string[] menuItems)
        {
            this.menuItems = menuItems;
        }

        public int PrintMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.WriteLine(menuItems[i]);
                }

                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        return counter;
                    case ConsoleKey.UpArrow:
                        counter--;
                        if (counter == -1)
                            counter = menuItems.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        counter++;
                        if (counter == menuItems.Length)
                            counter = 0;
                        break;
                }
            }
            while (true);
        }
    }
}
