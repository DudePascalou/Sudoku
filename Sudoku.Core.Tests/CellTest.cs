using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sudoku.Core.Tests
{
    /// <summary>
    ///This is a test class for CellTest and is intended
    ///to contain all CellTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CellTest
    {
        #region Properties

        ///// <summary>
        /////A test for Row
        /////</summary>
        //[TestMethod()]
        //public void RowTest()
        //{
        //    Cell target = new Cell(); // TODO: Initialize to an appropriate value
        //    Row expected = null; // TODO: Initialize to an appropriate value
        //    Row actual;
        //    target.Row = expected;
        //    actual = target.Row;
        //    Assert.AreEqual(expected, actual);
        //}


        /// <summary>
        ///A test for IsAGiven
        ///</summary>
        [TestMethod()]
        public void IsAGivenTest()
        {
            Cell target = new Cell();

            target.IsAGiven = false;
            Assert.AreEqual(false, target.IsAGiven);

            target.IsAGiven = true;
            Assert.AreEqual(true, target.IsAGiven);

            // La modification de Digit ne doit pas modifier la valeur de IsAGiven :
            target.IsAGiven = false;
            target.Digit = null;
            Assert.AreEqual(false, target.IsAGiven);

            target.IsAGiven = false;
            target.Digit = 7;
            Assert.AreEqual(false, target.IsAGiven);

            target.IsAGiven = true;
            target.Digit = null;
            Assert.AreEqual(true, target.IsAGiven);

            target.IsAGiven = true;
            target.Digit = 7;
            Assert.AreEqual(true, target.IsAGiven);
        }


        ///// <summary>
        /////A test for Grid
        /////</summary>
        //[TestMethod()]
        //public void GridTest()
        //{
        //    Cell target = new Cell(); // TODO: Initialize to an appropriate value
        //    Grid expected = null; // TODO: Initialize to an appropriate value
        //    Grid actual;
        //    target.Grid = expected;
        //    actual = target.Grid;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}


        /// <summary>
        ///A test for Digit
        ///</summary>
        [TestMethod()]
        public void DigitTest()
        {
            Cell target = new Cell();

            Assert.AreEqual(null, target.Digit);

            target.Digit = 1;
            Assert.AreEqual(1, target.Digit);

            target.Digit = null;
            Assert.AreEqual(null, target.Digit);
        }

        ///// <summary>
        /////A test for Column
        /////</summary>
        //[TestMethod()]
        //public void ColumnTest()
        //{
        //    Cell target = new Cell(); // TODO: Initialize to an appropriate value
        //    Column expected = null; // TODO: Initialize to an appropriate value
        //    Column actual;
        //    target.Column = expected;
        //    actual = target.Column;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}


        /// <summary>
        ///A test for Candidates
        ///</summary>
        [TestMethod()]
        public void CandidatesTest()
        {
            Cell target;
            bool[] expected;
            bool[] actual;

            target = new Cell();
            expected = new bool[9] { true, true, true, true, true, true, true, true, true };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);

            target.Digit = 1;
            expected = new bool[9] { false, false, false, false, false, false, false, false, false };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);

            target = new Cell();
            target.RemoveCandidate(1);
            expected = new bool[9] { false, true, true, true, true, true, true, true, true };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);

            target = new Cell();
            target.RemoveCandidate(2);
            expected = new bool[9] { true, false, true, true, true, true, true, true, true };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);

            target = new Cell();
            target.RemoveCandidate(3);
            expected = new bool[9] { true, true, false, true, true, true, true, true, true };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);

            target = new Cell();
            target.RemoveCandidate(4);
            expected = new bool[9] { true, true, true, false, true, true, true, true, true };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);

            target = new Cell();
            target.RemoveCandidate(5);
            expected = new bool[9] { true, true, true, true, false, true, true, true, true };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);

            target = new Cell();
            target.RemoveCandidate(6);
            expected = new bool[9] { true, true, true, true, true, false, true, true, true };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);

            target = new Cell();
            target.RemoveCandidate(7);
            expected = new bool[9] { true, true, true, true, true, true, false, true, true };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);

            target = new Cell();
            target.RemoveCandidate(8);
            expected = new bool[9] { true, true, true, true, true, true, true, false, true };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);

            target = new Cell();
            target.RemoveCandidate(9);
            expected = new bool[9] { true, true, true, true, true, true, true, true, false };
            actual = target.Candidates;
            CollectionAssert.AreEqual(expected, actual);
        }


        ///// <summary>
        /////A test for Box
        /////</summary>
        //[TestMethod()]
        //public void BoxTest()
        //{
        //    Cell target = new Cell(); // TODO: Initialize to an appropriate value
        //    Box expected = null; // TODO: Initialize to an appropriate value
        //    Box actual;
        //    target.Box = expected;
        //    actual = target.Box;
        //    Assert.AreEqual(expected, actual);
        //    Assert.Inconclusive("Verify the correctness of this test method.");
        //}

        #endregion



        #region Methods

        /// <summary>
        /// A test for RemoveCandidate.
        /// </summary>
        [TestMethod()]
        public void RemoveCandidateTest()
        {
            Cell target = new Cell();
            target.RemoveCandidate(1);
        }


        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Cell target = new Cell();
            string expectedString;

            for (int row = 0; row < 9; row++)
            {
                target.Row = new Row(row);
                for (int col = 0; col < 9; col++)
                {
                    target.Column = new Column(col);

                    target.Digit = 7;
                    expectedString = "R" + (target.Row.Index + 1) + "C" + (target.Column.Index + 1) + ":7";
                    Assert.AreEqual(expectedString, target.ToString());

                    target.Digit = null;
                    expectedString = "R" + (target.Row.Index + 1) + "C" + (target.Column.Index + 1) + ":null";
                    Assert.AreEqual(expectedString, target.ToString());
                }
            }
            
        }


        /// <summary>
        ///A test for Cell Constructor
        ///</summary>
        [TestMethod()]
        public void CellConstructorTest()
        {
            Cell target = new Cell();
            Assert.IsNotNull(target);
        }


        /// <summary>
        ///A test for GetLastCandidate
        ///</summary>
        [TestMethod()]
        public void GetLastCandidateTest()
        {
            Cell target = new Cell();
            int? expected = null;
            int? actual = target.GetLastCandidate();
            Assert.AreEqual(expected, actual);

            target.RemoveCandidate(1);
            target.RemoveCandidate(2);
            target.RemoveCandidate(3);
            target.RemoveCandidate(4);
            target.RemoveCandidate(5);
            target.RemoveCandidate(6);
            target.RemoveCandidate(7);
            target.RemoveCandidate(8);

            expected = 9;
            actual = target.GetLastCandidate();
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// A test for IsTheOnlyPlaceFor.
        /// </summary>
        [TestMethod]
        public void IsTheOnlyPlaceForTest()
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
            bool expected;
            bool actual;

            expected = true;
            actual = g.Cells[0, 1].IsTheOnlyPlaceFor(6);
            Assert.AreEqual(expected, actual);

            expected = true;
            actual = g.Cells[6, 7].IsTheOnlyPlaceFor(7);
            Assert.AreEqual(expected, actual);

        }

        #endregion
    }
}
