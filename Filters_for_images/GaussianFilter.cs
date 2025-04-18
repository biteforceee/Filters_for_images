using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class GaussianFilter : MatrixFilter
    {
        public GaussianFilter() {
            createGaussianFilter(3, 2);
        }

        public void createGaussianFilter(int radius, float sigma)
        {
            // определяем размер ядра
            int size = 2 * radius + 1;
            // создаём ядро фильтра
            kernel = new float[size, size];
            // коэфицент нормировки ядра
            float norm = 0;
            // расчитываем ядро линеёного фильтра
            for(int i = -radius; i<= radius; i++)
            {
                for(int j = -radius; j<= radius; j++)
                {
                    kernel[i+radius,j+radius] = (float)(Math.Exp(-(i*i+j*j)/(sigma*sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            }
            // нормируем ядро
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;
        }
    }
}
