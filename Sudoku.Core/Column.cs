using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Core
{
    public class Column : HouseBase
    {
        private Cell[] _Cells;
        public Cell[] Cells
        {
            get
            {
                return this._Cells;
            }
        }

        private int _Index;
        public int Index
        {
            get
            {
                return this._Index;
            }
        }


        public Column(int index)
        {
            this._Index = index;
            this._Cells = new Cell[9];
        }


        public override string ToString()
        {
            return "C" + (this.Index + 1);
        }


        public override IEnumerable<Cell> GetCells()
        {
            foreach (Cell cell in this._Cells)
                yield return cell;
        }
    }
}
