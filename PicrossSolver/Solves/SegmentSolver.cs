﻿using System;
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

        protected List<int> TrimStartAndEndFalses(Segment segment)
        {
            if ((segment.Cells.First().IsFalse || segment.Cells.Last().IsFalse) && segment.Cells.Any(cell=>cell.IsUnMarked))
            {
                // Start at the first Blank
                List<Cell> startWall = segment.Cells.TakeWhile(cell => cell.IsFalse).ToList();

                // End at the last Blank

                List<Cell> endWall = (segment.Cells as IEnumerable<Cell>).Reverse()
                    .TakeWhile(cell => cell.IsFalse).Reverse().ToList();

                List<Cell> middleSection =
                    segment.Cells.Skip(startWall.Count).Take(segment.Length - endWall.Count).ToList();

                // x _ _ _ x
                // If anyting between is Marked then ignore this all. We only want to deal with walls where
                //  there's nothing but free space between 1-2 known walls
                if (middleSection.Any(cell => cell.IsMarked))
                {
                    return new List<int>(){0,0};
                }
                else
                {
                    List<int> startAndEnd = new List<int>() { startWall.Count(), endWall.Count() };
                    segment.Cells = middleSection;


                    return startAndEnd;
                }
            }

            return new List<int>() { 0, 0 };
        }

        protected void PutStartAndEndBackTogether(List<int> StartAndEnd, Segment MiddleSegment)
        {
            if (StartAndEnd.First() != 0)
            {
                for(int i=0; i<StartAndEnd.First(); i++) {
                    Cell FalseCell = new Cell();
                    FalseCell.MarkFalse();
                    MiddleSegment.Cells.Insert(0, FalseCell);
                }
            }

            if (StartAndEnd.Last() != 0)
            {
                for (int i = 0; i < StartAndEnd.Last(); i++)
                {
                    Cell FalseCell = new Cell();
                    FalseCell.MarkFalse();
                    MiddleSegment.Cells.Add(FalseCell);
                }
            }
        }
    }
}