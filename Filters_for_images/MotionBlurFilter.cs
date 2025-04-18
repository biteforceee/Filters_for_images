using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class MotionBlurFilter : MatrixFilter
    {
        public MotionBlurFilter()
        {
            kernel = new float[3, 3];
            for (int i = 0; i <3; i++)
            {
                kernel[i, i] = 1f/3; 
            }
        }
    }
}
