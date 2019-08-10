/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 8/10/2019
 * Time: 10:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Media;

namespace OrganicCompoundVisualizerWPF
{
	/// <summary>
	/// Description of Kleur.
	/// </summary>
	public class Kleur
	{
		public Color Color {get; private set;}
		public string Name { get; private set;}
		
		public Kleur(Color color)
		{
			Color = color;
			Name = Util.GetColorName(color);		
		}
	}
}
