using System;
using System.Collections.Generic;
using System.Text;

namespace PicrossSolver.Models
{
    public class Puzzle
    {
        public List<Segment> Rows { get; set; }
        public List<Segment> Columns { get; set; }

        public Puzzle()
        {
            this.Rows = new List<Segment>();
            this.Columns = new List<Segment>();
        }
    }
}
