using System;
using System.Collections.Generic;
using System.Text;

namespace PicrossSolver.Models
{
    public class CellSegment
    {
        public List<Sequence> MustHaves { get; set; }
        public List<Cell> Cells { get; set; }
        public int Length => this.Cells.Count;

        public CellSegment()
        {
            this.MustHaves = new List<Sequence>();
            this.Cells = new List<Cell>();
        }
    }
}
