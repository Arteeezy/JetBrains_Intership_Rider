using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace intership.dict

// логика поиска совпадений
{
    class Dict
    {
        public int temp = 0;
        public string path;
        public Dict(string path)
        {
            this.path = path;
        }
        // функция проверяет совпадение по последовательным символам
        public bool Match(string word, string line)
        {
            int index = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (word[index] == line[i])
                    index++;

                if (index == word.Length)
                    return true;
            }
            return false;
        }
        // функция поиска совпадений в словаре вызывает массив найденных слов
        public string[] search(string Word)
        {
            using TextReader file = File.OpenText("../../../words.txt");

            List<string> results = new List<string>();
            string line = file.ReadLine();
            // при нажатой галочке выполняется вызов функции Match
            if (temp == 1) {
                while (line != null)
                {
                    if (Match(Word.ToLower(), line.ToLower()))
                    {
                        results.Add(line);
                    }

                    line = file.ReadLine();
                }
            }
            // при отжатой галочке выполняется поиск только по подстроке
            else
            {
                while (line != null)
                {
                    if (line.ToLower().Contains(Word.ToLower()))
                    {
                        results.Add(line);
                    }

                    line = file.ReadLine();
                }
            }


            return results.ToArray();
        }
    }
}
