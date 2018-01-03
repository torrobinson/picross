using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class SingleSequenceOverlapSolver: SegmentSolver
    {
        public override bool Execute(Segment segment)
        {
            if (!segment.HasBlanks) return false;

            List<int> falseStartAndEndCounts = base.TrimStartAndEndFalses(segment);

            bool cellsChanged = false;

            if (segment.MustHaves.Count == 1)
            {
                // For a single sequence in a segment,
                Sequence theSequence = segment.MustHaves.First();

                // Check for overlap
                int overlapFromMiddle = theSequence.Count - segment.Length / 2;
                if (overlapFromMiddle > 0)
                {
                    // Work outwards from the middle
                    int middleIndex = segment.Length / 2;

                    for (int i = 0; i < overlapFromMiddle; i++)
                    {
                        // Going up
                        if (segment.Cells[middleIndex - i].MarkTrue()
                            && !cellsChanged)
                            cellsChanged = true;

                        // Going down
                        if (segment.Cells[middleIndex - (segment.Length % 2 == 0 ? -1 : 0) + i].MarkTrue()
                            && !cellsChanged)
                            cellsChanged = true;
                    }
                }
            }
            base.PutStartAndEndBackTogether(falseStartAndEndCounts, segment);
            return cellsChanged;
        }
    }
}
