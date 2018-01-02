using System;
using System.Collections.Generic;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Helpers
{
    public static class SequenceGenerator
    {
        public static List<Sequence> GenerateMustHaves(Segment segment)
        {
            List<Sequence> mustHaves = new List<Sequence>();

            bool lastWasTrue = false;
            int currentSequenceCount = 0;
            foreach (Cell cell in segment.Cells)
            {
                if (!cell.IsTrue && lastWasTrue)
                {
                    mustHaves.Add(new Sequence(){Count = currentSequenceCount});
                    currentSequenceCount = 0;
                }

                if (cell.IsTrue)
                {
                    currentSequenceCount++;
                }

                lastWasTrue = cell.IsTrue;
            }

            if (lastWasTrue)
            {
                currentSequenceCount++;
                mustHaves.Add(new Sequence() { Count = currentSequenceCount });
            }

            return mustHaves;
        }
    }
}
