using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class GlowingEdgesFilter : Filters
    {
        private readonly float threshold;
        private MeanFilter mnf;

        public GlowingEdgesFilter(float edgeThreshold = 0.3f)
        {
            threshold = edgeThreshold;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (x < 1 || y < 1 || x >= sourceImage.Width - 1 || y >= sourceImage.Height - 1)
                return Color.Black;

            // Оператор Собеля для выделения краев
            float[,] Gx = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            float[,] Gy = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            float gradX = 0, gradY = 0;

            // Вычисляем градиенты
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Color pixel = sourceImage.GetPixel(x + j, y + i);
                    float intensity = (pixel.R + pixel.G + pixel.B) / 765f; // Нормализация 0-1

                    gradX += intensity * Gx[i + 1, j + 1];
                    gradY += intensity * Gy[i + 1, j + 1];
                }
            }

            // Вычисляем силу градиента и применяем порог
            float gradient = (float)Math.Sqrt(gradX * gradX + gradY * gradY);
            int value = gradient > threshold ? (int)(gradient * 255 * 2) : 0; // Усиление эффекта
            value = Clamp(value, 0, 255);

            // Фильтр "максимума" в 3x3 окрестности
            int maxValue = value;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Color neighbor = sourceImage.GetPixel(x + j, y + i);
                    maxValue = Math.Max(maxValue, (neighbor.R + neighbor.G + neighbor.B) / 3);
                }
            }

            return Color.FromArgb(maxValue, maxValue, maxValue);
        }
    }
}