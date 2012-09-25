using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Core
{
    public abstract class HouseBase : IHouse
    {
        #region IHouse Members

        public abstract IEnumerable<Cell> GetCells();

        public Cell GetNextSolvableCell()
        {
            foreach (Cell cell in this.GetCells())
            {
                if (cell != null)
                {
                    int? lastCandidate = cell.GetLastCandidate();
                    if (lastCandidate != null)
                    {
                        return cell;
                    }
                }
            }
            return null;
        }

        public bool IsComplete()
        {
            bool[] digits = new bool[9] { false, false, false, false, false, false, false, false, false };

            foreach (Cell cell in this.GetCells())
            {
                if (cell != null)
                {
                    // If at least one cell hos no value,
                    // current house is not complete :
                    if (!cell.Digit.HasValue)
                        return false;
                    else
                        digits[cell.Digit.Value - 1] = true;
                }
            }

            // Check that there are all 9 different digits :
            return digits.Count(b => b) == 9;
        }

        public bool Contains(int digit)
        {
            foreach (Cell cell in this.GetCells())
            {
                if (cell != null && cell.Digit.HasValue && cell.Digit.Value == digit)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Check wether the given cell is the only place for
        /// the given digit in the house.
        /// </summary>
        /// <param name="cell">Cell.</param>
        /// <param name="digit">Digit.</param>
        /// <returns>True, if the cell is the only place for 
        /// the given digit in the house, false otherwise.</returns>
        public bool HasOnlyOnePlaceFor(Cell cell, int digit)
        {
            foreach (Cell c in this.GetCells())
            {
                if (c != null && !c.Equals(cell))
                {
                    if (c.Digit.HasValue && c.Digit.Value == digit)
                        return false;
                    else if (c.HasACandidateFor(digit))
                        return false;
                }
            }
            return true;
        }

        public void RemoveCandidate(int digit)
        {
            foreach (Cell cell in this.GetCells())
                if (cell != null)
                    cell.RemoveCandidate(digit);
        }

        public void SetCandidates()
        {
            foreach (Cell cell in this.GetCells())
                if (cell != null && cell.Digit.HasValue)
                    this.RemoveCandidate(cell.Digit.Value);
        }

        public bool HasACandidateFor(int digit)
        {
            if (this.Contains(digit))
                return false;

            foreach (Cell cell in this.GetCells())
                if (cell != null && !cell.Digit.HasValue && cell.HasACandidateFor(digit))
                    return true;

            return false;
        }

        #endregion
    }
}
