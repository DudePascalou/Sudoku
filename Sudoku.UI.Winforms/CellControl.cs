using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sudoku.Core;
using System.Drawing;

namespace Sudoku.UI.Winforms
{
    public class CellControl : TextBox
    {
        private Cell _Cell;
        public Cell Cell
        {
            get
            {
                return this._Cell;
            }
            set
            {
                this._Cell = value;
                this.UpdateValue();
            }
        }

        private bool _Editable;
        public bool Editable
        { get { return this._Editable; } }



        public CellControl()
            : this(new Cell())
        { }

        public CellControl(Cell cell)
        {
            this.Cell = cell;

            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.ReadOnly = true;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Enter += new EventHandler(CellControl_Enter);
            this.Leave += new EventHandler(CellControl_Leave);

            this.Name = cell.ToString();
            this.TabIndex = ((cell.Row.Index - 1) * 9) + cell.Column.Index;
        }

        void CellControl_Enter(object sender, EventArgs e)
        {
            if (!this._Cell.IsAGiven)
                this._Editable = true;
            this.BackColor = Color.Aqua;
        }

        void CellControl_Leave(object sender, EventArgs e)
        {
            this.BackColor = Control.DefaultBackColor;
        }


        public void UpdateValue()
        {
            if (this.Cell != null && this.Cell.Digit.HasValue)
            {
                this.Text = this.Cell.Digit.Value.ToString();
                if (!this.Cell.IsAGiven)
                    this.ForeColor = Color.BlueViolet;
            }
            else
            {
                this.Text = string.Empty;
            }
        }
    }
}
