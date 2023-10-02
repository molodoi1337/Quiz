using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Quiz
{
    internal class Program
    {
        static public void InternalMenu()
        {
            string[] menu = { "Войти", "Зарегистрироваться", "Выйти" };
            LogOrReg lor = new LogOrReg();
            ConsoleMenu cm = new ConsoleMenu(menu);

            switch (cm.PrintMenu())
            {
                case 0:
                    lor.Enter();
                    break;
                case 1:
                    lor.Registration();
                    break;
                case 3:
                    return;
            }
        }
        static void Main(string[] args)
        {
            
            using (FileStream fs = File.Open("D:\\Reg.txt", FileMode.OpenOrCreate))
                fs.Close();

            InternalMenu();

            




            Console.ReadKey();
        }
    }
}
