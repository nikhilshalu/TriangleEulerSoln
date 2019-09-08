using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EulerLogic
{
    /// <summary>
    /// Helper to work with files.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Reads file to nested list.
        /// </summary>
        /// <param name="filePath">Full input file path.</param>
        /// <param name="separator">File content elements separator.</param>
        /// <param name="rows">Number of rows.</param>
        /// <returns>Returns triangle data in nested list.</returns>
        public static List<List<int>> ReadFileToNestedList(string filePath, string separator, out int rows)
        {
            if (filePath == null){throw new ArgumentNullException(filePath);}

            if (string.IsNullOrWhiteSpace(filePath)){throw new ArgumentOutOfRangeException(filePath);}

            if (!File.Exists(filePath)){throw new FileNotFoundException(filePath);}

            if (separator == null){throw new ArgumentNullException(separator);}

            char[] separatorChars = separator.ToCharArray();//delimiter by space
            string line;
            List <int> items = null;
            rows = 0;
            List<List<int>> twoDArrList = new List<List<int>>();
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line)) // skip empty lines 
                    {
                        try
                        {
                            //convert string array into int list type
                            items = line.Split(separatorChars, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                        }
                        catch(Exception ex){
                            throw new Exception(string.Format("Failed to parse line '{0}' to integer numbers. File: '{1}'.", line, filePath), ex);
                        }
                        rows++;
                        if(items.Count != rows){
                            throw new Exception(string.Format("Input data not valid, Input is not a triangle . Invalid line number: {0}. File: '{1}'.", rows, filePath));
                        }
                        twoDArrList.Add(items);
                    }
                }
            }
            return twoDArrList;
        }
        
    }
}
