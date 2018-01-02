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
        
        private bool isTrue = false;
        public bool IsTrue => this.isTrue;
        public bool MarkTrue()
        {
            bool changed = !this.isTrue;
            this.isTrue = true;
            this.isFalse = false;

            return changed;
        }

        private bool isFalse = false;
        public bool IsFalse => this.isFalse;
        public bool MarkFalse()
        {
            bool changed = !this.isFalse;
            this.isFalse = true;
            this.isTrue = false;

            return changed;
        }

        public bool IsMarked => this.IsFalse || this.IsTrue;
        public bool IsUnMarked => !this.IsMarked;

    }
}
