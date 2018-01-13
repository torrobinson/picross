using System;
using System.Collections.Generic;
using System.Text;

namespace PicrossSolver.Helpers
{
    public class SolverStats
    {
        private static SolverStats instance;

        private SolverStats()
        {
            SegmentPasses = 0;
        }

        public static SolverStats Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SolverStats();
                }
                return instance;
            }
        }

        public int SegmentPasses = 0;
    }
}
