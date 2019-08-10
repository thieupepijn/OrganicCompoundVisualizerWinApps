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
using System.Windows.Media;
using System.Windows.Shapes;

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
			_canvas.Background = new SolidColorBrush(Colors.White);
		}
		
		public void DrawString(string line, int x, int y)
		{
			TextBlock textBlock = new TextBlock();
			textBlock.Text = line;
			textBlock.Background = new SolidColorBrush(Colors.White);
			textBlock.Foreground = new SolidColorBrush(Colors.Black);
			
			Canvas.SetLeft(textBlock, x);
			Canvas.SetTop(textBlock, y);
			
			_canvas.Children.Add(textBlock);
		}
		
		public void DrawCircle(int centerX, int centerY, int radius)
		{
			Ellipse circle = new Ellipse();
			circle.Fill = new SolidColorBrush(Colors.White);
			circle.Stroke = new SolidColorBrush(Colors.White);
			circle.Width = radius;
			circle.Height = radius;
						
			int x = centerX - (radius / 2);
			int y = centerY - (radius / 2);
			
			Canvas.SetLeft(circle, x);
			Canvas.SetTop(circle, y);
			_canvas.Children.Add(circle);
		}
		
		public void DrawLine(int x1, int y1, int x2, int y2)
		{
			Line line = new Line();
			line.X1 = x1;
			line.Y1 = y1;
			line.X2 = x2;
			line.Y2 = y2;
			line.Stroke = new SolidColorBrush(Colors.Black);
			line.StrokeThickness = 3;
			_canvas.Children.Add(line);			
		}
		
		
	}
}
