using Sudoku.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Sudoku.Core.Tests
{
    
    
    /// <summary>
    ///This is a test class for ColumnTest and is intended
    ///to contain all ColumnTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ColumnTest
    {
        /// <summary>
        ///A test for Index
        ///</summary>
        [TestMethod()]
        public void IndexTest()
        {
            int index = 1;
            Column target = new Column(index);
            int actual;
            actual = target.Index;
            Assert.AreEqual(index, actual);
        }


        /// <summary>
        ///A test for Cells
        ///</summary>
        [TestMethod()]
        public void CellsTest()
        {
            int index = 0; // TODO: Initialize to an appropriate value
            Column target = new Column(index); // TODO: Initialize to an appropriate value
            Cell[] actual;
            actual = target.Cells;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            int index = 1;
            Column target = new Column(index);
            string expected = "C1";
            string actual;
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for RemoveCandidate.
        ///</summary>
        [TestMethod()]
        public void RemoveCandidateTest()
        {
            int index = 1;
            Column target = new Column(1);
            int value = 1;
            target.RemoveCandidate(value);
            Assert.AreEqual(false, target.HasACandidateFor(1));
        }


        /// <summary>
        ///A test for IsComplete
        ///</summary>
        [TestMethod()]
        public void IsCompleteTest()
        {
            int index = 0;
            Column target = new Column(index);
            for (int i = 0; i < 9; i++)
                target.Cells[i] = new Cell();
            bool expected = false;
            bool actual;
            actual = target.IsComplete();
            Assert.AreEqual(expected, actual);

            for (int i = 0; i < 9; i++)
                target.Cells[i].Digit = 2;
            expected = false;
            actual = target.IsComplete();
            Assert.AreEqual(expected, actual);

            for (int i = 0; i < 9; i++)
                target.Cells[i].Digit = i + 1;
            expected = true;
            actual = target.IsComplete();
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for AddCandidate
        ///</summary>
        [TestMethod()]
        public void HasOnlyOnePlaceForTest()
        {
            int?[,] sampleGrid = new int?[9, 9]
            {
                    {7,2,5,4,8,1,6,9,3},
                    {null,1,8,null,null,7,2,5,4},
                    {9,null,4,2,5,null,7,8,1},
                    {8,9,7,1,3,2,5,4,6},
                    {null,null,null,null,4,null,3,null,9},
                    {null,4,null,null,null,null,1,null,8},
                    {4,7,2,null,1,null,9,null,5},
                    {null,5,9,null,7,4,8,1,2},
                    {null,8,null,5,2,9,4,null,7}
            };

            Grid g = new Grid(sampleGrid);
            bool expected;
            bool actual;

            expected = true;
            actual = g.Columns[1].HasOnlyOnePlaceFor(g.Cells[2, 1], 3);
            Assert.AreEqual(expected, actual);

            expected = false;
            actual = g.Columns[1].HasOnlyOnePlaceFor(g.Cells[2, 1], 1);
            Assert.AreEqual(expected, actual);

        }


        /// <summary>
        ///A test for SetCandidates
        ///</summary>
        [TestMethod()]
        public void SetCandidatesTest()
        {
            int index = 0;
            Column target = new Column(index);
            for (int i = 0; i < 9; i++)
            {
                target.Cells[i] = new Cell();
                target.Cells[i].Column = target;
            }

            // Check that all digits are candidate :
            foreach (Cell cell in target.GetCells())
                for (int digit = 1; digit <= 9; digit++)
                    Assert.AreEqual(true, cell.HasACandidateFor(digit));

            target.SetCandidates();

            // Check that all digits are candidate :
            foreach (Cell cell in target.GetCells())
                for (int digit = 1; digit <= 9; digit++)
                    Assert.AreEqual(true, cell.HasACandidateFor(digit));

            target.Cells[0].Digit = 1;
            //target.SetCandidates();

            // Check that 1 is no more a candidate :
            foreach (Cell cell in target.GetCells())
                Assert.AreEqual(false, cell.HasACandidateFor(1));

            // Check that all other digits are candidate
            // (except for the first cell) :
            for (int i = 1; i < 9; i++)
            {
                for (int digit = 2; digit <= 9; digit++)
                    Assert.AreEqual(true, target.Cells[i].HasACandidateFor(digit), string.Format("({0} Candidate for {1})", target.Cells[i], digit));
            }

        }


        /// <summary>
        ///A test for Column Constructor
        ///</summary>
        [TestMethod()]
        public void ColumnConstructorTest()
        {
            int index = 0;
            Column target = new Column(index);
            Assert.IsNotNull(target);
        }
    }
}
