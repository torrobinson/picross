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
            Puzzle mockPuzzle = PuzzleBuilder.CreateMock();

            // Draw once
            Draw(mockPuzzle);

            // Solve as much as we can
            PuzzleSolver solver = new PuzzleSolver();
            solver.SolvePuzzle(mockPuzzle);
            
            // Draw again
            Draw(mockPuzzle);

        }

        /// <summary>
        /// Draw the puzzle to the console window for previewing
        /// </summary>
        /// <param name="segment"></param>
        private static void Draw(Puzzle puzzle)
        {
            Console.Clear();

            string pipe = "\u2502"; //│
            string middleLine = "\u2500"; //━
            string topLeft = "\u250C"; //┌
            string topRight = "\u2510"; //┐
            string bottomLeft = "\u2514";//└
            string bottomRight = "\u2518"; //┘
            string leftIntersection = "\u251C"; //├
            string rightIntersection = "\u2524"; //┤
            string topIntersection = "\u252C"; //┬
            string bottomIntersection = "\u2534"; //┴
            string intersection = "\u253C"; //┼
            string rightArrow = "\u2192"; //→
            string downArrow = "\u2193"; //↓


            // Draw the top line
            Console.WriteLine();
            Console.Write(topLeft);
            for (int i = 0; i < puzzle.Columns.Count * 2 + 1 - 2; i++)
            {
                Console.Write(i%2==0? middleLine : topIntersection);
            }
            Console.Write(topRight);
            Console.WriteLine();

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
                        Console.Write(pipe + GetCellCharacter(cell));
                    }
                    else if (last)
                    {
                        Console.Write(pipe + GetCellCharacter(cell) + pipe);
                    }
                    else
                    {
                        Console.Write(pipe + GetCellCharacter(cell));
                    }

                    number++;
                }

                // Then draw the sequences
                Console.Write(rightArrow);
                Console.Write(
                    String.Join(
                        " ",
                        row.MustHaves.Select(seq => seq.Count.ToString())
                    )
                );

                // Draw a line between each row (if not last line)
                if (row != puzzle.Rows.Last())
                {
                    Console.WriteLine();
                    Console.Write(leftIntersection);
                    for (int i = 0; i < puzzle.Columns.Count * 2 - 1; i++)
                    {
                        Console.Write(i%2==0? middleLine : intersection);
                    }
                    Console.Write(rightIntersection);
                }
                

                Console.WriteLine();
            }

            // Draw LAST line
            Console.Write(bottomLeft);
            for (int i = 0; i < puzzle.Columns.Count * 2 + 1 - 2; i++)
            {
                Console.Write(i % 2 == 0 ? middleLine : bottomIntersection);
            }
            Console.Write(bottomRight);
            Console.WriteLine();

            // Draw column sequences on bottom
            foreach (Segment column in puzzle.Columns)
            {
                Console.Write(" " + downArrow);
            }
            Console.WriteLine();

            Console.Write(" ");
            for (int i = 0; i < puzzle.Columns.Max(col => col.MustHaves.Count); i++)
            {
                if(i>0) Console.Write(" ");
                foreach (Segment column in puzzle.Columns)
                {
                    if (column.MustHaves.Count > i)
                    {
                        Console.Write(column.MustHaves[i].Count);
                    }
                    else
                    {
                        Console.Write(" ");
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
                return "\u2588"; // █
            }

            if (cell.IsFalse)
            {
                return "x"; //x
            }

            return "⋅";
        }
    }
}
