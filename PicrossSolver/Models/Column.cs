using System;
using System.Collections.Generic;
using System.Text;

namespace PicrossSolver.Models
{
    public class Column: CellSegment
    {
        public int Index { get; set; }
        public Column(int position)
        {
            this.Index = position;
        }
    }
}
