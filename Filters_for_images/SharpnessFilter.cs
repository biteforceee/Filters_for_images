﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters_for_images
{
    internal class SharpnessFilter : MatrixFilter
    {
        public SharpnessFilter() {
            kernel = new float[,]
            {
                { -1, -1, -1 },
                { -1, 9, -1 },
                { -1, -1, -1 }
            };
        }
    }
}