namespace Sudoku.UI.Winforms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._ResetGridButton = new System.Windows.Forms.Button();
            this._FillGridButton = new System.Windows.Forms.Button();
            this._NewGridButton = new System.Windows.Forms.Button();
            this._ShowNextMoveButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._MainPanel = new System.Windows.Forms.Panel();
            this.gridUserControl1 = new Sudoku.UI.Winforms.GridUserControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this._MainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ResetGridButton
            // 
            this._ResetGridButton.Location = new System.Drawing.Point(25, 8);
            this._ResetGridButton.Name = "_ResetGridButton";
            this._ResetGridButton.Size = new System.Drawing.Size(75, 23);
            this._ResetGridButton.TabIndex = 1;
            this._ResetGridButton.Text = "Reset grid";
            this._ResetGridButton.UseVisualStyleBackColor = true;
            this._ResetGridButton.Click += new System.EventHandler(this._ResetGridButton_Click);
            // 
            // _FillGridButton
            // 
            this._FillGridButton.Location = new System.Drawing.Point(25, 38);
            this._FillGridButton.Name = "_FillGridButton";
            this._FillGridButton.Size = new System.Drawing.Size(75, 23);
            this._FillGridButton.TabIndex = 2;
            this._FillGridButton.Text = "Fill grid";
            this._FillGridButton.UseVisualStyleBackColor = true;
            this._FillGridButton.Click += new System.EventHandler(this._FillGridButton_Click);
            // 
            // _NewGridButton
            // 
            this._NewGridButton.Location = new System.Drawing.Point(25, 67);
            this._NewGridButton.Name = "_NewGridButton";
            this._NewGridButton.Size = new System.Drawing.Size(75, 23);
            this._NewGridButton.TabIndex = 2;
            this._NewGridButton.Text = "New grid";
            this._NewGridButton.UseVisualStyleBackColor = true;
            this._NewGridButton.Click += new System.EventHandler(this._NewGridButton_Click);
            // 
            // _ShowNextMoveButton
            // 
            this._ShowNextMoveButton.Location = new System.Drawing.Point(25, 97);
            this._ShowNextMoveButton.Name = "_ShowNextMoveButton";
            this._ShowNextMoveButton.Size = new System.Drawing.Size(97, 23);
            this._ShowNextMoveButton.TabIndex = 5;
            this._ShowNextMoveButton.Text = "Show next move";
            this._ShowNextMoveButton.UseVisualStyleBackColor = true;
            this._ShowNextMoveButton.Click += new System.EventHandler(this._ShowNextMoveButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridUserControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this._NewGridButton);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this._ResetGridButton);
            this.splitContainer1.Panel2.Controls.Add(this._ShowNextMoveButton);
            this.splitContainer1.Panel2.Controls.Add(this._FillGridButton);
            this.splitContainer1.Size = new System.Drawing.Size(485, 294);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 7;
            // 
            // _MainPanel
            // 
            this._MainPanel.Controls.Add(this.splitContainer1);
            this._MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._MainPanel.Location = new System.Drawing.Point(0, 0);
            this._MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this._MainPanel.Name = "_MainPanel";
            this._MainPanel.Size = new System.Drawing.Size(485, 294);
            this._MainPanel.TabIndex = 8;
            // 
            // gridUserControl1
            // 
            this.gridUserControl1.AutoSize = true;
            this.gridUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridUserControl1.Location = new System.Drawing.Point(0, 0);
            this.gridUserControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gridUserControl1.Name = "gridUserControl1";
            this.gridUserControl1.Size = new System.Drawing.Size(263, 294);
            this.gridUserControl1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Location = new System.Drawing.Point(9, 11);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(30, 13);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "textBox1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(50, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 100);
            this.panel1.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 294);
            this.Controls.Add(this._MainPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this._MainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GridUserControl gridUserControl1;
        private System.Windows.Forms.Button _ResetGridButton;
        private System.Windows.Forms.Button _FillGridButton;
        private System.Windows.Forms.Button _NewGridButton;
        private System.Windows.Forms.Button _ShowNextMoveButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel _MainPanel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;

    }
}

