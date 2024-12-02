﻿using advent_of_code_2024.Solutions;
using System.Text.RegularExpressions;

namespace advent_of_code_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Day1.SumDifferences(InputReader.ReadAllLines(@"..\..\..\Inputs\Day1\example.txt")));
            //Console.WriteLine(Day1.SumDifferences(InputReader.ReadAllLines(@"..\..\..\Inputs\Day1\data.txt")));
            //Console.WriteLine(Day1.SumSimilarityScores(InputReader.ReadAllLines(@"..\..\..\Inputs\Day1\example.txt")));
            //Console.WriteLine(Day1.SumSimilarityScores(InputReader.ReadAllLines(@"..\..\..\Inputs\Day1\data.txt

            //Console.WriteLine(Day2.CountOfSafeReports(InputReader.ReadAllLines(@"..\..\..\Inputs\Day2\example.txt")));
            //Console.WriteLine(Day2.CountOfSafeReports(InputReader.ReadAllLines(@"..\..\..\Inputs\Day2\data.txt")));

            Console.WriteLine(Day2.ReportLevels(InputReader.ReadAllLines(@"..\..\..\Inputs\Day2\example.txt")[0]));

            //Console.WriteLine(Day3.SolveCorruptedMuls(InputReader.ReadAllText(@"..\..\..\Inputs\Day3\example.txt")));
            //Console.WriteLine(Day3.SolveCorruptedMuls(InputReader.ReadAllText(@"..\..\..\Inputs\Day3\data.txt")));
        }
    }
}