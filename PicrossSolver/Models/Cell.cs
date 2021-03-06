﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PicrossSolver.Models
{
    /// <summary>
    /// Represents a single cell in the puzzle
    /// </summary>
    public class Cell
    {
        public int IndexIn(Segment segment)
        {
            return segment.Cells.IndexOf(this);
        }

        private bool isTrue = false;

        public bool IsTrue
        {
            get
            {
                return this.isTrue;
            }
        }

        public bool MarkTrue()
        {
            bool changed = !this.isTrue;
            this.isTrue = true;
            this.isFalse = false;

            return changed;
        }

        public string DebugCharacter => IsTrue ? "#" : IsFalse ? "x" : "_";

        private bool isFalse = false;
        public bool IsFalse => this.isFalse;
        public bool MarkFalse()
        {
            bool changed = !this.isFalse;
            this.isFalse = true;
            this.isTrue = false;

            return changed;
        }

        public void MarkUnknown()
        {
            this.isFalse = false;
            this.isTrue = false;
        }

        public bool IsMarked => this.isFalse || this.isTrue;

        public bool IsUnMarked
        {
            get
            {
                return !this.IsMarked;
            }
        }

        public static List<Cell> CreateNew(int count = 1) {
            List<Cell> result = new List<Cell>();
            for (int i = 0; i < count; i++) {
                result.Add(new Cell() { isFalse = false, isTrue = false });
            }
            return result;
        }
    }
}
