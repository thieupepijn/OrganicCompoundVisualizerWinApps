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
				try
				{
					IUPAC2ImageConverter converter = new IUPAC2ImageConverter(iupacname, imageWidth, imageHeight, verticeLength, painter);
					converter.DrawOnCanvas();
				}
				catch
				{
					string errorMessage = string.Format("Could not generate image of organic compound \"{0}\"", iupacname);
					Console.WriteLine();
					Console.WriteLine(errorMessage);
					return;
				}

				try
				{
					painter.SaveToFile(imageOutputFilePath);
				}
				catch
				{
					string errorMessage = string.Format("Could not write to file \"{0}\"", imageOutputFilePath);
					Console.WriteLine();
					Console.WriteLine(errorMessage);
					return;
				}

				string succesMessage = string.Format("Image of organic compound \"{0}\" written to \"{1}\"", iupacname, imageOutputFilePath);
				Console.WriteLine();
				Console.WriteLine(succesMessage);
			}
			else
			{
				Console.WriteLine("OrganicCompoundVisualizerConsole <iupac-name> <imagefilepath>");
			}
		}
		
		
		
		
		
	}
}