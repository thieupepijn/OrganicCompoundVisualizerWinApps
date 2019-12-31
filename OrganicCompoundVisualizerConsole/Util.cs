using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace OrganicCompoundVisualizerConsole
{
    public class Util
    {
        public static ImageFormat FileExtension2ImageFormat(string extension)
        {
            if ((extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase)) || (extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase)))
            {
                return ImageFormat.Jpeg;
            }
            else if (extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase))
            {
                return ImageFormat.Bmp;
            }
            else if (extension.Equals(".gif", StringComparison.OrdinalIgnoreCase))
            {
                return ImageFormat.Gif;
            }
            else if (extension.Equals(".png", StringComparison.OrdinalIgnoreCase))
            {
                return ImageFormat.Png;
            }
            return ImageFormat.Bmp;
        }

    }
}
