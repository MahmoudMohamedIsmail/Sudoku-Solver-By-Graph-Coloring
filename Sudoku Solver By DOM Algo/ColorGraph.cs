using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Sudoku_Solver_By_DOM_Algo
{
    class ColorGraph
    {
       public  Color[] color = { Color.Black, Color.Green, Color.YellowGreen, Color.Turquoise, Color.Brown, Color.Blue, Color.Chocolate, Color.Yellow, Color.Red, Color.SkyBlue, Color.WhiteSmoke ,Color.Tomato,Color.SeaGreen,Color.RosyBrown,Color.Plum,Color.Orchid,Color.MistyRose};
       public Color[] colors;
        public  void AssignColor(int [] Sudoku)
        {
            colors = new Color[Sudoku.Length];
            for(int i=0;i<Sudoku.Length;i++)
            {
                colors[i]= color[(Sudoku[i]+1)%17];
             
            }
       
        }
    }
}
