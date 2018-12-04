using System;
using System.Linq;

namespace T1_Union_Find.Engine
{
    public class Percolation
    {
        public bool[][] Grid { get; private set; }
        public int Size { get; private set; }
        private Quick_Union_Improved unions;

        private struct Cell
        {
            public int row;
            public int col;

            public Cell(int row, int col)
            {
                this.row = row;
                this.col = col;
            }
        }

        public Percolation(int n)           // create n-by-n grid, with all sites blocked
        {
            if (n > 0)
            {
                Size = n;
                Grid = new bool[Size][];
                for (int i = 0; i < Size; ++i)
                {
                    Grid[i] = new bool[Size];
                }

                MakeAllCellsClosed();
                unions = new Quick_Union_Improved(n*n);
            }
            else
            {
                Size = 0;
            }
        }

        public void Open(int row, int col)    // open site (row, col) if it is not open already
        {
            //var cell = new Cell(row, col);
            if (Grid[row][col] == false) // Try to add it to percolation tree
            {
                Grid[row][col] = true;
                CheckNeighbours(row, col);
            }
        }

        private void CheckNeighbours(int row, int col)
        {
            AddNeighbourIfOpen(row, col, row, col - 1);
            AddNeighbourIfOpen(row, col, row + 1, col);
            AddNeighbourIfOpen(row, col, row, col + 1);
            AddNeighbourIfOpen(row, col, row - 1, col);
        }

        private void AddNeighbourIfOpen(int rowStart, int colStart, int rowEnd, int colEnd)
        {
            if (IsOpen(rowEnd, colEnd))
            {
                unions.AddLeaf(CellValue(rowStart, colStart), CellValue(rowEnd, colEnd));
            }
        }

        private int CellValue(int row, int col)
        {
            return row * Size + col;
        }

        private bool IsOpen(int row, int col)  // is site (row, col) open?
        {
            return row >= 0 && row < Size &&
                col >= 0 && col < Size &&
                Grid[row][col] == true;
        }

        //public int numberOfOpenSites()       // number of open sites
        public bool Percolates()              // does the system percolate?
        {
            unions.PrintUnions();
            var count = unions.TreesList
                             .Where(x => x.Exists(y => y < Size))
                             .Where(x => x.Exists(y => y >= (Size * Size - Size)))
                             .Count();
            return count > 0;
        }

        private void MakeAllCellsClosed()
        {
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    Grid[i][j] = false;
                }
            }
        }

        public void PrintMatrix()
        {
            string line;
            for (int i = 0; i < Size; ++i)
            {
                line = string.Empty;
                for (int j = 0; j < Size; ++j)
                {
                    line += (Grid[i][j])? "1": "0"
                        + "  ";
                }
                Console.WriteLine(line);
            }
        }

        public void main()
        {
            var percolation = new Percolation(10);
            Random rnd = new Random();
            int row;
            int col;
            bool a = true;
            for (int i = 0; i < 30; ++i)
            {
                for (int j = 0; j < 30; ++j)
                {
                    row = rnd.Next(0, 10);
                    col = rnd.Next(0, 10);
                    percolation.Open(row, col);
                    if (a && percolation.Percolates())
                    {
                        Console.WriteLine("Matrix percolates!!!");
                        percolation.PrintMatrix();
                        a = false;
                    }
                }
            }
            percolation.Percolates();
            percolation.PrintMatrix();
        }
    }
}
