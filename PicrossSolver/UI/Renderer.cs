using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicrossSolver.Models;
using PicrossSolver.Helpers;

namespace PicrossSolver.UI
{
    public static class Renderer
    {
        // Box Drawing
        private static string _pipe = "\u2502"; //│
        private static string _middleLine = "\u2500"; //━
        private static string _topLeft = "\u250C"; //┌
        private static string _topRight = "\u2510"; //┐
        private static string _bottomLeft = "\u2514";//└
        private static string _bottomRight = "\u2518"; //┘
        private static string _leftIntersection = "\u251C"; //├
        private static string _rightIntersection = "\u2524"; //┤
        private static string _topIntersection = "\u252C"; //┬
        private static string _bottomIntersection = "\u2534"; //┴
        private static string _intersection = "\u253C"; //┼
        private static string _rightArrow = "--"; //--
        private static string _downArrow = "|"; //|
        private static string _preCell = " ";
        private static string _postCell = " ";

        // Cells
        private static string _trueCell = "\u2588"; // █
        private static string _falseCell = "x"; //x
        private static string _unmarkedCell = " "; //

        /// <summary>
        /// Draw the puzzle to the console window for previewing
        /// </summary>
        /// <param name="segment"></param>
        public static void Draw(Puzzle puzzle)
        {
            Console.Clear();

            int puzzleWidth = 1 + (puzzle.Columns.Count * (_preCell.Length + 1 + _postCell.Length + _pipe.Length));
            int puzzleHeight = 1 + (puzzle.Rows.Count * 2) + 1;
            Console.SetWindowSize(puzzleWidth * 2, puzzleHeight + 10);

            // Draw the top line
            Console.WriteLine();
            Console.Write(_topLeft);
            for (int i = 0; i < puzzle.Columns.Count - 1; i++)
            {
                Console.Write(_middleLine.Repeat(_preCell.Length + 1 + _postCell.Length));
                Console.Write(_topIntersection);
            }
            Console.Write(_middleLine.Repeat(_preCell.Length + 1 + _postCell.Length));
            Console.Write(_topRight);
            Console.WriteLine();

            // Start drawing the puzzle in its current state
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
                        Console.Write(_pipe + _preCell + GetCellCharacter(cell) + _postCell + _pipe);
                    }
                    else if (last)
                    {
                        Console.Write(_preCell + GetCellCharacter(cell) + _postCell + _pipe);
                    }
                    else
                    {
                        Console.Write(_preCell + GetCellCharacter(cell) + _postCell + _pipe);
                    }

                    number++;
                }

                // Then draw the sequences
                Console.Write(_rightArrow);
                Console.Write(
                    String.Join(
                        " ",
                        row.MustHaves.Select(seq => seq.Count.ToString())
                    )
                );

                // Draw a line between each row (if not last line)
                Console.WriteLine();
                if (row != puzzle.Rows.Last())
                {
                    Console.Write(_leftIntersection);
                    for (int i = 0; i < puzzle.Columns.Count - 1; i++)
                    {
                        Console.Write(_middleLine.Repeat(_preCell.Length + 1 + _postCell.Length));
                        Console.Write(_intersection);
                    }
                    Console.Write(_middleLine.Repeat(_preCell.Length + 1 + _postCell.Length));
                    Console.Write(_rightIntersection);
                    Console.WriteLine();
                }
            }

            // Draw LAST line
            Console.Write(_bottomLeft);
            for (int i = 0; i < puzzle.Columns.Count - 1; i++)
            {
                Console.Write(_middleLine.Repeat(_preCell.Length + 1 + _postCell.Length));
                Console.Write(_bottomIntersection);
            }
            Console.Write(_middleLine.Repeat(_preCell.Length + 1 + _postCell.Length));
            Console.Write(_bottomRight);
            Console.WriteLine();

            // Draw column sequences on bottom
            foreach (Segment column in puzzle.Columns)
            {
                Console.Write(" ".Repeat(_pipe.Length));
                Console.Write(" ".Repeat(_preCell.Length));
                Console.Write(_downArrow);
                Console.Write(" ".Repeat(_postCell.Length));
            }
            Console.WriteLine();

            Console.Write(" ".Repeat(_pipe.Length));
            for (int i = 0; i < puzzle.Columns.Max(col => col.MustHaves.Count); i++)
            {
                if (i > 0) Console.Write(" ".Repeat(_pipe.Length));

                foreach (Segment column in puzzle.Columns)
                {
                    int overFlowSubAmount = 0;
                    if (column.MustHaves.Count > i)
                    {
                        Console.Write(" ".Repeat(_preCell.Length));

                        Console.Write(column.MustHaves[i].Count);
                        overFlowSubAmount += column.MustHaves[i].Count.ToString().Length > 1 ? 1 : 0;

                        Console.Write(" ".Repeat(_postCell.Length - overFlowSubAmount));
                    }
                    else
                    {
                        Console.Write(" ".Repeat(_preCell.Length));

                        Console.Write(" ");

                        Console.Write(" ".Repeat(_postCell.Length - overFlowSubAmount));
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static string GetCellCharacter(Cell cell)
        {
            if (cell.IsTrue) return _trueCell;
            return cell.IsFalse ? _falseCell : " ";
        }
    }
}
