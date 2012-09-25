using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Core
{
    public class Grid
    {
        private Row[] _Rows;
        public Row[] Rows
        {
            get
            {
                return this._Rows;
            }
            set
            {
                this._Rows = value;
            }
        }

        private Column[] _Columns;
        public Column[] Columns
        {
            get
            {
                return this._Columns;
            }
            set
            {
                this._Columns = value;
            }
        }

        private Box[,] _Boxes;
        public Box[,] Boxes
        {
            get
            {
                return this._Boxes;
            }
            set
            {
                this._Boxes = value;
            }
        }

        public IEnumerable<IHouse> Houses
        {
            get
            {
                for (int boxRow = 0; boxRow < 3; boxRow++)
                    for (int boxCol = 0; boxCol < 3; boxCol++)
                        yield return this._Boxes[boxRow, boxCol];
                for (int row = 0; row < 9; row++)
                    yield return this._Columns[row];
                for (int col = 0; col < 9; col++)
                    yield return this._Rows[col];
            }
        }

        private Cell[,] _Cells;
        public Cell[,] Cells
        {
            get
            {
                return this._Cells;
            }
        }


        public Grid(int?[,] startingMatrix)
        {
            this.CheckStartingMatrix(startingMatrix);

            this.InitGrid();

            Cell currentCell = null;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    currentCell = this.Cells[row, col];
                    currentCell.Digit = startingMatrix[row, col];
                    currentCell.IsAGiven = (currentCell.Digit != null);
                }
            }

            this.SetCandidates();
        }


        private int BoxIndex(int index)
        {
            if (index < 3)
            {
                return 0;
            }
            else if (index < 6)
            {
                return 1;
            }
            else
            {
                return 2;
            }
            //return (int)Math.Floor((double)index / 3);
        }

        private void CheckStartingMatrix(int?[,] startingMatrix)
        {
            if (startingMatrix.GetUpperBound(0) != 8 ||
                startingMatrix.GetUpperBound(1) != 8)
                throw new ArgumentOutOfRangeException();


            for (int c = 0; c < 9; c++)
                for (int r = 0; r < 9; r++)
                    if (startingMatrix[c, r].HasValue && (startingMatrix[c, r] < 1 || startingMatrix[c, r] > 9))
                        throw new ArgumentOutOfRangeException();
        }


        private void InitGrid()
        {
            // Boxes :
            this._Boxes = new Box[3, 3];
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    this._Boxes[row, col] = new Box(row, col);

            // Columns :
            this._Columns = new Column[9];
            for (int col = 0; col < 9; col++)
                this._Columns[col] = new Column(col);

            // Rows :
            this._Rows = new Row[9];
            for (int row = 0; row < 9; row++)
                this._Rows[row] = new Row(row);

            // Cells :
            int boxCol = 0;
            int boxRow = 0;
            this._Cells = new Cell[9, 9];
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Cell cell = new Cell();

                    cell.Grid = this;
                    cell.Box = this._Boxes[this.BoxIndex(row), this.BoxIndex(col)];
                    cell.Column = this._Columns[col];
                    cell.Row = this._Rows[row];

                    cell.Grid.Cells[row, col] = cell;
                    cell.Box.Cells[boxRow, boxCol] = cell;
                    cell.Column.Cells[cell.Row.Index] = cell;
                    cell.Row.Cells[cell.Column.Index] = cell;

                    boxCol = (boxCol < 2) ? boxCol + 1 : 0;
                }
                boxRow = (boxRow < 2) ? boxRow + 1 : 0;
            }
        }


        /// <summary>
        /// Determines wheter the current grid is solved.
        /// </summary>
        public bool IsSolved()
        {
            foreach (IHouse house in this.Houses)
                if (!house.IsComplete()) return false;

            return true;
        }


        /// <summary>
        /// Solve the entire grid.
        /// </summary>
        public void Solve()
        {
            Cell cell = this.FindNextSolvableCell();
            while (cell != null)
            {
                cell.Digit = cell.GetLastCandidate();
                cell = this.FindNextSolvableCell();
            }
        }


        private void SetCandidates()
        {
            foreach (IHouse house in this.Houses)
            {
                house.SetCandidates();
            }
        }


        public IEnumerable<Cell> GetCells()
        {
            for (int row = 0; row < 9; row++)
                for (int col = 0; col < 9; col++)
                    yield return this._Cells[row, col];
        }


        /// <summary>
        /// Find the next solvable cell.
        /// </summary>
        /// <returns>The solved cell.</returns>
        public Cell FindNextSolvableCell()
        {
            foreach (Cell cell in this.GetCells())
            {
                if (!cell.Digit.HasValue)
                {
                    for (int digit = 1; digit <= 9; digit++)
                    {
                        if (cell.IsTheOnlyPlaceFor(digit))
                        {
                            cell.Digit = digit;
                            return cell;
                        }
                    }
                }
            }
            return null;
        }

    }
}
