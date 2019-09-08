# TriangleEulerSoln
To find the valid path from a integer triangle taking Odd/Even rule in consideration
Algorithm
----------------------------------
*************Sample input****************
215 
192 124
117 269 442
218 836 347 235
320 805 522 417 345
229 601 728 835 133 124

1.	Uses Dynamic programming which will reduce the loop cycles 
2.	We will be using 2 for loops 
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
iv.	if(parent is Odd == Child1 is odd && parent is Odd == Child2 is odd ) OR (if parent is Even == Child1 is even && parent is Even == Child2 is even)
•	DO NOT STORE and continue with next Parent, child1 and child 2
