using System;
using System.Collections.Generic;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Helpers
{
    public static class PuzzleBuilder
    {
        /// <summary>
        /// Create a new mock puzzle
        /// </summary>
        /// <returns>A mock puzzle</returns>
        public static Puzzle CreateMock()
        {
            // _ _ _ _ _ x _ _ _ _  =  5,7
            Puzzle puzzle = new Puzzle();

            // New row
            Row segment = new Row(0);

            // Add 10 cells to it
            for (int i = 0; i < 10; i++)
            {
                segment.Cells.Add(
                    new Cell()
                    {
                        Index = i
                    }
                );
            }

            // Say it has a sequence of 6 in it
            segment.MustHaves.Add(
                new Sequence()
                {
                    Count = 3
                }
            );

            // Say we have a known at index 08
            segment.Cells[5].MarkTrue();
            segment.Cells[7].MarkTrue();

            puzzle.Rows.Add(segment);

            return puzzle;
        }
    }
}
