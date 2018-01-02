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
            if (unproductiveAttemptNumber > failsUntilGiveUp)
            {
                return;
            }

            foreach (CellSegment segment in puzzle.Rows.Concat(puzzle.Columns))
            {
                bool anyChanges = SolveSegment(segment);

                if (!anyChanges)
                {
                    unproductiveAttemptNumber++;
                }

                SolvePuzzle(puzzle, unproductiveAttemptNumber);
            }
        }

        public static List<SegmentSolver> SegmentSolvers => new List<SegmentSolver>()
        {
            new SingleSequenceOverlapSolver() // Single sequence overlap
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
