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
				Console.WriteLine(formula);
			}
			// TODO: Implement Functionality Here
			
		//	Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}