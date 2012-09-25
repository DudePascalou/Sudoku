using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Core.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class GridTests
    {
        #region Starting matrixes

        public int?[,] EmptyStartingMatrix
        {
            get
            {
                return new int?[9, 9]
                {
                    {null,null,null,null,null,null,null,null,null},
                    {null,null,null,null,null,null,null,null,null},
                    {null,null,null,null,null,null,null,null,null},
                    {null,null,null,null,null,null,null,null,null},
                    {null,null,null,null,null,null,null,null,null},
                    {null,null,null,null,null,null,null,null,null},
                    {null,null,null,null,null,null,null,null,null},
                    {null,null,null,null,null,null,null,null,null},
                    {null,null,null,null,null,null,null,null,null}
                };
            }
        }

        public int?[,] ValidFullStartingMatrix
        {
            get
            {
                return new int?[9, 9]
                {
                    {1,2,3,4,5,6,7,8,9},
                    {4,5,6,7,8,9,1,2,3},
                    {7,8,9,1,2,3,4,5,6},
                    {2,3,4,5,6,7,8,9,1},
                    {5,6,7,8,9,1,2,3,4},
                    {8,9,1,2,3,4,5,6,7},
                    {3,4,5,6,7,8,9,1,2},
                    {6,7,8,9,1,2,3,4,5},
                    {9,1,2,3,4,5,6,7,8}
                };
            }
        }

        public int?[,] InvalidFullStartingMatrix
        {
            get
            {
                return new int?[9, 9]
                {
                    {1,2,3,4,5,6,7,8,9},
                    {1,2,3,4,5,6,7,8,9},
                    {1,2,3,4,5,6,7,8,9},
                    {1,2,3,4,5,6,7,8,9},
                    {1,2,3,4,5,6,7,8,9},
                    {1,2,3,4,5,6,7,8,9},
                    {1,2,3,4,5,6,7,8,9},
                    {1,2,3,4,5,6,7,8,9},
                    {1,2,3,4,5,6,7,8,9}
                };
            }
        }

        #endregion


        [TestMethod]
        public void EmptyGridTest()
        {
            Grid g = new Grid(this.EmptyStartingMatrix);
        }


        [TestMethod]
        public void GridTest()
        {
            Grid g = new Grid(this.InvalidFullStartingMatrix);

            // Cells :
            for (int c = 0; c < 9; c++)
                for (int r = 0; r < 9; r++)
                    Assert.AreEqual(r + 1, g.Cells[c, r].Digit.Value);

            // Boxes :
            int expectedValue = 0;
            for (int boxRow = 0; boxRow < 3; boxRow++)
            {
                for (int boxCol = 0; boxCol < 3; boxCol++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        for (int col = 0; col < 3; col++)
                        {
                            expectedValue = (boxCol * 3) + col + 1;
                            Assert.AreEqual(expectedValue, g.Boxes[boxRow, boxCol].Cells[row, col].Digit.Value);
                        }
                    }
                }
            }
        }


        [TestMethod]
        public void FullGridTest()
        {
            Grid g = new Grid(this.ValidFullStartingMatrix);

            int expectedValue = 0;

            #region AssertCells

            expectedValue = 1;
            this.AssertCells(expectedValue, g, 0, 6, 3, 8, 5, 2, 7, 4, 1);
            expectedValue = 2;
            this.AssertCells(expectedValue, g, 1, 7, 4, 0, 6, 3, 8, 5, 2);
            expectedValue = 3;
            this.AssertCells(expectedValue, g, 2, 8, 5, 1, 7, 4, 0, 6, 3);
            expectedValue = 4;
            this.AssertCells(expectedValue, g, 3, 0, 6, 2, 8, 5, 1, 7, 4);
            expectedValue = 5;
            this.AssertCells(expectedValue, g, 4, 1, 7, 3, 0, 6, 2, 8, 5);
            expectedValue = 6;
            this.AssertCells(expectedValue, g, 5, 2, 8, 4, 1, 7, 3, 0, 6);
            expectedValue = 7;
            this.AssertCells(expectedValue, g, 6, 3, 0, 5, 2, 8, 4, 1, 7);
            expectedValue = 8;
            this.AssertCells(expectedValue, g, 7, 4, 1, 6, 3, 0, 5, 2, 8);
            expectedValue = 9;
            this.AssertCells(expectedValue, g, 8, 5, 2, 7, 4, 1, 6, 3, 0);

            #endregion
            #region AssertBoxes

            this.AssertBoxes(g.Boxes[0, 0], 1, 2, 3, 4, 5, 6, 7, 8, 9);
            this.AssertBoxes(g.Boxes[0, 1], 4, 5, 6, 7, 8, 9, 1, 2, 3);
            this.AssertBoxes(g.Boxes[0, 2], 7, 8, 9, 1, 2, 3, 4, 5, 6);
            this.AssertBoxes(g.Boxes[1, 0], 2, 3, 4, 5, 6, 7, 8, 9, 1);
            this.AssertBoxes(g.Boxes[1, 1], 5, 6, 7, 8, 9, 1, 2, 3, 4);
            this.AssertBoxes(g.Boxes[1, 2], 8, 9, 1, 2, 3, 4, 5, 6, 7);
            this.AssertBoxes(g.Boxes[2, 0], 3, 4, 5, 6, 7, 8, 9, 1, 2);
            this.AssertBoxes(g.Boxes[2, 1], 6, 7, 8, 9, 1, 2, 3, 4, 5);
            this.AssertBoxes(g.Boxes[2, 2], 9, 1, 2, 3, 4, 5, 6, 7, 8);

            #endregion
            #region AssertColumns

            this.AssertColumns(g.Columns[0], 1, 4, 7, 2, 5, 8, 3, 6, 9);
            this.AssertColumns(g.Columns[1], 2, 5, 8, 3, 6, 9, 4, 7, 1);
            this.AssertColumns(g.Columns[2], 3, 6, 9, 4, 7, 1, 5, 8, 2);
            this.AssertColumns(g.Columns[3], 4, 7, 1, 5, 8, 2, 6, 9, 3);
            this.AssertColumns(g.Columns[4], 5, 8, 2, 6, 9, 3, 7, 1, 4);
            this.AssertColumns(g.Columns[5], 6, 9, 3, 7, 1, 4, 8, 2, 5);
            this.AssertColumns(g.Columns[6], 7, 1, 4, 8, 2, 5, 9, 3, 6);
            this.AssertColumns(g.Columns[7], 8, 2, 5, 9, 3, 6, 1, 4, 7);
            this.AssertColumns(g.Columns[8], 9, 3, 6, 1, 4, 7, 2, 5, 8);

            #endregion
            #region AssertRows

            this.AssertRows(g.Rows[0], 1, 2, 3, 4, 5, 6, 7, 8, 9);
            this.AssertRows(g.Rows[1], 4, 5, 6, 7, 8, 9, 1, 2, 3);
            this.AssertRows(g.Rows[2], 7, 8, 9, 1, 2, 3, 4, 5, 6);
            this.AssertRows(g.Rows[3], 2, 3, 4, 5, 6, 7, 8, 9, 1);
            this.AssertRows(g.Rows[4], 5, 6, 7, 8, 9, 1, 2, 3, 4);
            this.AssertRows(g.Rows[5], 8, 9, 1, 2, 3, 4, 5, 6, 7);
            this.AssertRows(g.Rows[6], 3, 4, 5, 6, 7, 8, 9, 1, 2);
            this.AssertRows(g.Rows[7], 6, 7, 8, 9, 1, 2, 3, 4, 5);
            this.AssertRows(g.Rows[8], 9, 1, 2, 3, 4, 5, 6, 7, 8);

            #endregion

        }


        [TestMethod]
        public void CandidatesTest()
        {
            int?[,] sampleGrid = new int?[9, 9]
            {
                    {null,null,null,null,null,null,null,null,null},
                    {1,null,2,null,null,null,7,6,null},
                    {null,4,null,6,1,null,null,9,8},
                    {3,null,null,null,2,null,null,null,4},
                    {6,8,null,null,4,null,null,null,7},
                    {null,null,null,null,3,7,9,null,null},
                    {null,null,null,3,null,null,null,null,null},
                    {null,null,7,5,6,null,null,null,null},
                    {null,3,6,null,null,null,5,1,null}
            };

            Grid g = new Grid(sampleGrid);
            bool[] expected;
            bool[] actual;

            // g.Cells[0, 0]
            expected = new bool[9] { false, false, false, false, true, false, true, true, true };
            actual = g.Cells[0, 0].Candidates;
            CollectionAssert.AreEqual(expected, actual);
            // g.Cells[0, 1]
            expected = new bool[9] { false, false, false, false, true, true, true, false, true };
            actual = g.Cells[0, 1].Candidates;
            CollectionAssert.AreEqual(expected, actual);
            // g.Cells[0, 2]
            expected = new bool[9] { false, false, true, false, true, false, false, true, true };
            actual = g.Cells[0, 2].Candidates;
            CollectionAssert.AreEqual(expected, actual);

        }


        private void AssertRows(Row row, params int[] expectedValues)
        {
            if (expectedValues == null || expectedValues.Length != 9)
                throw new ArgumentException();
            for (int i = 0; i < 9; i++)
                if (expectedValues[i] < 1 || expectedValues[i] > 9)
                    throw new ArgumentOutOfRangeException();

            for (int colIndex = 0; colIndex < 9; colIndex++)
                Assert.AreEqual(expectedValues[colIndex], row.Cells[colIndex].Digit.Value);
        }
        private void AssertColumns(Column column, params int[] expectedValues)
        {
            if (expectedValues == null || expectedValues.Length != 9)
                throw new ArgumentException();
            for (int i = 0; i < 9; i++)
                if (expectedValues[i] < 1 || expectedValues[i] > 9)
                    throw new ArgumentOutOfRangeException();

            for (int rowIndex = 0; rowIndex < 9; rowIndex++)
                Assert.AreEqual(expectedValues[rowIndex], column.Cells[rowIndex].Digit.Value);
        }
        private void AssertBoxes(Box box, params int[] expectedValues)
        {
            if (expectedValues == null || expectedValues.Length != 9)
                throw new ArgumentException();
            for (int i = 0; i < 9; i++)
                if (expectedValues[i] < 1 || expectedValues[i] > 9)
                    throw new ArgumentOutOfRangeException();

            int index = 0;
            for (int boxRow = 0; boxRow < 3; boxRow++)
            {
                for (int boxCol = 0; boxCol < 3; boxCol++)
                {
                    Assert.AreEqual(expectedValues[index], box.Cells[boxRow, boxCol].Digit.Value);
                    index++;
                }
            }
        }
        private void AssertCells(int expectedValue, Grid grid, params int[] columnForRow)
        {
            if (expectedValue < 1 || expectedValue > 9)
                throw new ArgumentOutOfRangeException();
            if (columnForRow == null || columnForRow.Length != 9)
                throw new ArgumentException();

            for (int i = 0; i < 9; i++)
                Assert.AreEqual(expectedValue, grid.Cells[i, columnForRow[i]].Digit.Value);
        }


        [TestMethod]
        public void IsSolvedGridTest()
        {
            Grid g = new Grid(this.ValidFullStartingMatrix);

            // IsSolved :
            Assert.IsTrue(g.IsSolved());
        }
    }
}
