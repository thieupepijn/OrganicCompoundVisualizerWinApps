/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 8/10/2019
 * Time: 7:06 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Coordinates2Image;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media;

namespace OrganicCompoundVisualizerWPF
{
	/// <summary>
	/// Description of Painter.
	/// </summary>
	public class Painter :  IPainter
	{
		private Canvas _canvas;
		public Painter(Canvas canvas)
		{
			_canvas = canvas;	
		}
		
		public void DrawBackGround()
		{
			_canvas.Background = new SolidColorBrush(System.Windows.Media.Colors.White);
		}
		
		public void DrawString()
		{
			TextBlock textBlock = new TextBlock();
			textBlock.Text = "Yo";
			textBlock.Background = new SolidColorBrush(System.Windows.Media.Colors.White);
			textBlock.Foreground = new SolidColorBrush(System.Windows.Media.Colors.Black);
			
			Canvas.SetLeft(textBlock, 100);
			Canvas.SetTop(textBlock, 100);
			
			_canvas.Children.Add(textBlock);
		}
		
	}
}
