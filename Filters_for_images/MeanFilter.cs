using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class MeanFilter : Filters
    {
        public int WindowSize { get; set; } = 3; // Значение по умолчанию 3x3
        
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radius = WindowSize / 2;
            List<int> redValues = new List<int>();
            List<int> greenValues = new List<int>();
            List<int> blueValues = new List<int>();

            // Собираем значения всех пикселей в окрестности
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    int idX = Clamp(x + j, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + i, 0, sourceImage.Height - 1);
                    Color pixel = sourceImage.GetPixel(idX, idY);
                    redValues.Add(pixel.R);
                    greenValues.Add(pixel.G);
                    blueValues.Add(pixel.B);
                }
            }

            // Сортируем списки и находим медиану
            redValues.Sort();
            greenValues.Sort();
            blueValues.Sort();

            int medianIndex = redValues.Count / 2;
            int medianR = redValues[medianIndex];
            int medianG = greenValues[medianIndex];
            int medianB = blueValues[medianIndex];

            return Color.FromArgb(medianR, medianG, medianB);
        }
    }
}
