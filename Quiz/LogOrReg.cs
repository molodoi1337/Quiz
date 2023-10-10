using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Quiz
{

    internal class LogOrReg : Program
    {
        public static string path = "D:\\Reg.txt";
        private string _text;
        private static string _login;
        private static string _password;
        private static DateTime _date;

        Game g = new Game();

        public void Enter()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Console.Clear();

                _text = sr.ReadToEnd();

                Console.WriteLine("Введите логин: ");
                _login = Console.ReadLine();

                if (!_text.Contains(_login) || _login.Contains("") && _login.Length < 1)
                {
                    Console.WriteLine("Логин не найден");
                    while (!_text.Contains(_login) || _login.Contains("") && _login.Length < 1)
                    {
                        Console.WriteLine("Введите логин:");
                        _login = Console.ReadLine();
                    }
                }

                Console.WriteLine("Введите пароль: ");
                _password = Console.ReadLine();

                if (!_text.Contains(_login + " " + _password))
                    while (!_text.Contains(_login + " " + _password))
                    {
                        Console.WriteLine("Пароль неверный!");
                        _password = Console.ReadLine();
                    }
                sr.Close();
                Program.QuizMenu();
            }
        }

        public void Registration()
        {
            Console.Clear();

            Console.WriteLine("Введите логин:");
            _login = Console.ReadLine();

            using (StreamReader sr = new StreamReader(path))
            {
                _text = sr.ReadToEnd();

                if (_text.Contains(_login))
                {
                    Console.WriteLine("Такой логин уже существует");
                    while (_text.Contains(_login))
                    {
                        Console.WriteLine("Введите логин:");
                        _login = Console.ReadLine();
                    }
                }
                sr.Close();
            }

            Console.WriteLine("Введите пароль:");
            _password = Console.ReadLine();
            if (_password.Contains(" "))
            {
                while (_password.Contains(" "))
                {
                    Console.WriteLine("Введите пароль без пробелов:");
                    _password = Console.ReadLine();
                }
            }

            Console.WriteLine("Введите свою дату рождения(дд.мм.гггг)");
            string date = Console.ReadLine();
            while (!DateTime.TryParseExact(date, "dd.MM.yyyy", null, DateTimeStyles.None, out _date))
            {
                Console.WriteLine("Введите свою дату рождения(дд.мм.гггг)");
                date = Console.ReadLine();
            }
            _date = DateTime.Parse(date);

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(_login + " ");
                sw.Write(_password + " ");
                sw.Write(_date.ToShortDateString() + "\n");
                sw.Close();
            }
            Program.InternalMenu();
        }
        static public void WriteFile(string s)
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(_login))
                {
                    // Добавляем данные в конец строки
                    lines[i] += " ";
                    lines[i] += s;
                    lines[i] += " ";
                    lines[i] += Game.trueAnswers;
                }
            }

            File.WriteAllLines(path, lines);
        }
        static public void ChangeSetting()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = sr.ReadLine();
                

                while (!line.Contains(_login))
                {
                    line = sr.ReadLine();
                }
                sr.Close();

                Console.WriteLine("Введите новый пароль");
                string newPassword = Console.ReadLine();

                string fileText = File.ReadAllText(path);

                // Заменяем все вхождения старой подстроки на новую
                string Password = fileText.Replace(_password, newPassword);

                // Записываем измененный текст обратно в файл
                File.WriteAllText(path, Password);    
            }
        }

    static public void ViewpastQuizzes()
    {
        Console.Clear();

        using (StreamReader sr = new StreamReader("D:\\Reg.txt"))
        {
            Console.Clear();
            string str = sr.ReadLine();

            while (!str.Contains(_login))
            {
                str = sr.ReadLine();
            }

            int start = _login.Length + _password.Length + 13;
            for (int i = start; i < str.Length; i++)
            {
                Console.Write(str[i]);
            }

            sr.Close();
            Console.ReadKey();
            Program.QuizMenu();
        }
    }
}
}
