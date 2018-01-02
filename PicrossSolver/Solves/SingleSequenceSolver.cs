using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class SingleSequenceSolver: SegmentSolver
    {
        public override void Execute(CellSegment emptySegment)
        {
            if (emptySegment.MustHaves.Count == 1)
            {
                // For a single sequence in a segment,
                Sequence theSequence = emptySegment.MustHaves.First();

                // Is it all filled up?
                if (theSequence.Count >= emptySegment.Length)
                {
                    foreach (Cell cell in emptySegment.Cells)
                    {
                        cell.Fill();
                    }
                    return;
                }

                // Check for overlap
                int overlapFromMiddle = theSequence.Count - emptySegment.Length / 2;
                if (overlapFromMiddle > 0)
                {
                    int middleIndex = emptySegment.Length / 2;
                    // Fill in the middle of the segment with overlap*2
                    for (int i = 0 ; i < overlapFromMiddle; i++)
                    {
                        // Going up
                        emptySegment.Cells[middleIndex - i].Fill();

                        // Going down
                        emptySegment.Cells[middleIndex - 1 + i].Fill();
                    }
                }
            }
        }
    }
}
