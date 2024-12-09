using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024.Solutions
{
    internal class Day2 : IDay
    {
        public static List<int> ReportLevels(string report)
        {
            return report.Split(" ").Select(int.Parse).ToList();
        }

        private static bool IsReportSafe(List<int> levels)
        {
            bool ascendingSafe = true;
            bool descendingSafe = true;

            for (int i = 0; i < levels.Count - 1; i++)
            {
                int currentNum = levels[i];
                int nextNum = levels[i + 1];

                // check to falsify ascending
                if (currentNum >= nextNum || nextNum - currentNum > 3)
                {
                    ascendingSafe = false;
                }

                // check to falsify descending
                if (currentNum <= nextNum || currentNum - nextNum > 3)
                {
                    descendingSafe = false;
                }
            }

            return !(ascendingSafe && descendingSafe) && ascendingSafe || descendingSafe;
        }

        private static int CountSafeReports(string[] reports)
        {
            int safeReports = 0;

            foreach (string report in reports)
            {
                if (IsReportSafe(ReportLevels(report))) { safeReports++; }
            }

            return safeReports;
        }

        private static int CountSafeReportsWithTolerance(string[] reports)
        {
            int safeReports = 0;

            foreach (string report in reports)
            {
                bool atLeastOneSafe = false;

                List<int> untoleratedReport = ReportLevels(report);

                for (int i = 0; i < untoleratedReport.Count; i++)
                {
                    List<int> toleratedReport = ReportLevels(report);
                    toleratedReport.RemoveAt(i);

                    if (IsReportSafe(toleratedReport)) atLeastOneSafe = true;
                }

                if (atLeastOneSafe) { safeReports++; }
            }

            return safeReports;
        }

        public static void SolveProblem(string[] input)
        {
            Console.WriteLine(CountSafeReports(input));
            Console.WriteLine(CountSafeReportsWithTolerance(input));
        }
    }
}
