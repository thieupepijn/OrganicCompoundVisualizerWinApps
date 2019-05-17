/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/13/2019
 * Time: 11:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using IUPAC2Image;

namespace OrganicCompoundVisualizerWPF
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		void BtnDraw_Click(object sender, RoutedEventArgs e)
		{
			
			int width = (int)this.Width;
			int height = (int)this.Height;
			
			string iupacname = txtIupacName.Text.Trim();	
			
			IUPAC2ImageConverter converter = new IUPAC2ImageConverter(iupacname, width, height);	
			imgIUPAC.Source = converter.DrawToBitmapImage();
		}
		
		
		
		
	}
}