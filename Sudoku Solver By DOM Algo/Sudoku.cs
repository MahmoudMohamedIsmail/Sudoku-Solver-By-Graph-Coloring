using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Windows.Forms;


namespace Sudoku_Solver_By_DOM_Algo
{
	class Sudoku
	{
		public Graph graph, graph2;
		public int[] SudokuCells;
		public int Dim;
		public DominationCoveringAlgorithm Check;
		public List<GraphNode> Uncovers = new List<GraphNode>();
		public List<GraphNode> TempNodes = new List<GraphNode>();
		int[] Color;
		int[] VisitedColor;
		int[] FrequencyColor;
		int Countercolor = 1;

		// ----------------------------------------------------
		// 'Initialize Sudoku and Graph '.
		// ----------------------------------------------------
		public Sudoku(int Dimension, int[] sudokuCells)
		{

			Dim = Dimension;
			SudokuCells = sudokuCells;
			graph = new Graph();
			graph2 = new Graph();
			Check = new DominationCoveringAlgorithm();
			InitSudoku();
			InitColorAndVisit(Dim);

		}
		public void InitColorAndVisit(int Dim)
		{
			Color = new int[Dim + 1];
			VisitedColor = new int[Dim + 1];
			FrequencyColor = new int[Dim + 1];
			for (int i = 0; i < Dim + 1; i++)
			{
				Color[i] = i;
				VisitedColor[i] = 0;
				FrequencyColor[i] = 0;
			}
			VisitedColor[0] = 1;
		}
		public void InitSudoku()
		{
			for (int i = 0; i < (Dim * Dim); i++)
			{
				graph2.AddNode(SudokuCells[i]);
				graph.AddNode(SudokuCells[i]);

			}
			SetEdegsOfGraph();
			graph.Sort();

		}
		public void SetEdegsOfGraph()
		{
			// Set Neighbors For all Nodes
			for (int i = 0; i < graph.Count; i++)
			{
				RowEdges(i);
				ColEdges(i);
			}
			SquareEdges();
		}
		public void RowEdges(int inx)
		{
			for (int i = ((inx / Dim) * Dim); i < ((inx / Dim) * Dim) + Dim; i++)
			{
				if (i == inx) continue;// Not conected to itself
				graph.AddUndirectedEdge(graph.Nodes[inx], graph.Nodes[i]);
				// TEmp graph2
				graph2.AddUndirectedEdge(graph2.Nodes[inx], graph2.Nodes[i]);
			}
		}
		public void ColEdges(int inx)
		{
			int Col = 0;
			bool flag = true;

			for (int i = 0; i < Dim && flag; i++)
				for (int j = 0; j < Dim; j++)
				{
					if ((i * Dim + j) == inx)
					{
						Col = j;
						flag = false;
					}

				}
			for (int i = 0; i < Dim; i++)
			{
				if (inx == (i * Dim + Col)) continue;// Not conected to itself
				graph.AddUndirectedEdge(graph.Nodes[inx], graph.Nodes[(i * Dim + Col)]);
				//Temp
				graph2.AddUndirectedEdge(graph2.Nodes[inx], graph2.Nodes[(i * Dim + Col)]);

			}
		}
		public void SquareEdges()
		{
			int interval = Dim / (int.Parse(Math.Sqrt(Dim).ToString()));
			// Squares
			for (int r = 0; r < interval; r++)
				for (int c = 0; c < interval; c++)

					// For each square
					for (int i = (r * interval); i < (r * interval) + interval; i++)
						for (int j = (c * interval); j < (c * interval) + interval; j++)
						{

							//Loop in this Square (i,j).....
							for (int x = (r * interval); x < (r * interval) + interval; x++)
								for (int y = (c * interval); y < (c * interval) + interval; y++)
								{
									if (i == x && j == y) continue;// Ignor itself
									graph.AddUndirectedEdge(graph.Nodes[i * Dim + j], graph.Nodes[(x * Dim + y)]);
									//Temp
									graph2.AddUndirectedEdge(graph2.Nodes[i * Dim + j], graph2.Nodes[(x * Dim + y)]);


								}
						}
		}

		// ----------------------------------------------------
		// End of  'Initialize Sudoku and Graph '.
		// ----------------------------------------------------



		// ----------------------------------------------------
		// 'Solve Sudoku'.
		// ----------------------------------------------------
		public void Solve()
		{

			graph = Check.Reduction(graph);
			//Domination Covering Algorithm
			while (!Check.CompletGraph(graph))
			{
				if (Check.Cover(graph))
				{
					if (Check.Node1.Data > 0) //Set Color
						graph.SetColored(Check.Node1);

					if (Check.Node2.Data > 0) // Set Color
						graph.SetColored(Check.Node2);

					graph.AddCoverNode(Check.Node1, Check.Node2);
					graph.RemoveNode(Check.Node2);

				}
				else if (Check.PseudoCovering(graph))
				{
					if (Check.Node1.Data > 0) //Set Color
						graph.SetColored(Check.Node1);
					if (Check.Node2.Data > 0) // Set Color
						graph.SetColored(Check.Node2);

					graph.AddCoverNode(Check.Node1, Check.Node2);
					graph.RemoveNode(Check.Node2);
				}
				else
				{
					graph.Sort();// Sort by its Degre
					GraphNode node = graph.Nodes[0];
					Uncovers.Add(node);// Great Degre
					graph.RemoveNode(node);
				}



			}

			// DisplayGraph();
			ColorCompletGraph();

			ColorUncoverNodes();
			ColorReminderNode();

		}
		public void GetFrequencyColor()
		{
			bool[] VistedNode = new bool[Dim * Dim];
			//first For Graph
			foreach (var node in graph.Nodes)
			{
				if (!VistedNode[node.ID])
				{
					VistedNode[node.ID] = true;
					FrequencyColor[node.Data]++;
					// For All Covers of this node
					for (int i = 0; i < node.Covers.Count; i++)
					{
						if (!VistedNode[node.Covers[i].ID])
						{
							VistedNode[node.ID] = true;
							FrequencyColor[node.Data]++;
						}

					}

				}
			}

			//Second For UnCovers
			foreach (var node in Uncovers)
			{
				if (!VistedNode[node.ID])
				{
					VistedNode[node.ID] = true;
					FrequencyColor[node.Data]++;
					// For All Covers of this node
					for (int i = 0; i < node.Covers.Count; i++)
					{
						if (!VistedNode[node.Covers[i].ID])
						{
							VistedNode[node.ID] = true;
							FrequencyColor[node.Data]++;
						}

					}

				}

			}

		}
		public List<int> AvailableColor()
		{
			List<int> available = new List<int>();
			for (int i = 1; i <= Dim; i++)
			{
				if (FrequencyColor[i] < Dim)
				{
					available.Add(i);
				}

			}
			return available;
		}
		//mmkn aCheck hna l Cells but not node color 
		public bool CheckColorForNode(GraphNode node, int color)
		{

			for (int nodes = 0; nodes < graph2.Nodes.Count; nodes++)
			{
				if (graph2.Nodes[nodes].ID == node.ID)
				{
					for (int i = 0; i < graph2.Nodes[nodes].Neighbors.Count; i++)
					{
						if (SudokuCells[graph2.Nodes[nodes].Neighbors[i].ID] == color)
							return false;
					}
					return true;
				}
			}
			return false;
		}
		public void ColorItsCovers(GraphNode node, int color)
		{
			SudokuCells[node.ID] = color;
			node.Data = color;
			foreach (var nodes in node.Covers)
			{
				SudokuCells[nodes.ID] = color;
				nodes.Data = color;
			}
		}
		public void ColorCompletGraph()
		{
			List<int> AvailableColors = AvailableColor();
			int[] Visited = new int[AvailableColors.Count];
			foreach (var node in graph.Nodes)
			{
				if (node.Data == 0)
				{
					for (int i = 0; i < AvailableColors.Count; i++)
					{
						if (Visited[i] == 0)
						{
							if (CheckColorForNode(node, AvailableColors[i]))
							{
								Visited[i] = 1;
								node.Data = AvailableColors[i];
								ColorItsCovers(node, AvailableColors[i]);
								break;
							}

						}
					}
				}
			}

		}

		public bool CheckColorForCovers(GraphNode node, int color)
		{

			for (int nodes = 0; nodes < node.Covers.Count; nodes++)
			{
				if (!CheckColorForNode(node.Covers[nodes], color))
				{
					return false;
				}
			}
			return true;
		}
		public void ColorUncoverNodes()
		{
			for (int node = Uncovers.Count - 1; node >= 0; node--)
			{
				if (Uncovers[node].Data > 0)
				{
					ColorItsCovers(Uncovers[node], Uncovers[node].Data);
				}
				else
				{
					for (int color = 1; color <= Dim; color++)
					{

						if (CheckColorForNode(Uncovers[node], color))
						{
							if (CheckColorForCovers(Uncovers[node], color))
							{
								Uncovers[node].Data = color;
								SudokuCells[Uncovers[node].ID] = color;
								ColorItsCovers(Uncovers[node], color);
								break;
							}
						}

					}
				}
				DisplayUnCover();
				DisplaySudoku();

			}

		}
		public void AssignGraphToGraph(Graph graph2)
		{
			foreach (var node in graph.Nodes)
			{
				graph2.AddNode(node);
			}
		}

		public void ColorReminderNode()
		{
			for (int node = 0; node < Dim * Dim; node++)
			{
				if (SudokuCells[node] == 0)
				{
					for (int color = 1; color <= Dim; color++)
					{
						if (CheckColorForNode(graph2.Nodes[node], color))
						{
							SudokuCells[node] = color;
							break;
						}
					}
				}
			}
		}
		public void GreadyAlgorithm()
		{
			graph = Check.Reduction(graph);
			while (graph.Count > 0)
			{
				graph.Sort();
				List<GraphNode> DeleteNode = new List<GraphNode>(); // to avoid erase in tow forloop
				foreach (var nodes in graph.Nodes)
				{
					for (int color = 1; color <= Dim; color++)
						if (CheckColorForNode(nodes, color))
						{
							SudokuCells[nodes.ID] = color;
							nodes.Data = color;
							DeleteNode.Add(nodes);
							break;
						}
				}
				// Countercolor++;
				// Forloop To Avoid The erase and Decresing Size
				for (int inx = 0; inx < DeleteNode.Count; inx++)
				{
					graph.RemoveNode(DeleteNode[inx]);
				}

			}
			ColorCompletGraph();

			ColorUncoverNodes();
		}

		// ----------------------------------------------------
		// End of 'Solve Sudoku'.
		// ----------------------------------------------------

		// ----------------------------------------------------
		//  'Helper Function To Test My code'.
		// ----------------------------------------------------

		//public void DisplayCovers()
		//{
		//    FileStream f = new FileStream(@"C:\Users\mahmoud\Documents\Visual Studio 2013\Projects\Sudoku Solver By DOM Algo\Sudoku Solver By DOM Algo\Test.txt", FileMode.Append);
		//    StreamWriter sw = new StreamWriter(f);
		//    sw.WriteLine();
		//    sw.WriteLine("///////////////..... Start..... Covering//////////");

		//    //for (int i = 0; i < CoversNode.Count; i++)
		//    //{
		//    //    sw.Write("(" + CoversNode[i].Node.ID.ToString()/* + "," + CoversNode[i].Node.Data.ToString()*/ + " )...= { ");
		//    //    for (int j = 0; j < CoversNode[i].Covers.Count; j++)
		//    //    {
		//    //        sw.Write(",(" + CoversNode[i].Covers[j].ID.ToString()/* + "," + CoversNode[i].Covers[j].Data.ToString() */+ ") ");

		//    //    }
		//    //    sw.WriteLine(" }");
		//    //}
		//    sw.WriteLine("//////////////////......End..... Covering//////////");
		//    sw.WriteLine();
		//    sw.Close();
		//    f.Close();
		//}
		public void DisplayGraph()
		{
			FileStream f = new FileStream(@"\\vmware-host\Shared Folders\Fourth\MathematicalPro\Lab\Sudoku Solver By Graph Coloring\Sudoku Solver By DOM Algo\WHY.txt", FileMode.Append);
			StreamWriter sw = new StreamWriter(f);
			sw.WriteLine("++");

			sw.WriteLine("//////////////////..... Start.. Graph//////////");

			for (int i = 0; i < graph2.Count; i++)
			{
				sw.Write("(" + graph2.Nodes[i].ID.ToString() + "," + graph2.Nodes[i].Data.ToString() + ")...= { ");
				for (int j = 0; j < graph2.Nodes[i].Neighbors.Count; j++)
				{

					sw.Write(",(" + graph2.Nodes[i].Neighbors[j].ID.ToString() + "," + graph2.Nodes[i].Neighbors[j].Data.ToString() + ") ");

				}
				sw.WriteLine(" }");
			}
			sw.WriteLine(" ////////////.....End.....  Graph//////////");
			sw.WriteLine("++");

			sw.Close();
			f.Close();
		}

		public void DisplayUnCover()
		{
			FileStream f = new FileStream(@"\\vmware-host\Shared Folders\Fourth\MathematicalPro\Lab\Sudoku Solver By Graph Coloring\Sudoku Solver By DOM Algo\Test.txt", FileMode.Append);
			StreamWriter sw = new StreamWriter(f);
			sw.WriteLine();
			sw.WriteLine("///////////////..... Start..... UNCOVERING//////////");
			for (int j = 0; j < Uncovers.Count; j++)
			{
				sw.Write("(" + Uncovers[j].ID.ToString() + "," + Uncovers[j].Data.ToString() + "), ");

			}
			sw.WriteLine();
			sw.WriteLine("//////////////////......End..... UNCOVERING//////////");
			sw.WriteLine();
			sw.Close();
			f.Close();
		}
		public void DisplaySudoku()
		{
			FileStream f = new FileStream(@"\\vmware-host\Shared Folders\Fourth\MathematicalPro\Lab\Sudoku Solver By Graph Coloring\Sudoku Solver By DOM Algo\WHY.txt", FileMode.Append);
			StreamWriter sw = new StreamWriter(f);

			sw.WriteLine("//////////////////..... Start.. //////////");

			for (int i = 0; i < Dim; i++)
			{
				for (int j = 0; j < Dim; j++)
				{

					sw.Write(SudokuCells[i * Dim + j] + " ");

				}
				sw.WriteLine();
			}
			sw.WriteLine(" ////////////.....End.....  //////////");
			sw.Close();
			f.Close();
		}
		// ----------------------------------------------------
		// END OF  'Helper Function To Test My code'.
		// ----------------------------------------------------
	}
}
