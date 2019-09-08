**********************
# TriangleEulerSoln
**********************
To find the valid path from a integer triangle taking Odd/Even rule in consideration
Algorithm: The strategy used to solve this problem involves a combination of logics &  divide the problem into smaller subproblems, as well as dynamic programming used to divide the search space into a manageable size.  The basic pseudocode for the search algorithm is below:

*************Sample input in text file ****************
215 
192 124
117 269 442
218 836 347 235
320 805 522 417 345
229 601 728 835 133 124
***************sample input end*************

1.	Uses Dynamic programming which is reducing the loop cycles 
2.	We will be using 2  loops 
•	The row for loop will Start from the bottom 
•	The column for loop will increment row wise
3.	Temporary storage of results
  •	Store Path [rows][columns], i = rows.length,  j = 0
  •	Parent = row[i-1] [j], child1=row[i][j], child2=col[i][j+1]
  •	Valid path i.e. 
    i.	if parent is Odd == Child1 is even && parent is Odd != Child2 is odd
    •	Store path : parentchild1
    ii.	 if parent is Even == Child2 is Odd && parent is Odd != Child1 is odd
    •	Store path : parentchild2
    iii.	if (parent is Odd == Child1 is even && parent is Odd == Child2 is Even) OR (if parent is Even == Child1 is Odd && parent is Even == Child2 is Odd)
    •	check child 1 > child 2 then
      o	Store path : parentchild1
    •	Else
      o	Store path : parentchild2
    iv.	if(parent is Odd == Child1 is odd && parent is Odd == Child2 is odd ) OR (if parent is Even == Child1 is even && parent is Even ==              Child2 is even)
    •	DO NOT STORE and continue with next Parent, child1 and child 2
***********************
Program flow
**********************
1. Read the input file, validate and store the results in List<List of Integers>
2. Walthrough the List<List of Integers> using ynamic prigramming from bottom to top
	2.1. find the valid item 
	2.2 store the valid path and ignore the invalid
	2.3 traverse the rows & store the valid child and immediate parent path
3. get the final path & reverse
4. Summation the path to get the results 


**********************
Solution modular and diverse:
**********************
This solution is fairly divers in that it could be extended to 
		find the maximum path in any of the triangle.  

**********************
Performance:
**********************
Without caching, the complexity of this algorithm (average and worst-case) is O(2^N), where N = the height of the tree.  The  caching mechanism is implemented to stop the traversal of all suboptimal paths at level L as soon as all optimal paths for L are found. This will reduce the complexity to a little more than 
		O(N^2)

**********************
Memory Footprint: 
**********************
elements in the triangle are stored in a  list of integers that is dynamically resized to fit the triangle's dimensions.  This minimizes object creation overhead as well as the overhead of building a bulky rectangular-shaped array.
Default .net GC is used to clean up the heap memory allocation.

**********************
Data structure used:
**********************
1. Map the input file into List of integers storing every row items in the list
2. strore the intermediate path in the list of equivalent size [rows][colums]
3. comparison is used to make sure the input file is in correct forma

**********************
Future eenhancements
**********************
1. Additional functions for accepting the input dynamically 
2. representation of output for different audience
3. addition utility function which can handle more operations
4. converting console into a UI to help user decide the mode of input
5. exporting the output in various other formats
