using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;
using PicrossSolver.Solves;
using PicrossSolver.Solves._1_sequence;

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
            foreach (CellSegment segment in puzzle.Rows.Concat(puzzle.Columns))
            {
                bool anyChanges = SolveSegment(segment);

                if (!anyChanges)
                {
                    unproductiveAttemptNumber++;
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
            new SingleSequenceOverlapSolver(), // Single sequence overlap
            new SingleSequenceConnectEnds(),   // Single sequence connection
            new SingleSequenceExcludeOOB(),    // Single sequence exclude bounds
        };

        public static bool SolveSegment(CellSegment segment)
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
