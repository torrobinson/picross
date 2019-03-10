using System;
using System.Collections.Generic;
using System.Text;

namespace PicrossSolver.Models
{
    public class KnownStartAndEndFalses
    {
        /// <summary>
        /// Index in a segmment where the starting falses end
        /// </summary>
        public int StartIndexFalsesEnd { get; set; }
        /// <summary>
        /// Index in a segment where the ending falses being
        /// </summary>
        public int EndIndexFalsesStart { get; set; }

        public KnownStartAndEndFalses(int start, int end) {
            this.StartIndexFalsesEnd = start;
            this.EndIndexFalsesStart = end;
        }
    }
}
