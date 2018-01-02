using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicrossSolver.Helpers;
using PicrossSolver.Models;
using PicrossSolver.Solves;

namespace PicrossPreview
{
    class Program
    {
        static void Main(string[] args)
        {
            Puzzle mockPuzzle = PuzzleBuilder.CreateMock();

            // Draw once
            Draw(mockPuzzle);

            // Solve as much as we can
            PuzzleSolver.SolvePuzzle(mockPuzzle);
            
            // Draw again
            Draw(mockPuzzle);

            // Todo: Build rows AND columns, and add the same cell to both the corresponding row and column
            // so that filling them is mirrored in both

            // Loop:
            // for each row and for each column
            //     split on Cell !IsEmpty (or unmarked cells)
            //     for each segment in the split
            //         run all solves
            //         once ANY solve changed something, loop back and start over to reevaluate
        }

        /// <summary>
        /// ROUGHLY draw out single segments for now. Only need to debug solvers on 1 segment at a time.
        /// </summary>
        /// <param name="segment"></param>
        private static void Draw(Puzzle puzzle)
        {
            Console.Clear();

            // Lets just draw the first row of the puzzle for debug purposes
            CellSegment segment = puzzle.Rows.First();

            bool first;
            bool last;
            int number = 1;
            foreach (Cell cell in segment.Cells)
            {
                first = number == 1;
                last = number == segment.Cells.Count;

                if(first)
                {
                    Console.Write("[" + GetCellCharacter(cell));
                }
                else if(last)
                {
                    Console.Write("|" + GetCellCharacter(cell) + "]");
                }
                else
                {
                    Console.Write("|" + GetCellCharacter(cell));
                }

                number++;
            }

            Console.ReadLine();
        }

        private static string GetCellCharacter(Cell cell)
        {
            if (cell.IsTrue)
            {
                return "#";
            }

            if (cell.IsFalse)
            {
                return "x";
            }

            return " ";
        }
    }
}
