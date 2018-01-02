using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Helpers
{
    public static class SegmentMirror
    {
        // TODO: Create helper routine taking in an array of rows and columns,
        //  and mirror all cells from the rowset into the columset
        public static List<Segment> GenerateColumnsFromRows(List<Segment> rows)
        {
            List<Segment> columns = new List<Segment>();

            // Create list of columns
            foreach (Cell cell in rows.First().Cells)
            {
                columns.Add(new Segment());
            }

            // And prepopulate with cells
            foreach (Segment column in columns)
            {
                foreach (Segment column1 in columns)
                {
                    column.Cells.Add(new Cell());
                }
            }

            // Populate them
            int r = 0;
            foreach (Segment row in rows)
            {
                int c = 0;
                foreach (Cell cell in row.Cells)
                {
                    columns[c].Cells[r] = cell;
                    c++;
                }

                r++;
            }

            return columns;
        }
    }
}
