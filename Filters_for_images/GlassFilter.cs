using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class GlassFilter : Filters
    {
        private readonly int distortionRadius; // Радиус искажения
        private readonly Random random = new Random();

        public GlassFilter(int radius = 5)
        {
            distortionRadius = radius;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Генерируем случайное смещение в пределах [-radius, radius]
            int offsetX = (int)((random.NextDouble() - 0.5) * 2 * distortionRadius);
            int offsetY = (int)((random.NextDouble() - 0.5) * 2 * distortionRadius);

            // Вычисляем новые координаты с учетом смещения
            int newX = Clamp(x + offsetX, 0, sourceImage.Width - 1);
            int newY = Clamp(y + offsetY, 0, sourceImage.Height - 1);

            // Возвращаем цвет из смещенной позиции
            return sourceImage.GetPixel(newX, newY);
        }
    }
}
