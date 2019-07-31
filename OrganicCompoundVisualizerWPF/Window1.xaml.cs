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
			InitializeColorComboBoxen();
		
		}
		
		
		void BtnDraw_Click(object sender, RoutedEventArgs e)
		{
			
			int width = (int)this.Width;
			int height = (int)this.Height;
			
			string iupacname = txtIupacName.Text.Trim();
			
			try
			{
				Color backgroundColor = GetSelectedColor(cmbBackGroundColor);
				Brush fontBrush = GetSelectedColorAsBrush(cmbFontColor);
				Brush nodeBrush = GetSelectedColorAsBrush(cmbNodeColor);
				Brush verticeBrush = GetSelectedColorAsBrush(cmbVerticeColor);
				
				IUPAC2ImageConverter converter = new IUPAC2ImageConverter(iupacname, width, height, 15, 100, 2, backgroundColor, fontBrush, nodeBrush, verticeBrush);
				imgIUPAC.Source = converter.DrawToBitmapImage();
			}
			catch(Exception exception)
			{
				string errorMessage = string.Format("Cannot process {0}", iupacname);
				MessageBox.Show(errorMessage);
			}
		}
		
		
		private void InitializeColorComboBoxen()
		{
		  cmbBackGroundColor.ItemsSource = typeof(Color).GetProperties();
		  cmbBackGroundColor.DisplayMemberPath = "Name";
		  cmbBackGroundColor.SelectedValuePath = "Name";
		  cmbBackGroundColor.SelectedIndex = 1;	

		  cmbFontColor.ItemsSource = typeof(Color).GetProperties();
		  cmbFontColor.DisplayMemberPath = "Name";
		  cmbFontColor.SelectedValuePath = "Name";
		  cmbFontColor.SelectedIndex = 1;	
		  
		  cmbNodeColor.ItemsSource = typeof(Color).GetProperties();
		  cmbNodeColor.DisplayMemberPath = "Name";
		  cmbNodeColor.SelectedValuePath = "Name";
		  cmbNodeColor.SelectedIndex = 1;
		  
		  cmbVerticeColor.ItemsSource = typeof(Color).GetProperties();
		  cmbVerticeColor.DisplayMemberPath = "Name";
		  cmbVerticeColor.SelectedValuePath = "Name";
		  cmbVerticeColor.SelectedIndex = 1;
		  
		  
		}
		
		
		private Color GetSelectedColor(System.Windows.Controls.ComboBox combobox)
		{
			string colorName = combobox.SelectedValue.ToString();
			return (Color)new ColorConverter().ConvertFromString(colorName);
		}
		
		private Brush GetSelectedColorAsBrush(System.Windows.Controls.ComboBox combobox)
		{
			Color color = GetSelectedColor(combobox);
			return new SolidBrush(color);
		}
		
	}
}