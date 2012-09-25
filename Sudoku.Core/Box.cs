using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Core
{
    public class Box : HouseBase
    {
        private Cell[,] _Cells;
        public Cell[,] Cells
        {
            get
            {
                return this._Cells;
            }
        }

        private int _RowIndex;
        public int RowIndex
        {
            get
            {
                return this._RowIndex;
            }
        }

        private int _ColumnIndex;
        public int ColumnIndex
        {
            get
            {
                return this._ColumnIndex;
            }
        }


        public Box(int rowIndex, int columnIndex)
        {
            this._Cells = new Cell[3,3];
            this._RowIndex = rowIndex;
            this._ColumnIndex = columnIndex;
        }


        public override string ToString()
        {
            return "BR" + (this.RowIndex + 1) + "CR" + (this.ColumnIndex + 1);
        }


        public override IEnumerable<Cell> GetCells()
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    yield return this._Cells[row, col];
        }

    }
}
