﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YamahaAmpController
{
    public static class Util { 

            public static string Left(this string value, int maxLength)
            {
                if (string.IsNullOrEmpty(value)) return value;
                maxLength = Math.Abs(maxLength);

                return (value.Length <= maxLength
                       ? value
                       : value.Substring(0, maxLength)
                       );
            }
        
    }
}
