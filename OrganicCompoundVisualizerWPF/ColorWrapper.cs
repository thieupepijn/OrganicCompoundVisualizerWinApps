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
	/// Description of ColorWrapper.
	/// </summary>
	public class ColorWrapper
	{
		public Color Color {get; private set;}
		public string Name { get; private set;}
		
		public ColorWrapper(Color color)
		{
			Color = color;
			Name = Util.GetColorName(color);		
		}
		
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			else 
			{
				ColorWrapper otherKleur = (ColorWrapper)obj;
				return Name.Equals(otherKleur.Name);
			}
		}
		
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}
