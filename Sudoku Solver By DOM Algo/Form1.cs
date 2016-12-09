using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku_Solver_By_DOM_Algo
{
    public partial class Form1 : Form
    {
        Table table;
        int Dim;
        int[] SudokuCells;
        Sudoku sudoku;
        ColorGraph colorGraph = new ColorGraph();
        public Form1()
        {
            InitializeComponent();

            AllGroubs.Hide();
            //Hide All Button
           // SolveSudoku.Hide();
            //Algorithms.Hide();
            //ColorTable.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dimension.Text == "")
            {
                MessageBox.Show("Plz Enter Dimension");
            }

            Dim = int.Parse(dimension.Text);
            //create Table
            table = new Table(Dim * Dim);
            //Hide All
			dimension.Hide();
			groupBox1.Hide();



			// Show Buttons in new Size
			// this.SolveSudoku.Location = new System.Drawing.Point(93, Dim * 20 + 20);
			//this.ColorTable.Location = new System.Drawing.Point(174, Dim * 20 + 20);
			this.AllGroubs.Location = new System.Drawing.Point(12, Dim * 20 + 20);

            AllGroubs.Show();
           // SolveSudoku.Show();
            //ColorTable.Show();
            //Algorithms.Show();
            
            // this.ClientSize = new System.Drawing.Size(Math.Max(174 + 6, Dim * 20 + 20), Dim * 20 + 70);
            this.Size = new System.Drawing.Size(Math.Max(310, Dim * 30 + 50), (Dim * 20) + 150);


			//Display Table
			table.DisplayTable(Dim, Dim, this);
			createtable.Hide();
		}

        private void SolveSudoku_Click(object sender, EventArgs e)
        {
            SudokuCells = new int[Dim * Dim];
            for (int i = 0; i < (Dim * Dim); i++)
            {
                if (table.textBoxes[i].Text == "")
                    SudokuCells[i] = 0;
                else if (int.Parse(table.textBoxes[i].Text) > Dim || int.Parse(table.textBoxes[i].Text) < 1)
                {
                    MessageBox.Show("Data it great than your Dimension..");
                }
                else
                {
                    SudokuCells[i] = int.Parse(table.textBoxes[i].Text);
                }
            }

            ValidateSudoku Sol = new ValidateSudoku();
            if (Sol.CheckValidation(SudokuCells, Dim))
            {
                sudoku = new Sudoku(Dim, SudokuCells);

                if (GreadyAlgo.Checked)
                {
                    sudoku.GreadyAlgorithm();
                }
                else {
                    sudoku.Solve();
                }
               
                for (int i = 0; i < (Dim * Dim); i++)
                {
                    table.textBoxes[i].Text = sudoku.SudokuCells[i].ToString();
                }

                // sudoku.DisplayCovers();
            }
            else {
                MessageBox.Show("How Can You Solve It.. :D");
            }
        }

        private void ColorTable_Click(object sender, EventArgs e)
        {
            colorGraph.AssignColor(sudoku.SudokuCells);
            for (int i = 0; i < (Dim * Dim); i++)
            {
                table.textBoxes[i].BackColor = colorGraph.colors[i];
            }

        }
    }
}
