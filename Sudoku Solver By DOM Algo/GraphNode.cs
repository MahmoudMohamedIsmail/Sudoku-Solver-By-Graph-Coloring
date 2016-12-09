using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sudoku_Solver_By_DOM_Algo
{
   
    class GraphNode
    {

        #region Constructors

        public GraphNode(int data,int Id)
        {
            ID = Id;
            Data = data;
            Degre = 0;
            Neighbors = new List<GraphNode>();
            Covers = new List<GraphNode>();

            if (data > 0)
                Colored = 1;
            else
                Colored = 0;
        }

        #endregion

        #region Properties


        public int ID{ get; set; }
        public int Data { get; set; }
        public int Degre { get; set; }
        public int Colored { get; set; }
        /// <summary>
        /// Returns the set of neighbors for this graph node.
        /// </summary>
        public List<GraphNode> Neighbors { get; private set; }
        public List<GraphNode> Covers { get; private set; }

        
        #endregion
        public bool Contains(List<GraphNode> neighbors,GraphNode node)
        {
            for (int i = 0; i < neighbors.Count; i++)
            {
                if (neighbors[i].ID == node.ID)
                    return true;
            }
            return false;
        }

       
    }
}
