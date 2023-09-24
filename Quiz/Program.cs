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
        static void Main(string[] args)
        {
            string[] menu = { "Войти","Зарегистрироваться", "Выйти" };
             ConsoleMenu cm = new ConsoleMenu(menu);
             LogOrReg lor = new LogOrReg();


             using (FileStream fs = File.Open(lor.path,FileMode.OpenOrCreate));

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




            Console.ReadKey();
        }
    }
}
