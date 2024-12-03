using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024
{
    internal class InputReader
    {
        public static string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public static string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
