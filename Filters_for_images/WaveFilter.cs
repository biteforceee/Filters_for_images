using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class WaveFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double newX = x + 20*Math.Sin(2*Math.PI*y/60);
            double newY = y;

            // Округляем и ограничиваем координаты
            int sourceX = Clamp((int)newX, 0, sourceImage.Width - 1);
            int sourceY = Clamp((int)newY, 0, sourceImage.Height - 1);

            return sourceImage.GetPixel(sourceX, sourceY);
        }
    }
}
