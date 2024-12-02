using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024
{
    internal class Day2
    {
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
