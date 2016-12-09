using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Solver_By_DOM_Algo
{
    class DominationCoveringAlgorithm
    {
        public GraphNode Node1 = null, Node2 = null;

        public bool Cover(Graph graph)
        {
            for (int i = 0; i < graph.Count; i++)
                for (int j = 0; j < graph.Count; j++)
                {
                    if (i == j) continue;
                    if (graph.Nodes[i].Neighbors.Contains(graph.Nodes[j]) || graph.Nodes[j].Neighbors.Contains(graph.Nodes[i]))
                    {
                        continue;// Adjecent Node
                    }
                    int Intersect = Intersection(graph.Nodes[i], graph.Nodes[j]);
                    if (Intersect == graph.Nodes[i].Neighbors.Count && graph.Nodes[j].Neighbors.Count > Intersect && (graph.Nodes[i].Data == graph.Nodes[j].Data || graph.Nodes[i].Data == 0 || graph.Nodes[j].Data == 0))
                    {
                        if (graph.Nodes[j].Data != graph.Nodes[i].Data && graph.Nodes[j].Data != 0)// ACt 4!=3 and not 0 Node1 not cover node2
                        {
                            continue;
                        }
                        else {
                            graph.Nodes[j].Data = Math.Max(graph.Nodes[j].Data, graph.Nodes[i].Data);
                            graph.Nodes[i].Data = Math.Max(graph.Nodes[j].Data, graph.Nodes[i].Data);
                            Node1 = graph.Nodes[j];
                            Node2 = graph.Nodes[i];
                            return true;
                        }

                    }
                    if (Intersect == graph.Nodes[j].Neighbors.Count && graph.Nodes[i].Neighbors.Count > Intersect && (graph.Nodes[i].Data == graph.Nodes[j].Data || graph.Nodes[i].Data == 0 || graph.Nodes[j].Data == 0))
                    {
                        if (graph.Nodes[j].Data != graph.Nodes[i].Data && graph.Nodes[j].Data != 0)// ACt 4!=3 and not 0 Node1 not cover node2
                        {
                            continue;
                        }
                        else
                        {
                            graph.Nodes[j].Data = Math.Max(graph.Nodes[j].Data, graph.Nodes[i].Data);
                            graph.Nodes[i].Data = Math.Max(graph.Nodes[j].Data, graph.Nodes[i].Data);
                            Node1 = graph.Nodes[i];
                            Node2 = graph.Nodes[j];
                            return true;
                        }
                    }
                }
            return false;
        }
        public int Intersection(GraphNode node1, GraphNode node2)
        {
            int CountIntersection = 0;
            for (int i = 0; i < node1.Neighbors.Count; i++)
                for (int j = 0; j < node2.Neighbors.Count; j++)
                {
                    if (node1.Neighbors[i].ID == node2.Neighbors[j].ID)
                    {
                        CountIntersection++;
                    }
                }
            return CountIntersection;
        }

        public bool PseudoCovering(Graph graph)
        {
            for (int i = 0; i < graph.Count; i++)
                for (int j = 0; j < graph.Count; j++)
                {
                    if (i == j) continue;
                    if (graph.Nodes[i].Neighbors.Contains(graph.Nodes[j]) || graph.Nodes[j].Neighbors.Contains(graph.Nodes[i]))
                    {
                        continue;// Adjecent Node
                    }
                    int Intersect = Intersection(graph.Nodes[i], graph.Nodes[j]);
                    if (Intersect == graph.Nodes[i].Neighbors.Count && graph.Nodes[j].Neighbors.Count == Intersect)
                    {
                        if (graph.Nodes[j].Data != graph.Nodes[i].Data && graph.Nodes[j].Data != 0)// ACt 4!=3 and not 0 Node1 not cover node2
                        {
                            continue;
                        }
                        else
                        {
                            // assign Node1 to the Not color node  AND Delete Most Great Degre
                            graph.Nodes[j].Data = Math.Max(graph.Nodes[j].Data, graph.Nodes[i].Data);
                            graph.Nodes[i].Data = Math.Max(graph.Nodes[j].Data, graph.Nodes[i].Data);

                            if (graph.Nodes[i].Degre >= graph.Nodes[j].Degre)
                            {
                                Node1 = graph.Nodes[j];
                                Node2 = graph.Nodes[i];
                                return true;
                            }
                            else {
                                Node1 = graph.Nodes[i];
                                Node2 = graph.Nodes[j];
                                return true;
                            }
                        }
                    }
                }
            return false;
        }
        public bool CompletGraph(Graph graph)
        {
            for (int i = 0; i < graph.Count; i++)
                for (int j = 0; j < graph.Count; j++)
                {
                    if (i == j) continue;
                    if (!graph.Nodes[i].Neighbors.Contains(graph.Nodes[j]))
                    {
                        return false;
                    }
                }
            return true;
        }
        public Graph Reduction(Graph graph)
        {
            List<int> DeleteNode = new List<int>(); // to avoid erase in tow forloop
            for (int NodeRot = 0; NodeRot < graph.Count; NodeRot++)
            {
                for (int node = 0; node < graph.Count; node++)
                {
                    if (NodeRot == node) continue;
                    if (graph.Nodes[NodeRot].Data == graph.Nodes[node].Data && graph.Nodes[node].Data!=0)
                    {
                        graph.SetColored(graph.Nodes[NodeRot]);
                        graph.SetColored(graph.Nodes[node]);
                        graph.Nodes[NodeRot].Covers.Add(graph.Nodes[node]);

                        DeleteNode.Add(node);
                    }
                }

                // Forloop To Avoid The erase and Decresing Size
                for (int inx = 0; inx < DeleteNode.Count; inx++)
                {
                    graph.RemoveNode(graph.Nodes[DeleteNode[inx]]);
                }
            }

            return graph;
        }
    }
}
