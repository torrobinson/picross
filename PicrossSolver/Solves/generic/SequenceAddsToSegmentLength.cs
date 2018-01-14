using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class SequenceAddsToSegmentLength : SegmentSolver
    {
        /// <summary>
        /// If the sequences and their spacing adds to segment length, then just draw it out,
        /// separated by Falses
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public override bool Execute(Segment segment)
        {
            if (!segment.HasBlanks) return false;

            List<int> falseStartAndEndCounts = base.TrimStartAndEndFalses(segment);

            bool cellsChanged = false;

            if (segment.MustHaves.Sum(seq => seq.Count) + segment.MustHaves.Count - 1 == segment.Length)
            {
                int i = 0;
                foreach (Sequence sequence in segment.MustHaves)
                {
                    for (int j = 0; j < sequence.Count; j++)
                    {
                        // Mark the trues
                        if (segment.Cells[i].MarkTrue() & !cellsChanged) cellsChanged = true;
                        i++;
                    }

                    if (i < segment.Length)
                    {
                        // Joining with falses
                        if (segment.Cells[i].MarkFalse() & !cellsChanged) cellsChanged = true;
                        i++;
                    }
                }
            }

            base.PutStartAndEndBackTogether(falseStartAndEndCounts, segment);
            return cellsChanged;
        }
    }
}
