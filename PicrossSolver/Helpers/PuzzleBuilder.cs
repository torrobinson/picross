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

            segment.MustHaves.Add(
                new Sequence()
                {
                    Count = 6
                }
            );

            puzzle.Rows.Add(segment);

            return puzzle;
        }
    }
}
