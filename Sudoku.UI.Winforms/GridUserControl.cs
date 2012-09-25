using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sudoku.Core;

namespace Sudoku.UI.Winforms
{
    public partial class GridUserControl : UserControl
    {
        private static int?[,] _DEFAULTGRIDVALUES
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
                this.UpdateValues();
            }
        }


        public GridUserControl()
            : this(new Grid(GridUserControl._DEFAULTGRIDVALUES))
        { }


        public GridUserControl(Grid grid)
        {
            this.InitializeComponent();

            for (int row = 0; row < 9; row++)
                for (int col = 0; col < 9; col++)
                    this._GridTableLayoutPanel.Controls.Add(new CellControl(), col, row);

            this.Grid = grid;
        }


        private void UpdateValues()
        {
            int index = 0;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    ((CellControl)this._GridTableLayoutPanel.Controls[index]).Cell = (this.Grid != null ? this.Grid.Cells[row, col] : new Cell());
                    index++;
                }
            }
        }


        public void ShowNextMove()
        {
            Cell cell = this.Grid.FindNextSolvableCell();
            if (cell != null)
            {
                int index = ((cell.Row.Index) * 9) + cell.Column.Index;
                ((CellControl)this._GridTableLayoutPanel.Controls[index]).Cell = cell;
            }
            else
            {
                if (this._Grid.IsSolved())
                {
                    MessageBox.Show("Grid is solved !", "Grid solved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No solvable cell found.", "Next move", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
