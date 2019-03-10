using System;
using System.Collections.Generic;
using System.Text;

namespace PicrossSolver.Helpers
{
    public static class IntHelpers
    {
        public static bool IsOdd(this int num) {
            return num % 2 == 1;
        }

        public static bool IsEven(this int num) {
            return !num.IsOdd();
        }
    }
}
