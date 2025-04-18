using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class DelineationOfBoundariesFilter : MatrixFilter
    {
        public DelineationOfBoundariesFilter(bool isG) 
        {
            if(!isG)
            {
                kernel = new float[,]
                {
                    { 3, 10, 3 },
                    { 0, 0, 0 },
                    { -3, -10, -3 }
                };
            } else {
                kernel = new float[,]
                {
                    { 3, 0, -3 },
                    { 10, 0, -10 },
                    { 3, 0, -3 }
                };
            }
        }
    }
}
