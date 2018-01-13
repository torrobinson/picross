using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicrossSolver.Models
{
    public class Puzzle
    {
        public List<Segment> Rows { get; set; }
        public List<Segment> Columns { get; set; }

        public string DebugVisual => String.Join(System.Environment.NewLine, Rows.Select(r => r.DebugVisual));

        public Puzzle()
        {
            this.Rows = new List<Segment>();
            this.Columns = new List<Segment>();
        }
    }
}
