using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class SegmentEntirelyFilled:SegmentSolver
    {
        /// <summary>
        /// If the ENTIRE segment is either all true or all false
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public override bool Execute(Segment segment)
        {
            bool cellsChanged = false;

            if (segment.MustHaves.Count == 1)
            {
                // If it's all true
                if (segment.MustHaves.First().Count == segment.Length)
                {
                    foreach (Cell cell in segment.Cells)
                    {
                        if (cell.MarkTrue() && !cellsChanged) cellsChanged = true;
                    }
                }
                // If it's all false
                else if (segment.MustHaves.First().Count == 0)
                {
                    foreach (Cell cell in segment.Cells)
                    {
                        if (cell.MarkFalse() && !cellsChanged) cellsChanged = true;
                    }
                }
            }

            return cellsChanged;
        }
    }
}
