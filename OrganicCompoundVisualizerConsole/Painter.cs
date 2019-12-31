using Coordinates2Image;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace OrganicCompoundVisualizerConsole
{
    public class Painter : IPainter
    {
        private Graphics _graafix;
        private Bitmap _bitmap;
        private Font _font;

        public Painter(int width, int height)
        {
            _bitmap = new Bitmap(width, height);
            _graafix = Graphics.FromImage(_bitmap);
            _font = new Font("Arial", 15, FontStyle.Regular);
            LineThickness = 5;

        }
        
        public void SaveToFile(string filePath)
        {
            _bitmap.Save(filePath, ImageFormat.Jpeg);
        }

        #region IPainter interface
        public int LineThickness { get; set; }

        public void DrawBackGround()
        {
            _graafix.FillRectangle(Brushes.White, new Rectangle(0, 0, _bitmap.Width, _bitmap.Height));
        }

        public void DrawCircle(int centerX, int centerY, int radius)
        {
            int oneandhalfradius = (int)(radius * 1.5);
            int tripleradius = radius * 3;
            _graafix.FillEllipse(Brushes.White, centerX - oneandhalfradius, centerY - oneandhalfradius, tripleradius, tripleradius);
        }

        public void DrawLine(int x1, int y1, int x2, int y2, int thickness)
        {
            Pen pen = new Pen(Brushes.Black, thickness);
            _graafix.DrawLine(pen, x1, y1, x2, y2);
        }

        public void DrawString(string line, int centerX, int centerY)
        {
            int textWidth = GetPixelWidthOfString(line);
            int halftextWidth = textWidth / 2;
            int textHeight = GetPixelHeightOfString(line);
            int halftextHeight = textHeight / 2;
            _graafix.DrawString(line, _font, Brushes.Black, centerX - halftextWidth, centerY - halftextHeight);
        }

        public int GetPixelHeightOfString(string line)
        {
            int height = (int)_graafix.MeasureString(line, _font).Height;
            return height;
        }

        public int GetPixelWidthOfString(string line)
        {
            int width = (int)_graafix.MeasureString(line, _font).Height;
            return width;
        }
        #endregion
    }
}
