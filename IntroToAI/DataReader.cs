using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAI
{
    class DataReader
    {
        public static Map ReadMap(string filename)
        {
            Map map = new Map();
            foreach (string line in File.ReadLines(@filename))
            {
                string[] splitline = line.Split(' ');
                map.addconnection(splitline);
            }
            return map;
        }
    }
}
