using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class SharpeningFilter : MatrixFilter
    {
        public SharpeningFilter()
        {
            kernel = new float[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };
        }
    }
}
