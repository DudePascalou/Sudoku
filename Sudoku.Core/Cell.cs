using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Core
{
    public class Cell
    {
        //private static readonly bool[] _NOCANDIDATE = new bool[9] { false, false, false, false, false, false, false, false, false };
        //private static readonly bool[] _ALLCANDIDATES = new bool[9] { true, true, true, true, true, true, true, true, true };

        private Box _Box;
        public Box Box
        {
            get
            {
                return this._Box;
            }
            set
            {
                this._Box = value;
            }
        }

        private Row _Row;
        public Row Row
        {
            get
            {
                return this._Row;
            }
            set
            {
                this._Row = value;
            }
        }

        private Column _Column;
        public Column Column
        {
            get
            {
                return this._Column;
            }
            set
            {
                this._Column = value;
            }
        }

        private Grid _Grid;
        public Grid Grid
        {
            get
            {
                return this._Grid;
            }
            set
            {
                this._Grid = value;
            }
        }

        public IEnumerable<IHouse> Houses
        {
            get
            {
                if (this.Box != null)
                    yield return this.Box;
                if (this.Column != null)
                    yield return this.Column;
                if (this.Row != null)
                    yield return this.Row;
            }
        }

        public IEnumerable<IHouse> AdjacentHouses
        {
            get
            {
                if (this.Grid != null)
                {
                    if (this.Column != null)
                    {
                        int colIndex = this.Column.Index;
                        // 0 ou 3 ou 6 :
                        if (colIndex == 0 || colIndex == 3 || colIndex == 6)
                        {
                            yield return this.Grid.Columns[colIndex + 1];
                            yield return this.Grid.Columns[colIndex + 2];
                        }
                        // 1 ou 4 ou 7 :
                        else if (colIndex == 1 || colIndex == 4 || colIndex == 7)
                        {
                            yield return this.Grid.Columns[colIndex - 1];
                            yield return this.Grid.Columns[colIndex + 1];
                        }
                        // 2 ou 5 ou 8 :
                        else if (colIndex == 2 || colIndex == 5 || colIndex == 8)
                        {
                            yield return this.Grid.Columns[colIndex - 2];
                            yield return this.Grid.Columns[colIndex - 1];
                        }
                    }
                    if (this.Row != null)
                    {
                        int rowIndex = this.Row.Index;
                        // 0 ou 3 ou 6 :
                        if (rowIndex == 0 || rowIndex == 3 || rowIndex == 6)
                        {
                            yield return this.Grid.Rows[rowIndex + 1];
                            yield return this.Grid.Rows[rowIndex + 2];
                        }
                        // 1 ou 4 ou 7 :
                        else if (rowIndex == 1 || rowIndex == 4 || rowIndex == 7)
                        {
                            yield return this.Grid.Rows[rowIndex - 1];
                            yield return this.Grid.Rows[rowIndex + 1];
                        }
                        // 2 ou 5 ou 8 :
                        else if (rowIndex == 2 || rowIndex == 5 || rowIndex == 8)
                        {
                            yield return this.Grid.Rows[rowIndex - 2];
                            yield return this.Grid.Rows[rowIndex - 1];
                        }
                    }
                }
            }
        }

        private int? _Digit;
        public int? Digit
        {
            get
            {
                return this._Digit;
            }
            set
            {
                this._Digit = value;
                this.UpdateCandidates();
            }
        }

        private bool _IsAGiven;
        public bool IsAGiven
        {
            get
            {
                return this._IsAGiven;
            }
            set
            {
                this._IsAGiven = value;
            }
        }

        private bool[] _Candidates;
        public bool[] Candidates
        {
            get
            {
                return this._Candidates;
            }
        }


        /// <summary>
        /// Intializes a new instance of <see cref="Cell"/>.
        /// </summary>
        public Cell()
        {
            this._Digit = null;
            this._IsAGiven = false;
            this._Candidates = new bool[9] { true, true, true, true, true, true, true, true, true };
        }

        public void RemoveCandidate(int value)
        {
            this._Candidates[value - 1] = false;
        }


        private void UpdateCandidates()
        {
            if (this.Digit.HasValue)
            {
                // The cell has a value, there are no more candidate :
                this._Candidates = new bool[9] { false, false, false, false, false, false, false, false, false };
                // Update candidates on owning houses :
                foreach (IHouse house in this.Houses)
                    house.RemoveCandidate(this.Digit.Value);
            }
            else
            {
                // TODO : UpdateCandidates quand il n'y a plus de valeur.
                //// The cell has no value, 
                //this.Candidates = Cell._ALLCANDIDATES;
                //foreach (IHouse house in this.Houses)
                //    house.AddCandidate(this.Digit.Value);
            }
        }


        public int? GetLastCandidate()
        {
            int? lastCandidate = null;
            for (int i = 0; i < 9; i++)
            {
                if (this.Candidates[i] == true)
                {
                    if (lastCandidate == null)
                        lastCandidate = i + 1;
                    else
                        return null;
                }
            }
            return lastCandidate;
        }


        public override string ToString()
        {
            return
                (this.Row != null ? this.Row.ToString() : String.Empty) +
                (this.Column != null ? this.Column.ToString() : String.Empty) +
                ":" + (this.Digit.HasValue ? this.Digit.Value.ToString() : "null");
        }

        public bool HasACandidateFor(int digit)
        {
            return this.Candidates[digit - 1];
        }

        public bool IsTheOnlyPlaceFor(int digit)
        {
            if (this.Digit.HasValue)
                return false;

            foreach (IHouse house in this.Houses)
                if(house.Contains(digit))
                    return false;

            foreach (IHouse house in this.Houses)
                if (house.HasOnlyOnePlaceFor(this, digit))
                    return true;

            // Check that digit is not a candidate in any adjacent houses :
            foreach (IHouse house in this.AdjacentHouses)
                if (house.HasACandidateFor(digit))
                    return false;

            return true;
        }
    }
}
