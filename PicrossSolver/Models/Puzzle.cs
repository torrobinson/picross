using System;
using System.Collections.Generic;
using System.Text;

namespace PicrossSolver.Models
{
    public class Puzzle
    {
        public List<CellSegment> Rows { get; set; }
        public List<CellSegment> Columns { get; set; }

        public Puzzle()
        {
            this.Rows = new List<CellSegment>();
            this.Columns = new List<CellSegment>();
        }
    }
}
