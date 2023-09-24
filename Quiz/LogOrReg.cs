using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Quiz
{

    internal class LogOrReg
    {
        public string path = "D:\\Reg.txt";
        private string _text;
        private string _login;
        private string _password;
        private DateTime _date;


        public void Enter()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Console.Clear();
                Console.WriteLine("Введите свой логин");
                _login = Console.ReadLine();

                _text = sr.ReadToEnd();


                if (_text.Contains(_login))
                {
                    Console.WriteLine("Введите свой пароль");
                    _password = Console.ReadLine();

                    


                }
                else
                    Console.WriteLine("Неправильный логин или пароль");
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
                    Console.WriteLine("Введите логин:");
                    _login = Console.ReadLine();
                }
            }

            Console.WriteLine("Введите пароль:");
            _password = Console.ReadLine();

            try
            {
                Console.WriteLine("Введите дату рождения:");
                _date = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            using (StreamWriter sr = new StreamWriter(path, true))
            {
                sr.WriteLine(_login);
                sr.WriteLine(_password);
                sr.WriteLine(_date);
            }
        }




    }
}
