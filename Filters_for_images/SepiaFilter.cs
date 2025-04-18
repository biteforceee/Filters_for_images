using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color souceColor = sourceImage.GetPixel(x, y);
            int intensity = Clamp((int)(0.36 * souceColor.R + 0.53 * souceColor.G + 0.11 * souceColor.B), 0, 255);
            double k = 55;
            int R = Clamp((int)(intensity + 2 * k), 0, 255);
            int G = Clamp((int)(intensity + 0.5 * k), 0, 255);
            int B = Clamp((int)(intensity - 1 * k), 0, 255);
            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
