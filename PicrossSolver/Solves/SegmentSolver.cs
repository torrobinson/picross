using System;
using System.Collections.Generic;
using System.Text;
using PicrossSolver.Models;

namespace PicrossSolver.Solves
{
    public abstract class SegmentSolver
    {
        public abstract void Execute(CellSegment segment);
    }
}
