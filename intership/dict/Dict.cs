using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace intership.dict
{
    class Dict
    {
        public string path;
        public Dict(string path)
        {
            this.path = path;
        }

        public string[] search(string Word)
        {
            using TextReader file = File.OpenText("../../../words.txt");

            List<string> results = new List<string>();
            string line = file.ReadLine();
            while(line != null)
            {
                if (line.ToLower().Contains(Word.ToLower()))
                {
                    results.Add(line);
                }

                line = file.ReadLine();
            }

            return results.ToArray();
        }
    }
}
