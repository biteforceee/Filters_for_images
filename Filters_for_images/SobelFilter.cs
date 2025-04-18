using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class SobelFilter : MatrixFilter
    {
        public SobelFilter(bool isGorisontal) 
        {
            if (isGorisontal) {
                //kernel = new float[,]
                //{
                //    { -1, 0, 1 },
                //    { -2, 0, 2 },
                //    { -1, 0, 1 }
                //};
                kernel = new float[,]
                {
                    { -2, 4, 2 },
                    { -4, 0, 4 },
                    { -2, -4, 2 }
                };
            } else {
                kernel = new float[,]
                {
                    { -1, -2, -1 },
                    { 0, 0, 0 },
                    { 1, 2, 1 }
                };
            }
        }
    }
}
