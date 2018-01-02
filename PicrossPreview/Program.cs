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
            //Puzzle mockPuzzle = PuzzleBuilder.CreateMock();
            Puzzle mockPuzzle = PuzzleBuilder.ReadFromString();

            // Draw once
            Draw(mockPuzzle);

            // Solve as much as we can
            PuzzleSolver.SolvePuzzle(mockPuzzle);
            
            // Draw again
            Draw(mockPuzzle);

        }

        /// <summary>
        /// ROUGHLY draw out single segments for now. Only need to debug solvers on 1 segment at a time.
        /// </summary>
        /// <param name="segment"></param>
        private static void Draw(Puzzle puzzle)
        {
            Console.Clear();

            // Lets just draw the first row of the puzzle for debug purposes
            foreach (Segment row in puzzle.Rows)
            {
                bool first;
                bool last;
                int number = 1;
                foreach (Cell cell in row.Cells)
                {
                    first = number == 1;
                    last = number == row.Cells.Count;

                    if (first)
                    {
                        Console.Write("[" + GetCellCharacter(cell));
                    }
                    else if (last)
                    {
                        Console.Write("|" + GetCellCharacter(cell) + "]");
                    }
                    else
                    {
                        Console.Write("|" + GetCellCharacter(cell));
                    }

                    number++;
                }

                // Then draw the sequences
                Console.Write(" ");
                Console.Write(
                    String.Join(
                        ", ",
                        row.MustHaves.Select(seq => seq.Count.ToString())
                    )
                );

                Console.WriteLine();
            }

            // Draw column sequences on bottom
            Console.Write(" ");
            for (int i = 0; i < puzzle.Columns.Max(col => col.MustHaves.Count); i++)
            {
                if(i>0) Console.Write("_");
                foreach (Segment column in puzzle.Columns)
                {
                    if (column.MustHaves.Count > i)
                    {
                        Console.Write(column.MustHaves[i].Count);
                    }
                    else
                    {
                        Console.Write("_");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
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
