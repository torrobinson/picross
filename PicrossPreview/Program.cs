using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicrossPreview.Puzzles;
using PicrossSolver.Helpers;
using PicrossSolver.Models;
using PicrossSolver.Solves;
using PicrossSolver.Solves.sides;

namespace PicrossPreview
{
    class Program
    {
        static void Main(string[] args)
        {
            // Come up with a puzzle to solve
            Puzzle puzzle = PuzzleBuilder.FromString(PuzzleStrings.Cherries);

            // Draw once
            Renderer.Draw(puzzle);
            Console.WriteLine("Press any key to start the solve...");
            Console.ReadLine();

            // Solve as much as we can
            PuzzleSolver solver = new PuzzleSolver();
            solver.SegmentSolvers = new List<SegmentSolver>()
            {
                // Start simple with known entire chunks:
                new SegmentEntirelyFilled(), // The segment is all true or all false
                new SequenceAddsToSegmentLength(), // When the sequences already adds up to the total size

                // Easy pickings
                new BookendOnesInOneOnlySequence(), // When the sequence contains only 1s, bookend all 1s with False

                // Perform solves in single number chunks
                new SingleSequenceOverlapSolver(),    // Single sequence overlap
                new SingleSequenceConnectEnds(),      // Single sequence connection
                new SingleSequenceExcludeOOB(),       // Single sequence exclude bounds

                // Finish off
                new SegmentCompleteMarkBlanksFalse(), // Mark blank cells in a "complete" segment as false
                new SequenceTerminatesOnASide(), // Terminate the other side of a full sequence touching an edge
                new OnlyFinalPiecesRemain(), // When the number of blanks remaining match the number of trues remaining, fill them all in
                new ImpossibleStartOrEnd(), // When the first or last number in a sequence can't fit in the first or last holes, fill the holes
                new ExtendStartAndEnd(), // When a first or last segment cell is True, extend it outward the number of known cells in that segment
            };

            // Start a stopwatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // Solve the puzzle
            solver.SolvePuzzle(puzzle);
            // Stop the stopwatch
            stopWatch.Stop();
            
            // Draw again
            Renderer.Draw(puzzle);

            // Print out the solving stats
            Console.WriteLine("Solve completed in " + stopWatch.Elapsed.TotalMilliseconds + "ms");
            Console.WriteLine("Unknown cells left: " + puzzle.UnknownCount);
            Console.WriteLine("Segment passes: " + SolverStats.Instance.SegmentPasses);
            Console.ReadLine();

        }
    }
}
