using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class Wave2Filter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double newX = x ;
            double newY = y + 20 * Math.Sin(2 * Math.PI * x / 60); ;

            // Округляем и ограничиваем координаты
            int sourceX = Clamp((int)newX, 0, sourceImage.Width - 1);
            int sourceY = Clamp((int)newY, 0, sourceImage.Height - 1);

            return sourceImage.GetPixel(sourceX, sourceY);
        }
    }
}
