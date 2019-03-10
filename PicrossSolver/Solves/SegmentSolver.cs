using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public abstract class SegmentSolver
    {
        /// <summary>
        /// Execute the solver and return whether or not any cells were marked/filled
        /// </summary>
        /// <param name="segment"></param>
        /// <returns>Whether or not any cells were marked/filled</returns>
        public abstract bool Execute(Segment segment);

        protected KnownStartAndEndFalses TrimStartAndEndFalses(Segment segment, bool onlyTrimIfNoFalses = false)
        {
            if ((segment.Cells.First().IsFalse || segment.Cells.Last().IsFalse) && segment.Cells.Any(cell => cell.IsUnMarked))
            {
                // Start at the first Blank
                List<Cell> startWall = segment.Cells.TakeWhile(cell => cell.IsFalse).ToList();

                // End at the last Blank

                List<Cell> endWall = (segment.Cells as IEnumerable<Cell>).Reverse()
                    .TakeWhile(cell => cell.IsFalse).Reverse().ToList();

                List<Cell> middleSection =
                    segment.Cells.Skip(startWall.Count).Take(segment.Length - endWall.Count - startWall.Count).ToList();

                //// x _ _ _ x
                //// If anyting between is False then ignore this all. We only want to deal with walls where
                ////  there's nothing but free space (or already true cells) between 1-2 known walls
                if (onlyTrimIfNoFalses && middleSection.Any(cell => cell.IsFalse))
                {
                    return new KnownStartAndEndFalses(0,0);
                }
                else
                {
                    segment.Cells = middleSection;
                    return new KnownStartAndEndFalses(startWall.Count(), endWall.Count());
                }
            }

            return new KnownStartAndEndFalses(0, 0);
        }

        protected void PutStartAndEndBackTogether(KnownStartAndEndFalses StartAndEnd, Segment MiddleSegment)
        {
            if (StartAndEnd.StartIndexFalsesEnd != 0)
            {
                for (int i = 0; i < StartAndEnd.StartIndexFalsesEnd; i++)
                {
                    Cell FalseCell = new Cell();
                    FalseCell.MarkFalse();
                    MiddleSegment.Cells.Insert(0, FalseCell);
                }
            }

            if (StartAndEnd.EndIndexFalsesStart != 0)
            {
                for (int i = 0; i < StartAndEnd.EndIndexFalsesStart; i++)
                {
                    Cell FalseCell = new Cell();
                    FalseCell.MarkFalse();
                    MiddleSegment.Cells.Add(FalseCell);
                }
            }
        }
    }
}