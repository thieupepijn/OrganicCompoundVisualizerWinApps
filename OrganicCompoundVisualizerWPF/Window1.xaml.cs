﻿/*
 * Created by SharpDevelop.
 * User: thieu
 * Date: 5/13/2019
 * Time: 11:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Media;
using System.Collections.Generic;
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
			InitializeColorComboBoxen();
			
		}
		
		
		void BtnDraw_Click(object sender, RoutedEventArgs e)
		{
			string iupacname = txtIupacName.Text.Trim();
			
			try
			{
				DrawingCanvas.Children.Clear();
				
				Color backgroundColor = (Color)cmbBackGroundColor.SelectedValue;
				Color fontColor = (Color)cmbFontColor.SelectedValue;
				Color nodeColor = (Color)cmbNodeColor.SelectedValue;
				Color verticeColor = (Color)cmbVerticeColor.SelectedValue;
					
				int width = (int)DrawingCanvas.ActualWidth;
				int height = (int)DrawingCanvas.ActualHeight;
				
				System.Windows.Media.FontFamily fontFamily = (FontFamily)cmbFontType.SelectedItem;
				int fontSize = Convert.ToInt16(txtFontsize.Text);
				int verticeLength = Convert.ToInt16(txtVerticeLength.Text);
				int verticeThickness = Convert.ToInt16(txtVerticeThickness.Text);
				
				Painter painter = new Painter(DrawingCanvas, backgroundColor, fontColor, fontSize, fontFamily, nodeColor, verticeColor, verticeThickness);
				IUPAC2ImageConverter converter = new IUPAC2ImageConverter(iupacname, width, height, verticeLength, painter);
				converter.DrawOnCanvas();
			}
			catch(Exception exception)
			{
				string errorMessage = string.Format("Cannot process {0}", iupacname);
				MessageBox.Show(errorMessage);
			}
		}

	
		
		private void InitializeColorComboBoxen()
		{			
			List<ColorWrapper> colorWrappers = Util.GetColorWrappers();
		     	
			cmbBackGroundColor.ItemsSource = colorWrappers;
			cmbBackGroundColor.DisplayMemberPath = "Name";
			cmbBackGroundColor.SelectedValuePath = "Color";
			cmbBackGroundColor.SelectedItem = colorWrappers.Find(c => c.Name.Equals("Gray"));

			cmbFontColor.ItemsSource = colorWrappers;
			cmbFontColor.DisplayMemberPath = "Name";
			cmbFontColor.SelectedValuePath = "Color";
			cmbFontColor.SelectedItem = colorWrappers.Find(c => c.Name.Equals("Black"));
			
			cmbNodeColor.ItemsSource = colorWrappers;
			cmbNodeColor.DisplayMemberPath = "Name";
			cmbNodeColor.SelectedValuePath = "Color";
			cmbNodeColor.SelectedItem = colorWrappers.Find(c => c.Name.Equals("Gray"));
			
			cmbVerticeColor.ItemsSource = colorWrappers;
			cmbVerticeColor.DisplayMemberPath = "Name";
			cmbVerticeColor.SelectedValuePath = "Color";
			cmbVerticeColor.SelectedItem = colorWrappers.Find(c => c.Name.Equals("Black"));	

			cmbFontType.ItemsSource = Fonts.SystemFontFamilies;	
			cmbFontType.SelectedItem = Fonts.SystemFontFamilies.First();
			
		}
		
				
		
	}
}