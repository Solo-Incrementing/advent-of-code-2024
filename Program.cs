namespace advent_of_code_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Day1.SumDifferences(InputReader.ReadAllLines(@"..\..\..\Inputs\Day1\example.txt")));
            Console.WriteLine(Day1.SumDifferences(InputReader.ReadAllLines(@"..\..\..\Inputs\Day1\data.txt")));
            Console.WriteLine(Day1.SumSimilarityScores(InputReader.ReadAllLines(@"..\..\..\Inputs\Day1\example.txt")));
            Console.WriteLine(Day1.SumSimilarityScores(InputReader.ReadAllLines(@"..\..\..\Inputs\Day1\data.txt")));
        }
    }
}
