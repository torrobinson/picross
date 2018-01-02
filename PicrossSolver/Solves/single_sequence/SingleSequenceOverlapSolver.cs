using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class SingleSequenceOverlapSolver: SegmentSolver
    {
        public override bool Execute(Segment emptySegment)
        {
            bool cellsChanged = false;

            if (emptySegment.MustHaves.Count == 1)
            {
                // For a single sequence in a segment,
                Sequence theSequence = emptySegment.MustHaves.First();

                // Is it all filled up?
                if (theSequence.Count >= emptySegment.Length)
                {
                    foreach (Cell cell in emptySegment.Cells)
                    {
                        if (cell.MarkTrue() && !cellsChanged) cellsChanged = true;
                    }
                    return cellsChanged;
                }

                // Check for overlap
                int overlapFromMiddle = theSequence.Count - emptySegment.Length / 2;
                if (overlapFromMiddle > 0)
                {
                    // And if it's even, we can work OUTWARDS from the "middle" area
                    int middleIndex = emptySegment.Length / 2;

                    for (int i = 0; i < overlapFromMiddle; i++)
                    {
                        // Going up
                        if (emptySegment.Cells[middleIndex - i].MarkTrue()
                            && !cellsChanged)
                            cellsChanged = true;

                        // Going down
                        if (emptySegment.Cells[middleIndex - (emptySegment.Length % 2 == 0 ? -1 : 0) + i].MarkTrue()
                            && !cellsChanged)
                            cellsChanged = true;
                    }
                }
            }

            return cellsChanged;
        }
    }
}
