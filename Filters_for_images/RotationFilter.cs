using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class RotationFilter : Filters
    {
        private readonly float angle;
        private PointF center;

        public RotationFilter(float angleInDegrees)
        {
            this.angle = angleInDegrees * (float)Math.PI / 180f;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {   
            center.X = sourceImage.Width / 2f;
            center.Y = sourceImage.Height / 2f;

            // Переносим координаты относительно центра поворота
            float xRel = x - center.X;
            float yRel = y - center.Y;

            // Применяем матрицу поворота
            float newX = xRel * (float)Math.Cos(angle) - yRel * (float)Math.Sin(angle) + center.X;
            float newY = xRel * (float)Math.Sin(angle) + yRel * (float)Math.Cos(angle) + center.Y;

            // Если координаты выходят за границы - возвращаем черный
            if (newX < 0 || newX >= sourceImage.Width || newY < 0 || newY >= sourceImage.Height)
            {
                return Color.Black;
            }

            // Округляем и ограничиваем координаты
            int sourceX = Clamp((int)newX, 0, sourceImage.Width - 1);
            int sourceY = Clamp((int)newY, 0, sourceImage.Height - 1);

            return sourceImage.GetPixel(sourceX, sourceY);
        }
    }
}
