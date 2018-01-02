﻿using System;
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

        public bool IsComplete => MustHaves.Sum(seq=>seq.Count) == Cells.Count(cell => cell.IsTrue);

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