using System;
using System.Collections.Generic;
using System.Linq;

namespace EulerLogic
{
    public static class EulerTriangle
    {
        #region Public methods
        //Method : to get the Odd, even path 
        //input: List of items from input in list items
        //output: true if path exist else false
        public static bool GetPathByOddEvenRule(List<List<int>> itemsList, out List<int> path)
        {
            if(itemsList == null){throw new ArgumentNullException();}
            if(!itemsList.Any()){throw new ArgumentOutOfRangeException();}

            int rows = itemsList.Count;
            List<int>[,] pathsTrack = new List<int>[rows, rows];
            int child1, child2, parent, validItem;
            int child2ColumnIndex, parentRowIndex;
            bool isItemExists, isChild1Valid;
            List<int> row; bool firstRowFromBottom = true;
            List<int> pathToCurrentElement = null;

            for (int i = rows - 1; i > 0; i--)
            {
                row = itemsList[i];
                parentRowIndex = i - 1;

                for (int j = 0; j < i; j++)
                {
                    child2ColumnIndex = j + 1;
                    child1 = row[j];
                    child2 = row[child2ColumnIndex];
                    parent = itemsList[parentRowIndex][j];

                    isItemExists = GetItemOddEvenRule(child1, child2, parent, i, j,  out validItem , out isChild1Valid);
                    if (!isItemExists) {
                        //not a valid entry, skip
                        continue; 
                    }

                    var childIndex = isChild1Valid ? j : child2ColumnIndex;

                    if (firstRowFromBottom){//to handle Dynamic programming starting from botton row
                        pathToCurrentElement = new List<int>() { validItem };
                        pathsTrack[i, childIndex] = pathToCurrentElement;
                    }else{//rest of rows
                        pathToCurrentElement = pathsTrack[i, childIndex];
                    }

                    List<int> parentChildrenTree = pathsTrack[parentRowIndex, j];
                    if (parentChildrenTree == null && pathToCurrentElement != null)
                    {
                        parentChildrenTree = new List<int>(pathToCurrentElement);
                        parentChildrenTree.Add(parent);
                        pathsTrack[parentRowIndex, j] = parentChildrenTree;
                    }
                }

                firstRowFromBottom = false;
            }
            //get the final valid path
            path = pathsTrack[0, 0];
            var found = path != null;
            if (found){
                path.Reverse(); 
            }

            return found;
        }


        
        #endregion Public methods

        #region Private methods
                
        /*  if (parent is Odd == Child1 is even && parent is Odd == Child2 is Even) OR (if parent is Even == Child1 is Odd && parent is Even == Child2 is Odd)
        ///	check child 1 > child 2 then
        /// Store path : parentchild1
        /// Else
        /// Store path : parentchild2
        /// if(parent is Odd == Child1 is odd && parent is Odd == Child2 is odd ) OR (if parent is Even == Child1 is even && parent is Even == Child2 is even)
        ///  DO NOT STORE and continue with next Parent, child1 and child 2 */
        private static bool GetItemOddEvenRule(int child1, int child2, int parent, int i, int j, out int validItem, out bool isChild1Valid)
        {
            validItem = 0;
            isChild1Valid = false; //default
            bool isParentOdd;
            bool retVal = false;

                isParentOdd = IsOdd(parent);

                bool isChild1Odd = IsOdd(child1);
                bool isChild2Odd = IsOdd(child2);

                if (isParentOdd != isChild1Odd)
                {
                    if (isParentOdd != isChild2Odd)
                    {
                        isChild1Valid = child1 > child2;
                        validItem = isChild1Valid ? child1 : child2;
                        retVal=true;
                    }
                    else
                    {
                        isChild1Valid = true;
                        validItem = child1;
                        retVal= true;
                    }
                }
                else if (isParentOdd != isChild2Odd)
                {
                    validItem = child2;
                    retVal=true;
                }
                else
                {
                    retVal=false;
                }
            return retVal;
        }

        /// <summary>
        /// Function which checks if number is odd.
        /// </summary>
        /// <param name="number">Number to check.</param>
        /// <returns>Returns 'true' if numbers is odd, 'false' - otherwise.</returns>
        private static bool IsOdd(int number)
        {
            var remainder = number % 2;
            return (number > 0 && remainder == 1) || (number < 0 && remainder == -1);
        }

        #endregion Private methods
    }
}
