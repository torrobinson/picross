using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class OnlyFinalPiecesRemain : SegmentSolver
    {
        /// <summary>
        /// If the number of remaining blanks match the number of remainting Trues for the segment, fill the blanks in with Trues
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public override bool Execute(Segment segment)
        {
            if (!segment.HasBlanks) return false;

            bool cellsChanged = false;

            if (
                    segment.MustHaves.Sum(seq => seq.Count)
                    - segment.Cells.Count(cell => cell.IsTrue)
                    ==
                    segment.Cells.Count(cell => cell.IsUnMarked)
               )
            {
                foreach (Cell cell in segment.Cells.Where(cell => cell.IsUnMarked))
                {
                    if (cell.MarkTrue() & !cellsChanged) cellsChanged = true;
                }
            }

            return cellsChanged;
        }
    }
}
