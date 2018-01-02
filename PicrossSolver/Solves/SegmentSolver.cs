using System;
using System.Collections.Generic;
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
    }
}
