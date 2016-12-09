using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Sudoku_Solver_By_DOM_Algo
{

    class Graph : ICloneable
    {
        #region fields

        public List<GraphNode> Nodes;

        int Id;

        #endregion

        #region Constructors
        public Graph()
        {
            Id = 0;
            Nodes = new List<GraphNode>();
           
        }
        /// <summary>
        /// Initialize a new Graph instance.
        /// </summary>
        /// <param name="nodeSet">The initial set of nodes in the graph.</param>
        public Graph(List<GraphNode> nodeSet)
        {
            if (nodeSet == null)
                Nodes = new List<GraphNode>();
            else
                Nodes = nodeSet;
        }
        public Graph DeepCopy()
        {
            Graph other = (Graph)this.MemberwiseClone();
            other.Nodes =Nodes;
            
            return other;
        }
        public object Clone()
        {
            return new Graph
            {
                Nodes = this.Nodes,
                Id = this.Id
            };
        }

        #endregion

        #region Properties


        /// <summary>
        /// Returns the number of vertices in the graph.
        /// </summary>
        public int Count
        {
            get { return Nodes.Count; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new GraphNode instance to the Graph
        /// </summary>
        /// <param name="node">The GraphNode instance to add.</param>
        public void AddNode(GraphNode node)
        {
            // adds a node to the graph
            Nodes.Add(node);
        }

        /// <summary>
        /// Adds a new value to the graph.
        /// </summary>
        /// <param name="value">The value to add to the graph</param>
        public void AddNode(int value)
        {
            Nodes.Add(new GraphNode(value,Id));
            Id++;
        }


      
        /// <summary>
        /// Adds an undirected edge from one GraphNode to another.
        /// </summary>
        /// <param name="fromNode">One of the GraphNodes that is joined by the edge.</param>
        /// <param name="toNode">One of the GraphNodes that is joined by the edge.</param>
        public void AddUndirectedEdge(GraphNode fromNode, GraphNode toNode)
        {
            if (fromNode == null || toNode == null) return;

            if (fromNode.Neighbors.Contains(toNode) || toNode.Neighbors.Contains(fromNode)) return;

            fromNode.Neighbors.Add(toNode);
            fromNode.Degre++;

            toNode.Neighbors.Add(fromNode);
            toNode.Degre++;
        }

        /// <summary>
        /// Clears out the contents of the Graph.
        /// </summary>
        public void Clear()
        {
            Nodes.Clear();
        }

        /// <summary>
        /// Returns a Boolean, indicating if a particular value exists within the graph.
        /// </summary>
        /// <param name="Node">The value to search for.</param>
        /// <returns>True if the value exist in the graph; false otherwise.</returns>
        public bool Contains(GraphNode node)
        {
            foreach(var nodes in Nodes)
            {
                if (nodes.ID == node.ID)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Attempts to remove a node from a graph.
        /// </summary>
        /// <param name="Node">The value that is to be removed from the graph.</param>
        /// <returns>True if the corresponding node was found, and removed; false if the value was not
        /// present in the graph.</returns>
        /// <remarks>This method removes the GraphNode instance, and all edges leading to or from the
        /// GraphNode.</remarks>
        public bool RemoveNode(GraphNode node)
        {
            // first remove the node from the nodeset
           
            if (!Contains(node))// Check if node exist
                return false;
        
            // otherwise, the node was found
            foreach (var nodes in Nodes)
            {
                if (nodes.ID == node.ID)
                {
                    Nodes.Remove(nodes);
                    break;
                }

            }
           
            // enumerate through each node in the nodeSet, removing edges to this node
            foreach (var nodes in Nodes)
            {
                // remove the reference to the node.
                if (nodes.Contains(nodes.Neighbors,node))
                {
                    foreach (var nod in nodes.Neighbors)
                    {
                        if (nod.ID == node.ID)
                        {
                            nodes.Neighbors.Remove(nod);
                            nodes.Degre--;
                            break;
                        }
                      
                    }
                   
                }
            }

            return true;
        }
        public void Sort()
        {
            for (int i = 0; i < Nodes.Count; i++)
            {
                GraphNode CurNode = Nodes[i];
                int inx = i;
                for (int j = i + 1; j < Nodes.Count; j++)
                {
                    if (Nodes[j].Degre > CurNode.Degre)
                    {
                        CurNode = Nodes[j];
                        inx = j;
                    }
                }

                Nodes[inx] = Nodes[i];
                Nodes[i] = CurNode;
            }
        }

        public void SetColored(GraphNode node)
        {
            foreach (var nodes in Nodes)
            {
                if (nodes.ID == node.ID)
                {
                    nodes.Colored = 1;
                    return;
                }
            }
        }
        public void AddCoverNode(GraphNode node1, GraphNode node2)
        {
            foreach (var node in Nodes)
            {
                if (node.ID == node1.ID)
                {
                    bool color = false;
                    if (node.Data > 0) color = true;
                    if (color) node2.Colored = 1;
                    //First add Node Itself
                    node.Covers.Add(node2);
                    

                    //Check Exist Node in Covers
                    for (int i = 0; i < node2.Covers.Count; i++)
                    {
                        if (color) node2.Covers[i].Colored = 1;
                        node.Covers.Add(node2.Covers[i]);
                    }
                    return;
                }
            }
        }
     
        #endregion
    }
}
