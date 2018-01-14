using System;
using System.Collections.Generic;
using System.Text;
using PicrossPreview.Puzzles;
using PicrossSolver.Models;

namespace PicrossSolver.Helpers
{
    public static class PuzzleBuilder
    {

        public static Puzzle FromString(string puzzleString)
        {
            Puzzle puzzle = new Puzzle();

            foreach (string line in puzzleString.Split(new[] { Environment.NewLine },StringSplitOptions.None))
            {
                Segment segment = new Segment();

                int index = 0;
                foreach (char cellString in line.ToCharArray())
                {
                    Cell cell = new Cell();
                    if (cellString == PuzzleStrings.TrueCharacter)
                        cell.MarkTrue();
                    segment.Cells.Add(cell);
                    index++;
                }

                puzzle.Rows.Add(segment);
            }

            puzzle.Columns = SegmentMirror.GenerateColumnsFromRows(puzzle.Rows);

            // Generate the row musthaves
            foreach (Segment row in puzzle.Rows)
            {
                row.MustHaves = SequenceGenerator.GenerateMustHaves(row);
            }

            // Generate the column musthaves
            foreach (Segment column in puzzle.Columns)
            {
                column.MustHaves = SequenceGenerator.GenerateMustHaves(column);
            }

            // Now that we have the musthaves, unmark all cells again
            foreach (Segment row in puzzle.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    cell.MarkUnknown();
                }
            }

            return puzzle;
        }
    }
}
