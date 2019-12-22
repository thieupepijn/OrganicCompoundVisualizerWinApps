/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 8/10/2019
 * Time: 9:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Globalization;
using System.Windows;

namespace OrganicCompoundVisualizerWPF
{
	
	public class Util
	{
		public static List<ColorWrapper> GetColorWrappers()
		{
			List<System.Windows.Media.Color> colors = GetColors();
			
			List<ColorWrapper> colorWrappers = new List<ColorWrapper>();
			
			foreach(System.Windows.Media.Color color in colors)
			{
				ColorWrapper colorWrapper = new ColorWrapper(color);
				colorWrappers.Add(colorWrapper);
			}
			
			colorWrappers.RemoveAll(k => String.IsNullOrEmpty(k.Name));
			return colorWrappers.Distinct().OrderBy(c => c.Name).ToList();
		}
		
		private static List<System.Windows.Media.Color> GetColors()
		{
			List<System.Windows.Media.Color> rv = new List<System.Windows.Media.Color>();
			
			foreach(KnownColor color in Enum.GetValues(typeof(KnownColor)))
			{
				System.Drawing.Color col = System.Drawing.Color.FromKnownColor(color);
				rv.Add(System.Windows.Media.Color.FromArgb(col.A, col.R, col.G, col.B));
			}
			return rv;
		}
		
		
		public static string GetColorName(System.Windows.Media.Color color)
		{
			Type colors = typeof(System.Windows.Media.Colors);
			foreach(var prop in colors.GetProperties())
			{
				if(((System.Windows.Media.Color)prop.GetValue(null, null)) == color)
				{
					return prop.Name;
				}
			}
			return null;
		}
		
		public static System.Windows.Size MeasureTextBlockSize(TextBlock textblock)
		{
			System.Windows.Media.Typeface typeFace = new System.Windows.Media.Typeface(textblock.FontFamily, textblock.FontStyle, textblock.FontWeight, textblock.FontStretch);		
			System.Windows.Media.FormattedText formattedText = new System.Windows.Media.FormattedText(textblock.Text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, 
			                                                                            typeFace, textblock.FontSize, textblock.Foreground);
			return new System.Windows.Size(formattedText.Width, formattedText.Height);
		}

		
		
		
	}
}
