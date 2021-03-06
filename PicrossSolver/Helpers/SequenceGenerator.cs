﻿using System;
using System.Collections.Generic;
using System.Linq;
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
                    mustHaves.Add(new Sequence(currentSequenceCount));
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
                mustHaves.Add(new Sequence(currentSequenceCount));
            }

            // If there was nothing for this segment, then give it a single empty musthave
            if (mustHaves.Count == 0)
            {
                mustHaves.Add(new Sequence(0));
            }

            return mustHaves;
        }
    }
}
