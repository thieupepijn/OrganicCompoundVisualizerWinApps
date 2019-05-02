/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 4/30/2019
 * Time: 7:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using IUPAC2Formula;
using Formula2Graph;

namespace OrganicCompoundVisualizerConsole
{
	class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				IUPACCompound compound = new IUPACCompound(args[0]);
				string formula = compound.ShowFormula();
				Chain mainChain = new Chain(formula, null);
				
				Console.WriteLine(formula);
				Console.WriteLine(string.Join(";", mainChain.Nodes));
				Console.WriteLine(string.Join(Environment.NewLine, mainChain.Vertices));
			}
			
			Console.ReadKey(true);
		}
	}
}