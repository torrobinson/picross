using System;
using System.Collections.Generic;
using System.Text;

namespace PicrossSolver.Models
{
    /// <summary>
    /// Represents a single cell in the puzzle
    /// </summary>
    public class Cell
    {
        public int Index { get; set; }        
        
        // Filled
        private bool filled = false;
        public bool IsFilled => this.filled;
        /// <summary>
        /// Fill the cell
        /// </summary>
        public void Fill()
        {
            this.filled = true;
        }

        // Xed
        private bool xed = false;
        public bool IsXed => this.xed;
        /// <summary>
        /// 'X' the cell, or mark is as a known un-marked cell
        /// </summary>
        public void X()
        {
            this.xed = true;
        }


        public bool IsEmpty => !IsFilled && !IsXed;

    }
}
