# Algorithms
To create .gitignore file type in the terminal (internet required)
curl -o .gitignore https://www.gitignore.io/api/VisualStudio

Quick-Find - Is there a path connecting the two objects? 
		Design efficient data structure for union-find.
		・Number of objects N can be huge.
		・Number of operations M can be huge.

		Cost model. Number of array accesses (for read or write).
		Union is too expensive. It takes N^2 array accesses to process a sequence 		of N union commands on N objects. Is too slow:
		initialize union find
		N	   N	  1

Quick-Union - Solve the same problem and is also too slow
		initialize union find
		N	   N	  N
Improved (Weighted) Union
		initialize union find
		N	   lg N  lg N

Percolation - Algorithm for checking if we can move from top cells to bottom if we can move only straight up-down and right-left and can not go by the diagonal.