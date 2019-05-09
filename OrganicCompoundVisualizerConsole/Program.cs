/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 4/30/2019
 * Time: 7:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using IUPAC2Formula;
using Formula2Graph;
using Graph2Coordinates;
using Coordinates2Image;

namespace OrganicCompoundVisualizerConsole
{
	class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length > 1)
			{
				string iupacname = args[0];
				string imageOutputFilePath = args[1];
				
				string formula = GetFormula(iupacname);
				Chain graph = GetGraph(formula);
				
				string nodesLine = GraphNodes2Line(graph);
				List<string> verticesLines = GraphVertices2Lines(graph);
				
				List<Graph2Coordinates.Node> nodes = new List<Graph2Coordinates.Node>();
				UtilNodesAndVertices.InitNodesFromLine(nodesLine, nodes);
				
				List<Graph2Coordinates.Vertice> vertices = new List<Graph2Coordinates.Vertice>();
				UtilNodesAndVertices.InitVerticesFromLines(verticesLines, nodes, vertices);
				
				UtilNodesAndVertices.InitializeNodeLocations(nodes, vertices);
				UtilNodesAndVertices.Reposition(nodes, vertices, 1000, 1000);
				//	UtilDrawing.DrawEverything(canvas, nodes, vertices);
				
				//Console.WriteLine(formula);
				//Console.WriteLine(string.Join(";", mainChain.Nodes));
				//Console.WriteLine(string.Join(Environment.NewLine, mainChain.Vertices));	
				Drawer drawer = new Drawer(nodes, vertices, 1000, 1000, imageOutputFilePath);
			}
			else 
			{
				Console.WriteLine("OrganicCompoundVisualizerConsole <iupac-name> <imagefilepath>");
			}
			
		//	Console.ReadKey(true);
		}
		
		private static string GetFormula(string line)
		{
			IUPACCompound compound = new IUPACCompound(line);
			return compound.ShowFormula();
		}
		
		private static Chain GetGraph(string formula)
		{
			return new Chain(formula, null);
		}
		
		private static string GraphNodes2Line(Chain graph)
		{
			return string.Join(";", graph.Nodes);
		}
		
		private static List<string> GraphVertices2Lines(Chain graph)
		{
			List<string> lines = new List<string>();
			graph.Vertices.ForEach(v => lines.Add(v.ToString()));
			return lines;
		}
		
		
		
		
	}
}