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

            List<int> falseStartAndEndCounts = base.TrimStartAndEndFalses(segment: segment, onlyTrimIfNoFalses: true);

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
                    double middleIndex = segment.Length / 2.0;

                    // If an odd number is needed, mark the middle 
                    bool markedMiddle = false;
                    if (segment.Length % 2 == 1)
                    {
                        // Mark the middle
                        if (segment.Cells[(segment.Length - 1) / 2].MarkTrue()
                            && !cellsChanged)
                            cellsChanged = true;

                        markedMiddle = true;
                    }

                    if (!markedMiddle || (markedMiddle && overlapFromMiddle > 1))
                    {
                        // Regardless, move outwards if we have to
                        for (int i = 0; i < overlapFromMiddle; i++)
                        {
                            // When odd, we need to do each side from the middle equally
                            if (segment.Length % 2 == 1)
                            {
                                // 2.5-> 1,3 0,4
                                if (segment.Cells[Convert.ToInt32(Math.Floor(middleIndex)) - (i + 1)].MarkTrue() && !cellsChanged) cellsChanged = true;
                                if (segment.Cells[Convert.ToInt32(Math.Floor(middleIndex)) + (i + 1)].MarkTrue() && !cellsChanged) cellsChanged = true;
                            }
                            else
                            {
                                // 2 -> 1,2 0,3
                                if (segment.Cells[Convert.ToInt32(middleIndex) + (i)].MarkTrue() && !cellsChanged) cellsChanged = true;
                                if (segment.Cells[Convert.ToInt32(middleIndex) - (i + 1)].MarkTrue() && !cellsChanged) cellsChanged = true;
                            }
                        }
                    }
                }
            }
            base.PutStartAndEndBackTogether(falseStartAndEndCounts, segment);
            return cellsChanged;
        }
    }
}
