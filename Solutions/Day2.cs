using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024
{
    internal class Day2
    {
        public static int[] ReportLevels(string report)
        {
            return report.Split(" ").Select(int.Parse).ToArray();
        }

        private static bool ReportIsSafeWithTolerance(string report)
        {
            int maximumDifference = 3;

            bool ascendingSafe = true;
            bool descendingSafe = true;
            
            int ascendingTolerances = 0;
            int descendingTolerances = 0;

            int[] levels = ReportLevels(report);

            for (int i = 1; i < levels.Count() - 1; i++)
            {
                int previousNum = levels[i - 1];
                int currentNum = levels[i];
                int nextNum = levels[i + 1];
                
                // ascending checks
                {
                    int currentMinusPrevious = currentNum - previousNum;
                    int nextMinusPrevious = nextNum - previousNum;
                    
                    if (!(currentMinusPrevious > 0 && currentMinusPrevious <= maximumDifference))
                    {
                        if (!(nextMinusPrevious > 0 && nextMinusPrevious <= maximumDifference))
                        {
                            if (ascendingTolerances > 0)
                            {
                                int prevPrev = levels[i - 2];
                                int currentMinusPrevPrev = currentNum - prevPrev;

                                if (!(currentMinusPrevPrev > 0 && currentMinusPrevPrev <= maximumDifference))
                                {
                                    ascendingSafe = false;
                                }
                            }
                        }
                                                
                        if (ascendingTolerances > 0)
                        { 
                            ascendingSafe = false;
                        }
                        
                        ascendingTolerances++;
                    }
                }
                
                // descending checks

                {
                    int currentMinusNext = currentNum - nextNum;
                    int previousMinusNext = previousNum - nextNum;
                    
                    if (!(currentMinusNext > 0 && currentMinusNext <= maximumDifference))
                    {
                        descendingTolerances++;

                        if (descendingTolerances > 1)
                        {
                            descendingSafe = false;
                        }

                        if (!(previousMinusNext > 0 && previousMinusNext <= maximumDifference))
                        {
                            descendingSafe = false;
                        }
                    }
                }
            }

            return ascendingSafe || descendingSafe;
        }
        
        public static int SafeReportCount(IEnumerable<string> reports)
        {
            int safeReports = 0;
            foreach (string report in reports)
            {
                if (ReportIsSafeWithTolerance(report)) safeReports++;
            }

            return safeReports;
        }

        public static string SafetyString(IEnumerable<string> reports)
        {
            string safetyString = "";
            foreach (string report in reports)
            {
                safetyString += $"{ReportIsSafeWithTolerance(report)} ";
            }

            return safetyString;
        }

        public static int CountOfSafeReports(string[] reports)
        {
            int safeReports = 0;

            List<bool> safeReportBools = [];

            foreach (string report in reports)
            {
                string[] levels = report.Split(" ");

                bool isSafe = true;
                bool isAscending = true;

                int firstNum = int.Parse(levels[0]);
                int secondNum = int.Parse(levels[1]);

                int firstTwoNumDiff = Math.Abs(firstNum - secondNum);

                if ((firstTwoNumDiff >= 1) && (firstTwoNumDiff <= 3))
                {
                    if (firstNum > secondNum)
                    {
                        isAscending = false;
                    }
                    else
                    {
                        isAscending = true;
                    }
                }
                else
                {
                    continue;
                }

                bool dampened = false;

                for (int i = 1; i < levels.Length - 1; i++)
                {
                    int prevNum = int.Parse(levels[i - 1]);
                    int currentNum = int.Parse(levels[i]);
                    int nextNum = int.Parse(levels[i+1]);
                    int currentNextDiff = Math.Abs(currentNum - nextNum);
                    int currentPrevDiff = Math.Abs(currentNum - prevNum);
                    

                    if (isAscending)
                    {
                        if ((nextNum <= currentNum) || (prevNum >= currentNum) || currentNextDiff < 1 || currentNextDiff > 3 || currentPrevDiff < 1 || currentPrevDiff > 3)
                        {
                            if (!dampened)
                            {
                                dampened = true;
                            }
                            else
                            {
                                if (prevNum > nextNum || currentNextDiff > 3)
                                {
                                    prevNum = int.Parse(levels[i - 2]);
                                    currentPrevDiff = Math.Abs(currentNum - prevNum);

                                    if ((prevNum > currentNum) || currentPrevDiff > 3)
                                    {
                                        isSafe = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if ((nextNum >= currentNum) || (prevNum <= currentNum) || currentNextDiff < 1 || currentNextDiff > 3 || currentPrevDiff < 1 || currentPrevDiff > 3)
                        {
                            if (!dampened)
                            {
                                dampened = true;
                            }
                            else
                            {
                                if (prevNum < nextNum || currentNextDiff > 3)
                                {
                                    prevNum = int.Parse(levels[i - 2]);
                                    currentPrevDiff = Math.Abs(currentNum - prevNum);

                                    if ((prevNum < currentNum) || currentPrevDiff > 3)
                                    {
                                        isSafe = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (isSafe)
                {
                    safeReportBools.Add(true);
                    safeReports++;
                }
                else
                {
                    safeReportBools.Add(false);
                }
            }

            foreach (var safeBool in safeReportBools)
            {
                Console.Write(safeBool + " ");
            }

            return safeReports;
        }
    }
}
