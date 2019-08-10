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

namespace OrganicCompoundVisualizerWPF
{
	/// <summary>
	/// Description of Util.
	/// </summary>
	public class Util
	{
		public static List<Kleur> GetKleuren()
		{
			List<System.Windows.Media.Color> colors = GetColors();
			
			List<Kleur> kleuren = new List<Kleur>();
			
			foreach(System.Windows.Media.Color color in colors)
			{
				Kleur kleur = new Kleur(color);
				kleuren.Add(kleur);
			}
			
			kleuren.RemoveAll(k => String.IsNullOrEmpty(k.Name));			
			return kleuren;
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
		
		
		
	}
}
