using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024.Solutions
{
    internal class Day5
    {
        public struct Sections
        {
            public List<string> orderingRules { get; set; }
            public List<string> updates { get; set; }
        }
        public static Sections ParseSections(string[] input)
        {
            Sections sections = new Sections();

            sections.orderingRules = new List<string>();
            sections.updates = new List<string>();

            bool parsingRules = true;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == string.Empty)
                {
                    parsingRules = false;
                    continue;
                }

                if (parsingRules)
                {
                    sections.orderingRules.Add(input[i]);
                }
                else
                {
                    sections.updates.Add(input[i]);
                }
            }

            return sections;
        }

        public static Dictionary<int, List<int>> ParsePageOrderingRules(List<string> rules)
        {
            Dictionary<int, List<int>> prequisiteMappings = new Dictionary<int, List<int>>();

            for (int i = 0;i < rules.Count;i++)
            {
                int[] rule = rules[i].Split("|").Select(int.Parse).ToArray();

                if (prequisiteMappings.ContainsKey(rule[0]))
                {
                    prequisiteMappings[rule[0]].Add(rule[1]);
                }
                else
                {
                    prequisiteMappings.Add(rule[0], new List<int> { rule[1] });
                }
            }

            return prequisiteMappings;
        }

        public static List<int> ParseUpdate(string update) {
            return update.Split(",").Select(int.Parse).ToList();
        }

        public static int SumCorrectlyOrderedUpdates(string[] input)
        {
            int correctUpdatedMiddleNumSum = 0;

            Sections sections = ParseSections(input);

            // each key is a number that contains a list of numbers as its value
            // all of these numbers must come before our key number
            Dictionary<int, List<int>> orderMappings = ParsePageOrderingRules(sections.orderingRules);

            
            foreach (var update in sections.updates)
            {
                List<int> pageNumbers = ParseUpdate(update);
                bool updateCorrectlyOrdered = true;

                for (int i = 1; i < pageNumbers.Count; i++)
                {
                    int pageNumber = pageNumbers[i];

                    if (orderMappings.ContainsKey(pageNumber))
                    {
                        for (int j = 0; j < orderMappings[pageNumber].Count; j++)
                        {
                            if (pageNumbers.Contains(orderMappings[pageNumber][j]))
                            {
                                if (pageNumbers.IndexOf(orderMappings[pageNumber][j]) < i)
                                {
                                    updateCorrectlyOrdered = false;
                                }
                            }
                        }
                    }
                }

                if (updateCorrectlyOrdered)
                {
                    int updateSize = pageNumbers.Count;

                    if (updateSize % 2 != 0)
                    {
                        correctUpdatedMiddleNumSum += pageNumbers[(updateSize - 1) / 2];
                        Console.WriteLine($"{pageNumbers[(updateSize - 1) / 2]} from {pageNumbers.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Even update encountered");
                        correctUpdatedMiddleNumSum = pageNumbers[updateSize / 2] + pageNumbers[(updateSize) / 2 + 1] / 2;
                    }
                }

            }

            return correctUpdatedMiddleNumSum;
        }
    }
}
