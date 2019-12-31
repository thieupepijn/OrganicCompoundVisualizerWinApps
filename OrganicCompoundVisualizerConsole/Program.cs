/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 4/30/2019
 * Time: 7:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Coordinates2Image;
using IUPAC2Image;

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

				Painter painter = new Painter(1000, 1000);
				IUPAC2ImageConverter converter = new IUPAC2ImageConverter(iupacname, 1000, 1000, 125, painter);
				converter.DrawOnCanvas();
				painter.SaveToFile(@"D:\Pepijn\molecuultje.jpg");		
			}
			else
			{
				Console.WriteLine("OrganicCompoundVisualizerConsole <iupac-name> <imagefilepath>");
			}
			
			//	Console.ReadKey(true);
		}
		
		
		
		
		
	}
}