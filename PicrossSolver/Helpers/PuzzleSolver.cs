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
        private const int UnproductiveAttemptsUntilGiveUp = 50;
        private bool debugMode = false;

        public void SolvePuzzle(Puzzle puzzle, bool debug)
        {
            this.debugMode = debug;

            unproductiveAttemptNumber = 0;

            while (unproductiveAttemptNumber < UnproductiveAttemptsUntilGiveUp)
            {
                bool anyChanges = false;
                foreach (Segment segment in puzzle.Rows.Concat(puzzle.Columns))
                {
                    anyChanges = SolveSegment(segment) && !anyChanges;

                    if (anyChanges && debugMode) {

                    }
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

        public List<SegmentSolver> SegmentSolvers { get; set; }

        public bool SolveSegment(Segment segment)
        {
            // For every type of solver
            foreach (SegmentSolver solver in SegmentSolvers)
            {
                // Increment our segment pass count
                SolverStats.Instance.SegmentPasses++;

                // If it made a change
                if (solver.Execute(segment)) {

                    // Break and return true
                    return true;
                }                
            }

            // Return the fact that nothing was changed
            return false;
        }
    }
}
