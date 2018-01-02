using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;
using PicrossSolver.Solves;

namespace PicrossSolver.Helpers
{
    public static class PuzzleSolver
    {
        private const int failsUntilGiveUp = 10;

        public static void SolvePuzzle(Puzzle puzzle)
        {
            SolvePuzzle(puzzle, 0);
        }

        public static void SolvePuzzle(Puzzle puzzle, int unproductiveAttemptNumber)
        {
            foreach (Segment segment in puzzle.Rows.Concat(puzzle.Columns))
            {
                bool anyChanges = SolveSegment(segment);

                if (!anyChanges)
                {
                    unproductiveAttemptNumber++;
                }
                else
                {
                    // Reset on productive solve cycle
                    unproductiveAttemptNumber = 0;
                }

                if (unproductiveAttemptNumber > failsUntilGiveUp)
                {
                    return;
                }

                SolvePuzzle(puzzle, unproductiveAttemptNumber);
            }
        }

        public static List<SegmentSolver> SegmentSolvers => new List<SegmentSolver>()
        {
            new SingleSequenceOverlapSolver(),   // Single sequence overlap
            new SingleSequenceConnectEnds(),     // Single sequence connection
            new SingleSequenceExcludeOOB(),      // Single sequence exclude bounds
            new SegmentCompleteMarkBlanksFalse() // Mark blank cells in a complete sequence as false
        };

        public static bool SolveSegment(Segment segment)
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
