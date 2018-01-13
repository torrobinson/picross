using System;
using System.Collections.Generic;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Helpers
{
    public static class PuzzleBuilder
    {

        public static Puzzle CreateMock()
        {
            string map =
                "____######" + Environment.NewLine +
                "_______#__" + Environment.NewLine +
                "______##__" + Environment.NewLine +
                "____##_#__" + Environment.NewLine +
                "_###___#__" + Environment.NewLine +
                "#_###_###_" + Environment.NewLine +
                "######_###" + Environment.NewLine +
                "##########" + Environment.NewLine +
                "####_#####" + Environment.NewLine +
                "______###_";

            //string map =
            //    "_#___" + Environment.NewLine +
            //    "#__#_" + Environment.NewLine +
            //    "_#___" + Environment.NewLine +
            //    "__#__" + Environment.NewLine +
            //    "#_##_";

            //string map =
            //    "_#_#_" + Environment.NewLine +
            //    "#_###" + Environment.NewLine +
            //    "#_##_";

            //string map =
            //    "_____" + Environment.NewLine +
            //    "_____" + Environment.NewLine +
            //    "_#_#_" + Environment.NewLine +
            //    "_____" + Environment.NewLine +
            //    "_____";

            Puzzle puzzle = new Puzzle();

            foreach (string line in map.Split(new[] { Environment.NewLine },StringSplitOptions.None))
            {
                Segment segment = new Segment();

                int index = 0;
                foreach (char cellString in line.ToCharArray())
                {
                    Cell cell = new Cell();
                    if (cellString == '#')
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
