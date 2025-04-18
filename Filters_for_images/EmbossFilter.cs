using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class EmbossFilter : MatrixFilter
    {
        public EmbossFilter()
        {
            kernel = new float[,]
            {
                { -1, -1, -1 },
                { -1, 9, -1 },
                { -1, -1, -1 }
            };
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);

                    // Получаем яркость пикселя (0.299*R + 0.587*G + 0.114*B)
                    float intensity = 0.299f * neighborColor.R + 0.587f * neighborColor.G + 0.114f * neighborColor.B;

                    resultR += intensity * kernel[k + radiusX, l + radiusY];
                    resultG += intensity * kernel[k + radiusX, l + radiusY];
                    resultB += intensity * kernel[k + radiusX, l + radiusY];
                }
            }

            // Сдвиг яркости (добавляем 128 для получения эффекта тиснения)
            resultR += 128;
            resultG += 128;
            resultB += 128;

            // Нормировка значений
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255));
        }
    }
}
