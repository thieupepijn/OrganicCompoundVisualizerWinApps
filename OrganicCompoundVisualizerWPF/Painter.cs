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
using System.Windows;

namespace OrganicCompoundVisualizerWPF
{
	/// <summary>
	/// Description of Painter.
	/// </summary>
	public class Painter :  IPainter
	{
		private Canvas _canvas;
		private Color _backgroundColor;
		private Color _fontColor;
		private Color _nodeColor;
		private Color _verticecolor;
		private int _fontSize;
		private FontFamily _fontFamily;
		
		public Painter(Canvas canvas, Color backgroundColor, Color fontColor, int fontSize, FontFamily fontFamily, Color nodeColor, Color verticeColor, int verticeThickness)
		{
			_canvas = canvas;	
			_backgroundColor = backgroundColor;
			_fontColor = fontColor;
			_fontSize = fontSize;
			_fontFamily = fontFamily;
			_nodeColor = nodeColor;
			_verticecolor = verticeColor;
			LineThickness = verticeThickness;
		}
		
		public void DrawBackGround()
		{
			_canvas.Background = new SolidColorBrush(_backgroundColor);
		}
		
		public void DrawString(string line, int centerX, int centerY)
		{
			TextBlock textBlock = new TextBlock();
			textBlock.FontSize = _fontSize;
			textBlock.FontFamily = _fontFamily;
			textBlock.Text = line;
			textBlock.Background = new SolidColorBrush(_backgroundColor);
			textBlock.Foreground = new SolidColorBrush(_fontColor);
			Size textBlockSize = Util.MeasureTextBlockSize(textBlock);
			int textBlockWidth = (int)textBlockSize.Width;
			int textblockHeight = (int)textBlockSize.Height;
			
			Canvas.SetLeft(textBlock, centerX - (textBlockWidth / 2));
			Canvas.SetTop(textBlock, centerY - (textblockHeight / 2));
			
			_canvas.Children.Add(textBlock);
		}
		
		public int GetPixelWidthOfString(string line)
		{
			TextBlock textBlock = new TextBlock();
			textBlock.Text = line;
			return (int)Util.MeasureTextBlockSize(textBlock).Width;
		}
		
		public void DrawCircle(int centerX, int centerY, int radius)
		{
			Ellipse circle = new Ellipse();
			circle.Fill = new SolidColorBrush(_nodeColor);
			circle.Stroke = new SolidColorBrush(_nodeColor);
			circle.Width = radius;
			circle.Height = radius;
						
			int x = centerX - (radius / 2);
			int y = centerY - (radius / 2);
			
			Canvas.SetLeft(circle, x);
			Canvas.SetTop(circle, y);
			_canvas.Children.Add(circle);
		}
		
		public int LineThickness{get; set;}
		
		
		public void DrawLine(int x1, int y1, int x2, int y2, int thickness)
		{
			Line line = new Line();
			line.X1 = x1;
			line.Y1 = y1;
			line.X2 = x2;
			line.Y2 = y2;
			line.Stroke = new SolidColorBrush(_verticecolor);
			line.StrokeThickness = thickness;
			_canvas.Children.Add(line);			
		}
		
		
	}
}
