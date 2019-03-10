using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;
using PicrossSolver.UI;
using PicrossSolver.Solves;

namespace PicrossSolver.Helpers
{
    public class PuzzleSolver
    {
        private Puzzle puzzle;
        private int unproductiveAttemptNumber = 0;
        private const int UnproductiveAttemptsUntilGiveUp = 50;
        private bool debugMode = false;

        public void SolvePuzzle(Puzzle puzzle, bool debug)
        {
            this.debugMode = debug;
            this.puzzle = puzzle;

            unproductiveAttemptNumber = 0;

            while (unproductiveAttemptNumber < UnproductiveAttemptsUntilGiveUp)
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

                    if (debugMode)
                    {
                        Renderer.Draw(
                            this.puzzle,
                            false,
                            "Change was made with solver " + solver.Name
                        );
                        Console.ReadLine();
                    }

                    // Break and return true
                    return true;
                }                
            }

            // Return the fact that nothing was changed
            return false;
        }
    }
}
