﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
using System.Text.RegularExpressions;


namespace Quiz
{
    internal class Game : Program
    {
        static public int trueAnswers = 0;//Кол правильных ответов
        public string path_Reg = "D:\\Reg.txt";
        public string path_Questions = "D:\\questions.txt";

        public void Games(int first_index, int last_index)
        {
            using (StreamReader sr = new StreamReader(path_Questions))
            {
                string t = sr.ReadToEnd();
                string[] text = t.Split('\r');
                //z,x,c - индексы вариантов ответов.n - индекс вопроса.a - индекс ответа
                int a = first_index, n = a + 1, z = n + 1, x = z + 1, c = x + 1;

                string[] array; //массив для вопросов

                do
                {
                    array = new string[3];
                    array[0] = text[z];
                    array[1] = text[x];
                    array[2] = text[c];

                    ConsoleMenu cm = new ConsoleMenu(array);
                    if (cm.PrintMenu(text[n]) == int.Parse(text[a]))
                    {
                        trueAnswers++;
                    }

                    array = null;

                    a += 5; n += 5; z += 5; x += 5; c += 5;
                } while (c - 5 < last_index);
                sr.Close();
            }
            string temp = "";
            if (last_index == 99) temp = "История";
            if (last_index == 199) temp = "География";
            if (last_index == 299) temp = "Биология";
            LogOrReg.WriteFile(temp);
            Summarize();
            Program.QuizMenu();
        }
        /*public void Top_20()
        {
            string path = "D:\\Top.txt";

            using (StreamReader sr = new StreamReader(path_Reg))
            {
                string inputString = sr.ReadToEnd();

                // Используем регулярное выражение для поиска двузначных чисел в строке
                Regex regex = new Regex(@"\b\d{2}\b");

                // Извлекаем все двузначные числа из строки
                var matches = regex.Matches(inputString);

                // Сортируем двузначные числа
                var sortedNumbers = matches
                    .OfType<Match>()
                    .Select(match => int.Parse(match.Value))
                    .OrderBy(number => number);

                // Заменяем двузначные числа в строке отсортированными числами
                string sortedString = regex.Replace(inputString, match =>
                {
                    int number = int.Parse(match.Value);
                    return sortedNumbers.First() == number ? sortedNumbers.First().ToString() : sortedNumbers.Skip(1).First().ToString();
                });
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(sortedString);
                    sw.Close();
                }
                sr.Close();
            }
            using (StreamReader sr = new StreamReader(path))
            {
                int startIndex = 10; // индекс начала строки

                // Чтение и пропуск символов до нужного индекса
                sr.BaseStream.Seek(startIndex, SeekOrigin.Begin);
                string line = sr.ReadLine();

                if (line != null)
                {
                    Console.WriteLine(line);
                }
            }
        }*/   
        public void Summarize()
        {
            Console.Clear();
            Console.WriteLine("Правильных ответов: " + trueAnswers);
            trueAnswers = 0;
            Console.ReadKey();
        }       
    }
}
