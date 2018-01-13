﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves.sides
{
    public class ImpossibleStartOrEnd : SegmentSolver
    {
        // After a cap-trim, if start or end is [unmarked][false] and [unmarked.count] < sequences.first.count, then it can't fit, so mark [unmarked] as falses
        public override bool Execute(Segment segment)
        {
            if (segment.DebugVisual == "x_xx___#_x")
            {
                var foo = "bar";
            }

            if (!segment.HasBlanks) return false;
            List<int> falseStartAndEndCounts = base.TrimStartAndEndFalses(segment);
            bool cellsChanged = false;


            // Start
            int startingUnmarked = segment.Cells.TakeWhile(cell => cell.IsUnMarked).Count();
            if (startingUnmarked < segment.MustHaves.First().Count &&
                segment.Cells.Skip(startingUnmarked).First().IsFalse)
            {
                foreach (Cell cell in segment.Cells.Take(startingUnmarked))
                {
                    if (cell.MarkFalse() && !cellsChanged) cellsChanged = true;
                }
            }

            // End
            segment.Cells.Reverse();
            startingUnmarked = segment.Cells.TakeWhile(cell => cell.IsUnMarked).Count();
            if (startingUnmarked < segment.MustHaves.First().Count &&
                segment.Cells.Skip(startingUnmarked).First().IsFalse)
            {
                foreach (Cell cell in segment.Cells.Take(startingUnmarked))
                {
                    if (cell.MarkFalse() && !cellsChanged) cellsChanged = true;
                }
            }
            segment.Cells.Reverse();


            base.PutStartAndEndBackTogether(falseStartAndEndCounts, segment);
            return cellsChanged;
        }
    }
}
