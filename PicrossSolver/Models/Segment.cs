using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicrossSolver.Models
{
    public class Segment
    {
        public List<Sequence> MustHaves { get; set; }
        public List<Cell> Cells { get; set; }
        public int Length => this.Cells.Count;

        public string DebugVisual => String.Join("", Cells.Select(cell => cell.DebugCharacter));

        public int TrueCount => this.Cells.Count(cell=>cell.IsTrue);

        public bool HasBlanks => this.Cells.Any(cell => cell.IsUnMarked);

        public bool IsComplete
        {
            get
            {
                return MustHaves.Sum(seq => seq.Count) == Cells.Count(cell => cell.IsTrue);
            }
        }

        public Segment()
        {
            this.MustHaves = new List<Sequence>();
            this.Cells = new List<Cell>();
        }

        public List<Segment> SplitIntoEmptySegments()
        {
            List<Segment> segments = new List<Segment>();

            //

            return segments;
        }
    }
}
