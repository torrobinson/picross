﻿using System;
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
            // _ _ _ _ _ x _ _ _ _  =  5
            Puzzle puzzle = new Puzzle();

            // New row
            Segment segment = new Segment();

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

            puzzle.Rows.Add(segment);

            return puzzle;
        }

        public static Puzzle ReadFromString()
        {
            string map =
                "___###____" + Environment.NewLine +
                "__##______" + Environment.NewLine +
                "_##_______";

            Puzzle puzzle = new Puzzle();

            foreach (string line in map.Split(new[] { Environment.NewLine },StringSplitOptions.None))
            {
                Segment segment = new Segment();

                int index = 0;
                foreach (char cellString in line.ToCharArray())
                {
                    Cell cell = new Cell(){Index = index};
                    //if (cellString == '#')
                        //cell.MarkTrue();
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

            return puzzle;
        }
    }
}
