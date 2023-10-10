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
                    Environment.Exit(0);
                    break;
            }
        }
       static public void QuizMenu()
        {
            string[] array1 = {
                "Выбрать раздел викторины",
                "Посмотреть результаты своих прошлых викторин",
                "Изменить настройки",
                "Выход"
            };
            string[] array2 = { "История", "География", "Биология" };

            ConsoleMenu cm = new ConsoleMenu(array1);
            Game g = new Game();
            switch (cm.PrintMenu())
            {
                case 0:
                    ConsoleMenu cm2 = new ConsoleMenu(array2);
                    switch (cm2.PrintMenu())
                    {
                        case 0:
                            g.Games(0, 99);
                            break;
                        case 1:
                            g.Games(100, 199);
                            break;
                        case 2:
                            g.Games(200, 299);
                            break;
                    }
                    break;
                case 1:
                    LogOrReg.ViewpastQuizzes();
                    break;
                case 2:
                    LogOrReg.ChangeSetting();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
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
