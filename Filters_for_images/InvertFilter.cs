using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color souceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - souceColor.R, 255 - souceColor.G, 255 - souceColor.B);
            return resultColor;
        }
    }
}
