using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class BrightnessUp : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color souceColor = sourceImage.GetPixel(x, y);
            int R = Clamp((int)(souceColor.R + 40), 0, 255);
            int G = Clamp((int)(souceColor.G + 40), 0, 255);
            int B = Clamp((int)(souceColor.B + 40), 0, 255);
            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
}
