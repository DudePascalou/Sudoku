using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Core
{
    /// <summary>
    /// A house is a group of 9 cells which must contain digits 1 through 9.
    /// In a standard Sudoku, a house can either be a row, a column, or a box.
    /// </summary>
    public interface IHouse
    {
        IEnumerable<Cell> GetCells();

        Cell GetNextSolvableCell();

        bool IsComplete();

        bool HasOnlyOnePlaceFor(Cell cell, int digit);

        bool Contains(int digit);

        void RemoveCandidate(int digit);

        void SetCandidates();

        bool HasACandidateFor(int digit);
    }
}
