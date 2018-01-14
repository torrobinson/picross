using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class BookendOnesInOneOnlySequence : SegmentSolver
    {
        /// <summary>
        /// If all numbers in this sequences are 1, then bookend all true cells with Falses
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public override bool Execute(Segment segment)
        {
            if (!segment.HasBlanks) return false;

            bool cellsChanged = false;

            // If the sum == the count (all are 1s)
            if (segment.MustHaves.Sum(seq => seq.Count) == segment.MustHaves.Count)
            {
                foreach (Cell cell in segment.Cells.Where(cell => cell.IsTrue))
                {
                    int trueIndex = cell.IndexIn(segment);

                    if (trueIndex > 0)
                    {
                        if (segment.Cells[trueIndex - 1].MarkFalse() & !cellsChanged) cellsChanged = true;
                    }

                    if (trueIndex < segment.Length - 1)
                    {
                        if (segment.Cells[trueIndex + 1].MarkFalse() & !cellsChanged) cellsChanged = true;
                    }

                }
            }

            return cellsChanged;
        }
    }
}
