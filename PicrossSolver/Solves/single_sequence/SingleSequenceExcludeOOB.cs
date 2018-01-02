using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public class SingleSequenceExcludeOOB: SegmentSolver
    {
        /// <summary>
        /// If we have a single sequence and we know at least 1 part of it, mark anything
        ///     out of possible bounds as False
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public override bool Execute(Segment segment)
        {
            if (!segment.HasBlanks) return false;

            bool cellsChanged = false;

            // If there's exactly 1 sequence
            if (segment.MustHaves.Count == 1)
            {
                Sequence theSequence = segment.MustHaves.First();
                // But there's already more than 1 known True cell,
                IEnumerable<Cell> trueCells = segment.Cells.Where(cell => cell.IsTrue);
                if (trueCells.Any())
                {
                    // Find the known bounds
                    int minimumTrue = trueCells.Min(cell => cell.IndexIn(segment));
                    int maximumTrue = trueCells.Max(cell => cell.IndexIn(segment));

                    // Exclude known bounds below the minimum and above the maxium
                    for (int i = 0; i< maximumTrue + 1 - theSequence.Count; i++)
                    {
                        if (segment.Cells[i].IsUnMarked)
                        {
                            if (segment.Cells[i].MarkFalse() && !cellsChanged) cellsChanged = true;
                        }
                    }
                    for (int i = segment.Length - 1; i > minimumTrue - 1 + theSequence.Count; i--)
                    {
                        if (segment.Cells[i].IsUnMarked)
                        {
                            if (segment.Cells[i].MarkFalse() && !cellsChanged) cellsChanged = true;
                        }
                    }
                }
            }

            return cellsChanged;
        }
    }
}
