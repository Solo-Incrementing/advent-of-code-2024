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

        public static bool IsReportSafe(string report)
        {
            int[] levels = ReportLevels(report);
            bool ascendingSafe = true;
            bool descendingSafe = true;

            for (int i = 0; i < levels.Length - 1; i++)
            {
                int currentNum = levels[i];
                int nextNum = levels[i + 1];

                // check to falsify ascending
                if (currentNum >= nextNum || (nextNum - currentNum) > 3)
                {
                    ascendingSafe = false;
                }

                // check to falsify descending
                if (currentNum <= nextNum || (currentNum - nextNum) > 3)
                {
                    descendingSafe = false;
                }
            }

            return !(ascendingSafe && descendingSafe) && ascendingSafe || descendingSafe;
        }

        public static int CountSafeReports(string[] reports)
        {
            int safeReports = 0;

            foreach (string report in reports)
            {
                if (IsReportSafe(report)) { safeReports++; }
            }

            return safeReports;
        }

        public static int CountSafeReportsWithTolerance(string[] reports)
        {
            return 0;
        }
    }
}
