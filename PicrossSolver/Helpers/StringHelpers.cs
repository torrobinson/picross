using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicrossSolver.Helpers
{
    public static class StringHelpers
    {
        public static string Repeat(this string input, int count)
        {
            return new StringBuilder(input.Length * count).Insert(0, input, count).ToString();
        }
    }
}
