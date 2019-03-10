using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class ExtendStartAndEnd : SegmentSolver
    {
        /// <summary>
        /// If a segment starts or ends with a True, extend it outward based on first or last sequence
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public override bool Execute(Segment segment)
        {
            if (!segment.HasBlanks) return false;
            KnownStartAndEndFalses falseStartAndEndCounts = base.TrimStartAndEndFalses(segment);

            bool cellsChanged = false;
            if (segment.TrueCount > 0)
            {

                if (segment.Cells.First().IsTrue)
                {
                    foreach (Cell cell in segment.Cells.Take(segment.MustHaves.First().Count))
                    {
                        if (cell.MarkTrue() && !cellsChanged) cellsChanged = true;
                    }
                }

                //End
                if (segment.Cells.Last().IsTrue)
                {
                    segment.Cells.Reverse();
                    foreach (Cell cell in segment.Cells.Take(segment.MustHaves.Last().Count))
                    {
                        if (cell.MarkTrue() && !cellsChanged) cellsChanged = true;
                    }
                    segment.Cells.Reverse();
                }
            }

            base.PutStartAndEndBackTogether(falseStartAndEndCounts, segment);
            return cellsChanged;
        }
    }
}
