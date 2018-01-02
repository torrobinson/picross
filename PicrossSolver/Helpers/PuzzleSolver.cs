using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;
using PicrossSolver.Solves;

namespace PicrossSolver.Helpers
{
    public class PuzzleSolver
    {
        private int unproductiveAttemptNumber = 0;
        private const int failsUntilGiveUp = 50;

        public void SolvePuzzle(Puzzle puzzle)
        {
            while (unproductiveAttemptNumber < failsUntilGiveUp)
            {
                bool anyChanges = false;
                foreach (Segment segment in puzzle.Rows.Concat(puzzle.Columns))
                {
                    anyChanges = SolveSegment(segment) && !anyChanges;
                }

                if (!anyChanges)
                {
                    unproductiveAttemptNumber++;
                }
                else
                {
                    // Reset on productive solve cycle
                    unproductiveAttemptNumber = 0;
                }
            }
        }

        public List<SegmentSolver> SegmentSolvers => new List<SegmentSolver>()
        {
            new SegmentEntirelyFilled(),         // The segment is all true or all false
            new SingleSequenceOverlapSolver(),   // Single sequence overlap
            new SingleSequenceConnectEnds(),     // Single sequence connection
            new SingleSequenceExcludeOOB(),      // Single sequence exclude bounds
            new SegmentCompleteMarkBlanksFalse() // Mark blank cells in a "complete" segment as false
        };

        public bool SolveSegment(Segment segment)
        {
            bool cellMarked = false;

            foreach (SegmentSolver solver in SegmentSolvers)
            {
                if (solver.Execute(segment) && !cellMarked) cellMarked = true;

                if (cellMarked) break;
            }

            return cellMarked;
        }
    }
}
