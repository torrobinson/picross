using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class SequenceTerminatesOnASide : SegmentSolver
    {
        /// <summary>
        /// If a segment has its first sequence in its entirety touching its first side, then terminate it with a False.
        /// Vice versa for the last sequence.
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public override bool Execute(Segment segment)
        {
            if (!segment.HasBlanks) return false;

            if (segment.TrueCount == 0) return false;
            KnownStartAndEndFalses falseStartAndEndCounts = base.RemoveStartAndEndFalsesFromSegment(segment);
            bool cellsChanged = false;

            // If the sequence is small enough to fit inside and needs to be terminated somewhere,
            Sequence firstSequence = segment.MustHaves.First();
            if (firstSequence.Count < segment.Length)
            {
                // And if it's touching the start in it's entirety
                if (segment.Cells.Take(firstSequence.Count).Count(cell => cell.IsTrue) == firstSequence.Count
                    && segment.Cells[firstSequence.Count].IsUnMarked)
                {
                    // Then terminate it
                    if (segment.Cells[firstSequence.Count].MarkFalse() && !cellsChanged) cellsChanged = true;
                }
            }

            // Last
            Sequence lastSequence = segment.MustHaves.Last();
            if (lastSequence.Count < segment.Length)
            {
                // And if it's touching the end in it's entirety
                if (segment.Cells.Skip(segment.Length - lastSequence.Count).Take(lastSequence.Count).Count(cell => cell.IsTrue) == lastSequence.Count
                    && segment.Cells[lastSequence.Count].IsUnMarked)
                {
                    // Then terminate it
                    if (segment.Cells[segment.Length - lastSequence.Count - 1].MarkFalse() && !cellsChanged) cellsChanged = true;
                }
            }
            base.RecombineFalseStartsAndEndsWithSegment(falseStartAndEndCounts, segment);
            return cellsChanged;
        }
    }
}
