using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class SegmentCompleteMarkBlanksFalse : SegmentSolver
    {
        public override bool Execute(Segment segment)
        {
            if (!segment.HasBlanks) return false;

            bool cellsChanged = false;

            if(segment.IsComplete)
            {
                foreach (Cell cell in segment.Cells.Where(cell => cell.IsUnMarked))
                {
                    if (cell.MarkFalse() && !cellsChanged) cellsChanged = true;
                }
            }

            return cellsChanged;
        }
    }
}
