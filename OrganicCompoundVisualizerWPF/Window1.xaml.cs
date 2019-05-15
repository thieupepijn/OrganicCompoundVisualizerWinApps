/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/13/2019
 * Time: 11:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using IUPAC2Formula;
using Formula2Graph;
using Graph2Coordinates;
using Coordinates2Image;

namespace OrganicCompoundVisualizerWPF
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		void BtnDraw_Click(object sender, RoutedEventArgs e)
		{
			
			int width = (int)this.Width;
			int height = (int)this.Height;
			
			string iupacname = txtIupacName.Text.Trim();	
			string formula = GetFormula(iupacname);
			Chain graph = GetGraph(formula);
			
			string nodesLine = GraphNodes2Line(graph);
			List<string> verticesLines = GraphVertices2Lines(graph);
			
			List<Graph2Coordinates.Node> nodes = new List<Graph2Coordinates.Node>();
			UtilNodesAndVertices.InitNodesFromLine(nodesLine, nodes);
			
			List<Graph2Coordinates.Vertice> vertices = new List<Graph2Coordinates.Vertice>();
			UtilNodesAndVertices.InitVerticesFromLines(verticesLines, nodes, vertices);
			
			UtilNodesAndVertices.InitializeNodeLocations(nodes, vertices);
			UtilNodesAndVertices.Reposition(nodes, vertices, width, height);
			
			Drawer drawer = new Drawer(nodes, vertices, width, height);
			imgIUPAC.Source = drawer.Draw2BitmapImage();
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