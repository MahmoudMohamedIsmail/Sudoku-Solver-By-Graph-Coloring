using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver_By_DOM_Algo
{
    class ValidateSudoku
    {
        public bool CheckValidation(int[] SudokuCells, int Dim)
        {
            //For All Rows, Col, Squares 
            if (!Row(SudokuCells, Dim))
                return false;
            if (!Col(SudokuCells, Dim))
                return false;
            if (!Squares(SudokuCells, Dim))
                return false;

            return true;
        }
        public bool Row(int[] SudokuCells, int Dim)
        {
            for (int i = 0; i < Dim; i++)
            {
                for (int j = 0; j < Dim; j++)
                {
                    for (int inx = 0; inx < Dim; inx++)
                    {
                        if (inx == j) continue;
                        if ((SudokuCells[(i * Dim + j)] == SudokuCells[(i * Dim + inx)]) && SudokuCells[(i * Dim + j)] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public bool Col(int[] SudokuCells, int Dim)
        {
            for (int j = 0; j < Dim; j++)
            {
                for (int i = 0; i < Dim; i++)
                {
                    for (int inx = 0; inx < Dim; inx++)
                    {
                        if (inx == i) continue;

                        if ((SudokuCells[(i * Dim + j)] == SudokuCells[(inx*Dim + j)]) && SudokuCells[(i * Dim + j)] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public bool Squares(int[] SudokuCells, int Dim)
        {
            int interval=Dim /(int.Parse(Math.Sqrt(Dim).ToString()));
            // Squares
            for (int r = 0; r <interval ; r++)
                for (int c = 0; c < interval; c++)
                   
                    // For each square
                    for(int i=(r*interval);i<(r*interval)+interval;i++)
                        for (int j = (c * interval); j < (c * interval) + interval; j++)
                        {
                            
                            //Check Square.....
                             for(int x=(r*interval);x<(r*interval)+interval;x++)
                                 for (int y = (c * interval); y < (c * interval) + interval; y++)
                                 {
                                     if (i==x&&j==y) continue;

                                     if ((SudokuCells[(i * Dim + j)] == SudokuCells[(x * Dim + y)]) && SudokuCells[(i * Dim + j)] != 0)
                                     {
                                         return false;
                                     }
                                 }
                        }
            return true;
        }
    }
}
