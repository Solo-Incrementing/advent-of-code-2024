using advent_of_code_2024.Solutions;
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

            //Console.WriteLine(Day2.CountSafeReports(InputReader.ReadAllLines(@"..\..\..\Inputs\Day2\example.txt")));
            //Console.WriteLine(Day2.CountSafeReports(InputReader.ReadAllLines(@"..\..\..\Inputs\Day2\data.txt")));
            //Console.WriteLine(Day2.CountSafeReportsWithTolerance(InputReader.ReadAllLines(@"..\..\..\Inputs\Day2\example.txt")));
            //Console.WriteLine(Day2.CountSafeReportsWithTolerance(InputReader.ReadAllLines(@"..\..\..\Inputs\Day2\data.txt")))

            //Console.WriteLine(Day3.SolveCorruptedMuls(InputReader.ReadAllText(@"..\..\..\Inputs\Day3\example.txt")));
            //Console.WriteLine(Day3.SolveCorruptedMuls(InputReader.ReadAllText(@"..\..\..\Inputs\Day3\data.txt")));

            //Console.WriteLine(Day4.CountOfWordSearch(InputReader.ReadAllLines(@"..\..\..\Inputs\Day4\example.txt"), "XMAS"));
            //Console.WriteLine(Day4.CountOfWordSearch(InputReader.ReadAllLines(@"..\..\..\Inputs\Day4\data.txt"), "XMAS"));
            //Console.WriteLine(Day4.oddWordCrossSearch(InputReader.ReadAllLines(@"..\..\..\Inputs\Day4\example.txt"), "MAS"));
            //Console.WriteLine(Day4.oddWordCrossSearch(InputReader.ReadAllLines(@"..\..\..\Inputs\Day4\data.txt"), "MAS"));

            //var parsedSections = Day5.ParsePageOrderingRules(Day5.ParseSections(InputReader.ReadAllLines(@"..\..\..\Inputs\Day5\example.txt")).orderingRules);

            //Console.WriteLine(Day5.SumCorrectlyOrderedUpdates(InputReader.ReadAllLines(@"..\..\..\Inputs\Day5\example.txt")));
            //Console.WriteLine(Day5.SumCorrectlyOrderedUpdates(InputReader.ReadAllLines(@"..\..\..\Inputs\Day5\data.txt")));

            Console.WriteLine(Day5.SumIncorrectUpdatesAfterOrdering(InputReader.ReadAllLines(@"..\..\..\Inputs\Day5\example.txt")));
            Console.WriteLine(Day5.SumIncorrectUpdatesAfterOrdering(InputReader.ReadAllLines(@"..\..\..\Inputs\Day5\data.txt")));
        }
    }
}