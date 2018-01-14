using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class SingleSequenceConnectEnds : SegmentSolver
    {
        /// <summary>
        /// If there's only 1 sequence and we have more than one already True cells,
        ///     then connect them
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public override bool Execute(Segment segment)
        {
            if (!segment.HasBlanks) return false;

            List<int> falseStartAndEndCounts = base.TrimStartAndEndFalses(segment);

            bool cellsChanged = false;

            // If there's only 1 sequence
            if (segment.MustHaves.Count == 1)
            {
                // But there's already more than 1 known True cell,
                IEnumerable<Cell> trueCells = segment.Cells.Where(cell => cell.IsTrue);
                if (trueCells.Count() > 1)
                {
                    // Figure out what to draw between
                    int startDrawingAt = trueCells.Min(cell => cell.IndexIn(segment));
                    int endDrawingAt = trueCells.Max(cell => cell.IndexIn(segment));

                    // Draw between them
                    for (; startDrawingAt < endDrawingAt; startDrawingAt++)
                    {
                        // startDrawingAt is the index of cell to mark as True
                        // Mark the cells along the path as true
                        if (segment.Cells[startDrawingAt].MarkTrue() && !cellsChanged) cellsChanged = true;
                    }
                }
            }
            base.PutStartAndEndBackTogether(falseStartAndEndCounts, segment);
            return cellsChanged;
        }
    }
}
