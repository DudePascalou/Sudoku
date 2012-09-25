using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sudoku.Core;

namespace Sudoku.UI.Winforms
{

    public partial class MainForm : Form
    {
        private int?[,] ValidFullStartingMatrix
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


        public MainForm()
        {
            InitializeComponent();

            // Sudoku :
            Grid g = new Grid(this.ValidFullStartingMatrix);
            this.gridUserControl1.Grid = g;
        }

        private void _ResetGridButton_Click(object sender, EventArgs e)
        {
            this.gridUserControl1.Grid = null;
        }

        private void _FillGridButton_Click(object sender, EventArgs e)
        {
            Grid g = new Grid(this.ValidFullStartingMatrix);
            this.gridUserControl1.Grid = g;
        }

        private void _NewGridButton_Click(object sender, EventArgs e)
        {
            //int?[,] sampleGrid = new int?[9, 9]
            //{
            //        {null,null,null,null,null,null,null,null,null},
            //        {1,null,2,null,null,null,7,6,null},
            //        {null,4,null,6,1,null,null,9,8},
            //        {3,null,null,null,2,null,null,null,4},
            //        {6,8,null,null,4,null,null,null,7},
            //        {null,null,null,null,3,7,9,null,null},
            //        {null,null,null,3,null,null,null,null,null},
            //        {null,null,7,5,6,null,null,null,null},
            //        {null,3,6,null,null,null,5,1,null}
            //};
            int?[,] sampleGrid = new int?[9, 9]
            {
                    {null,null,null,null,null,null,null,null,null},
                    {null,null,null,null,9,null,7,6,5},
                    {null,null,null,1,null,6,null,9,null},
                    {null,null,3,null,null,null,null,null,4},
                    {null,8,1,null,null,5,2,null,null},
                    {null,5,2,6,null,1,null,null,null},
                    {5,null,null,null,null,null,null,null,null},
                    {2,null,null,null,6,9,null,null,3},
                    {3,null,null,2,null,8,5,1,null}
            };

            Grid g = new Grid(sampleGrid);
            this.gridUserControl1.Grid = g;
        }

        private void _ShowNextMoveButton_Click(object sender, EventArgs e)
        {
            this.gridUserControl1.ShowNextMove();
        }

        private void button1_Click(object sender, EventArgs e)
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
            this.gridUserControl1.Grid = g;
        }



        #region Problèmes de scintillements

        // supprime les scintillements
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x02000000;
                cp.ExStyle |= 0x00080000;

                return cp;
            }
        }


        // corrige le rafraichissement des controls après un maximize
        // du a la suppression des scintillements
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MAXIMIZE = 0xF030;
            const int SC_RESTORE = 0xF120;

            base.WndProc(ref message);

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MAXIMIZE || command == SC_RESTORE)
                    {
                        this.Refresh();
                        this.Invalidate();
                    }
                    break;
            }
        }

        #endregion

    }
}
