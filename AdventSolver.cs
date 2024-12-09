using System.Reflection;
using System.Runtime.InteropServices;

namespace advent_of_code_2024;

public class AdventSolver
{
    public void SolveProblem(string dayNum)
    {
        string dayTypeString = $"Day{dayNum}";
        string examplePath;
        string dataPath;
        
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            examplePath = @"..\..\..\Solutions\" + dayTypeString + @"\Inputs\example.txt";
            dataPath = @"..\..\..\Solutions\" + dayTypeString + @"\Inputs\data.txt";
        }
        else
        {
            examplePath = @"../../../Solutions/" + dayTypeString + @"/Inputs/example.txt";
            dataPath = @"../../../Solutions/" + dayTypeString + @"/Inputs/data.txt";
        }

        string[] exampleInput = File.ReadAllLines(examplePath);
        string[] dataInput = File.ReadAllLines(dataPath);

        string className = $"advent_of_code_2024.Solutions.{dayTypeString}";

        Type dayType = Type.GetType(className);

        if (dayType == null)
        {
            Console.WriteLine($"Class '{className}' not found");
            return;
        }

        MethodInfo methodInfo = dayType.GetMethod("SolveProblem", BindingFlags.Static | BindingFlags.Public);
        
        if (methodInfo == null)
        {
            Console.WriteLine($"Method 'SolveProblem' not found in class '{className}'.");
            return;
        }

        methodInfo.Invoke(null, [exampleInput]);
        methodInfo.Invoke(null, [dataInput]);
    }
}