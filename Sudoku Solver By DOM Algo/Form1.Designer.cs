namespace Sudoku_Solver_By_DOM_Algo
{
    partial class Form1
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
            this.createtable = new System.Windows.Forms.Button();
            this.dimension = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SolveSudoku = new System.Windows.Forms.Button();
            this.ColorTable = new System.Windows.Forms.Button();
            this.Algorithms = new System.Windows.Forms.GroupBox();
            this.DOMAlgo = new System.Windows.Forms.RadioButton();
            this.GreadyAlgo = new System.Windows.Forms.RadioButton();
            this.AllGroubs = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.Algorithms.SuspendLayout();
            this.AllGroubs.SuspendLayout();
            this.SuspendLayout();
            // 
            // createtable
            // 
            this.createtable.Location = new System.Drawing.Point(51, 45);
            this.createtable.Name = "createtable";
            this.createtable.Size = new System.Drawing.Size(104, 23);
            this.createtable.TabIndex = 0;
            this.createtable.Text = "Create Table";
            this.createtable.UseVisualStyleBackColor = true;
            this.createtable.Click += new System.EventHandler(this.button1_Click);
            // 
            // dimension
            // 
            this.dimension.Location = new System.Drawing.Point(68, 19);
            this.dimension.Name = "dimension";
            this.dimension.Size = new System.Drawing.Size(74, 20);
            this.dimension.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dimension";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dimension);
            this.groupBox1.Controls.Add(this.createtable);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 83);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // SolveSudoku
            // 
            this.SolveSudoku.Location = new System.Drawing.Point(178, 19);
            this.SolveSudoku.Name = "SolveSudoku";
            this.SolveSudoku.Size = new System.Drawing.Size(75, 23);
            this.SolveSudoku.TabIndex = 5;
            this.SolveSudoku.Text = "Solve";
            this.SolveSudoku.UseVisualStyleBackColor = true;
            this.SolveSudoku.Click += new System.EventHandler(this.SolveSudoku_Click);
            // 
            // ColorTable
            // 
            this.ColorTable.Location = new System.Drawing.Point(178, 48);
            this.ColorTable.Name = "ColorTable";
            this.ColorTable.Size = new System.Drawing.Size(75, 23);
            this.ColorTable.TabIndex = 7;
            this.ColorTable.Text = "ColorTable";
            this.ColorTable.UseVisualStyleBackColor = true;
            this.ColorTable.Click += new System.EventHandler(this.ColorTable_Click);
            // 
            // Algorithms
            // 
            this.Algorithms.Controls.Add(this.GreadyAlgo);
            this.Algorithms.Controls.Add(this.DOMAlgo);
            this.Algorithms.Location = new System.Drawing.Point(7, 19);
            this.Algorithms.Name = "Algorithms";
            this.Algorithms.Size = new System.Drawing.Size(142, 52);
            this.Algorithms.TabIndex = 8;
            this.Algorithms.TabStop = false;
            // 
            // DOMAlgo
            // 
            this.DOMAlgo.AutoSize = true;
            this.DOMAlgo.Location = new System.Drawing.Point(7, 19);
            this.DOMAlgo.Name = "DOMAlgo";
            this.DOMAlgo.Size = new System.Drawing.Size(50, 17);
            this.DOMAlgo.TabIndex = 0;
            this.DOMAlgo.TabStop = true;
            this.DOMAlgo.Text = "DOM";
            this.DOMAlgo.UseVisualStyleBackColor = true;
            // 
            // GreadyAlgo
            // 
            this.GreadyAlgo.AutoSize = true;
            this.GreadyAlgo.Location = new System.Drawing.Point(75, 19);
            this.GreadyAlgo.Name = "GreadyAlgo";
            this.GreadyAlgo.Size = new System.Drawing.Size(59, 17);
            this.GreadyAlgo.TabIndex = 1;
            this.GreadyAlgo.TabStop = true;
            this.GreadyAlgo.Text = "Gready";
            this.GreadyAlgo.UseVisualStyleBackColor = true;
            // 
            // AllGroubs
            // 
            this.AllGroubs.Controls.Add(this.SolveSudoku);
            this.AllGroubs.Controls.Add(this.Algorithms);
            this.AllGroubs.Controls.Add(this.ColorTable);
            this.AllGroubs.Location = new System.Drawing.Point(12, 113);
            this.AllGroubs.Name = "AllGroubs";
            this.AllGroubs.Size = new System.Drawing.Size(272, 83);
            this.AllGroubs.TabIndex = 9;
            this.AllGroubs.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 113);
            this.Controls.Add(this.AllGroubs);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Sudoku";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Algorithms.ResumeLayout(false);
            this.Algorithms.PerformLayout();
            this.AllGroubs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createtable;
        private System.Windows.Forms.TextBox dimension;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SolveSudoku;
        private System.Windows.Forms.Button ColorTable;
        private System.Windows.Forms.GroupBox Algorithms;
        private System.Windows.Forms.RadioButton GreadyAlgo;
        private System.Windows.Forms.RadioButton DOMAlgo;
        private System.Windows.Forms.GroupBox AllGroubs;
    }
}

