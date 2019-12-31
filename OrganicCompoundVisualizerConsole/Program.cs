/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 4/30/2019
 * Time: 7:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using IUPAC2Image;
using System;

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

				int imageWidth = 1500;
				int imageHeight = 1000;
				int verticeLength = 125;
				int verticeThickness = 3;
				int fontSize = 15;

				Painter painter = new Painter(imageWidth, imageHeight, verticeThickness, fontSize);
				IUPAC2ImageConverter converter = new IUPAC2ImageConverter(iupacname, imageWidth, imageHeight, verticeLength, painter);
				converter.DrawOnCanvas();
				painter.SaveToFile(imageOutputFilePath);
			}
			else
			{
				Console.WriteLine("OrganicCompoundVisualizerConsole <iupac-name> <imagefilepath>");
			}
		}
		
		
		
		
		
	}
}