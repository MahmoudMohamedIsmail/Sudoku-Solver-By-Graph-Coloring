using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver_By_DOM_Algo
{
    class Table
    {
        public TextBox[] textBoxes;
        public Table(int Size)
        {
            textBoxes = new TextBox[Size];
        }

        public void DisplayTable(int Row,int Col, Form F)
        {
           
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    textBoxes[(i*Row)+j] = new TextBox();
                    textBoxes[(i * Row) + j].Location = new System.Drawing.Point(0 + (30 * j), 0 + (i * 20));
                    textBoxes[(i * Row) + j].Size = new System.Drawing.Size(30, 20);
                    F.Controls.Add(textBoxes[(i * Row) + j]);   
                }
            }

        }
    }
}
