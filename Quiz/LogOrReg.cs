using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
using System.Globalization;

namespace Quiz
{

    internal class LogOrReg
    {
        public string path = "D:\\Reg.txt";
        private string _text;
        private string _login;
        private string _password;
        private DateTime _date;

        public string GetLogin()
        {
            return _login;
        }

        public string GetPassword()
        {
            return _password;
        }

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
                g.QuizMenu();
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
                sw.WriteLine();
                sw.Write(_login + " ");
                sw.Write(_password + " ");
                sw.WriteLine(_date.ToShortDateString() + "");
                sw.Close();
            }
            Program.InternalMenu();
        }
    }
}
