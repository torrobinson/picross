using System;
using System.Collections.Generic;
using System.Text;

namespace PicrossSolver.Models
{
    public class Row: CellSegment
    {
        public int Index { get; set; }
        public Row(int position)
        {
            this.Index = position;
        }
    }
}
