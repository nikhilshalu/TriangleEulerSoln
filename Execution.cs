using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using EulerLogic;


namespace TriangleEulerSolution
{
    class Execution
    {
        static void Main(string[] args)
        {
            try
            {
                string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filePath = Path.Combine(assemblyPath, "Data\\input.txt");

                if (File.Exists(filePath))
                {
                    int rows;
                    var matrix = Utils.ReadFileToNestedList(filePath, " ", out rows);
                    if (rows < 2)
                    {
                        Console.WriteLine("Input data is invalid. The triangle can be at least from 2 rows.");
                        return;
                    }

                    List<int> path=new List<int>();
                    bool pathExist = EulerTriangle.GetPathByOddEvenRule(matrix, out path);
                    if (pathExist)
                    {
                        Console.WriteLine("Euler path and sum is : ");
                        Console.WriteLine(string.Join("->", path.Select(i => i.ToString()).ToArray()));
                        Console.WriteLine("{0} = {1}", path.Sum(), string.Join(" + ", path.Select(i => i.ToString()).ToArray()));
                    }
                    else
                    {
                        Console.WriteLine("No Triangle path, Odd/Even rule mismatch");
                    }
                }
                else
                {
                    Console.WriteLine("File '{0}' not exists or inaccessible.", filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.WriteLine("StackTrace: {0}", ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        private static string FormatNegativeNumbers(int i)
        {
            return i < 0 ? string.Format("({0})", i) : i + "";
        }
    }
}
