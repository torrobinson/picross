using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicrossSolver.Models;
using PicrossSolver.Solves;

namespace PicrossPreview
{
    class Program
    {
        static void Main(string[] args)
        {
            // New test segment
            CellSegment segment = new CellSegment();

            // Add 10 cells to it
            for (int i = 0; i < 9; i++)
            {
                segment.Cells.Add(
                    new Cell()
                    {
                        Index = i
                    }
                );
            }

            segment.MustHaves.Add(
                new Sequence()
                {
                    Count = 20
                }
            );

            // Draw once
            Draw(segment);

            // Run solve to debug
            List<SegmentSolver> solvers = new List<SegmentSolver>()
            {
                new SingleSequenceSolver()
            };
            foreach (SegmentSolver solver in solvers)
            {
                solver.Execute(segment);
            }
            
            // Draw again
            Draw(segment);


            // Todo: Build rows AND columns, and add the same cell to both the corresponding row and column
            // so that filling them is mirrored in both

            // Loop:
            // for each row and for each column
            //     split on Cell !IsEmpty (or unmarked cells)
            //     for each segment in the split
            //         run all solves
            //         once ANY solve changed something, loop back and start over to reevaluate
        }

        /// <summary>
        /// ROUGHLY draw out single segments for now. Only need to debug solvers on 1 segment at a time.
        /// </summary>
        /// <param name="segment"></param>
        private static void Draw(CellSegment segment)
        {
            Console.Clear();

            bool first;
            bool last;
            int number = 1;
            foreach (Cell cell in segment.Cells)
            {
                first = number == 1;
                last = number == segment.Cells.Count;

                if (first)
                {
                    Console.Write(cell.IsFilled ? "[X" : "[ ");
                }
                if (last)
                {
                    Console.Write(cell.IsFilled ? "|X]" : "| ]");
                }
                else
                {
                    Console.Write(cell.IsFilled ? "|X" : "| ");
                }

                number++;
            }

            Console.ReadLine();
        }
    }
}
