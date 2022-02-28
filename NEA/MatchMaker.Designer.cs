
using System;

namespace NEA
{
    partial class MatchMaker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SizeLabel = new System.Windows.Forms.Label();
            this.LengthLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.LengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.WidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.SizeSubmitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ShiftUpButton = new System.Windows.Forms.Button();
            this.ShiftLeftButton = new System.Windows.Forms.Button();
            this.ShiftDownButton = new System.Windows.Forms.Button();
            this.ShiftRightButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(15, 52);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(30, 15);
            this.SizeLabel.TabIndex = 0;
            this.SizeLabel.Text = "Size:";
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(57, 26);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(47, 15);
            this.LengthLabel.TabIndex = 1;
            this.LengthLabel.Text = "Length:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(118, 25);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(42, 15);
            this.WidthLabel.TabIndex = 2;
            this.WidthLabel.Text = "Width:";
            // 
            // LengthUpDown
            // 
            this.LengthUpDown.Location = new System.Drawing.Point(57, 50);
            this.LengthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LengthUpDown.Name = "LengthUpDown";
            this.LengthUpDown.ReadOnly = true;
            this.LengthUpDown.Size = new System.Drawing.Size(52, 23);
            this.LengthUpDown.TabIndex = 3;
            this.LengthUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // WidthUpDown
            // 
            this.WidthUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.WidthUpDown.Location = new System.Drawing.Point(118, 50);
            this.WidthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthUpDown.Name = "WidthUpDown";
            this.WidthUpDown.ReadOnly = true;
            this.WidthUpDown.Size = new System.Drawing.Size(52, 23);
            this.WidthUpDown.TabIndex = 4;
            this.WidthUpDown.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // SizeSubmitButton
            // 
            this.SizeSubmitButton.Location = new System.Drawing.Point(200, 48);
            this.SizeSubmitButton.Name = "SizeSubmitButton";
            this.SizeSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SizeSubmitButton.TabIndex = 5;
            this.SizeSubmitButton.Text = "Submit";
            this.SizeSubmitButton.UseVisualStyleBackColor = true;
            this.SizeSubmitButton.Click += new System.EventHandler(this.SizeSubmitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(400, 48);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear All";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ShiftUpButton
            // 
            this.ShiftUpButton.Location = new System.Drawing.Point(330, 26);
            this.ShiftUpButton.Name = "ShiftUpButton";
            this.ShiftUpButton.Size = new System.Drawing.Size(24, 23);
            this.ShiftUpButton.TabIndex = 7;
            this.ShiftUpButton.Text = "↑";
            this.ShiftUpButton.UseVisualStyleBackColor = true;
            this.ShiftUpButton.Click += new System.EventHandler(this.ShiftButton_Click);
            // 
            // ShiftLeftButton
            // 
            this.ShiftLeftButton.Location = new System.Drawing.Point(300, 55);
            this.ShiftLeftButton.Name = "ShiftLeftButton";
            this.ShiftLeftButton.Size = new System.Drawing.Size(24, 23);
            this.ShiftLeftButton.TabIndex = 8;
            this.ShiftLeftButton.Text = "←";
            this.ShiftLeftButton.UseVisualStyleBackColor = true;
            this.ShiftLeftButton.Click += new System.EventHandler(this.ShiftButton_Click);
            // 
            // ShiftDownButton
            // 
            this.ShiftDownButton.Location = new System.Drawing.Point(330, 55);
            this.ShiftDownButton.Name = "ShiftDownButton";
            this.ShiftDownButton.Size = new System.Drawing.Size(24, 23);
            this.ShiftDownButton.TabIndex = 9;
            this.ShiftDownButton.Text = "↓";
            this.ShiftDownButton.UseVisualStyleBackColor = true;
            this.ShiftDownButton.Click += new System.EventHandler(this.ShiftButton_Click);
            // 
            // ShiftRightButton
            // 
            this.ShiftRightButton.Location = new System.Drawing.Point(360, 55);
            this.ShiftRightButton.Name = "ShiftRightButton";
            this.ShiftRightButton.Size = new System.Drawing.Size(24, 23);
            this.ShiftRightButton.TabIndex = 10;
            this.ShiftRightButton.Text = "→";
            this.ShiftRightButton.UseVisualStyleBackColor = true;
            this.ShiftRightButton.Click += new System.EventHandler(this.ShiftButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.ExportToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.NewToolStripMenuItem.Text = "New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // ExportToolStripMenuItem
            // 
            this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
            this.ExportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExportToolStripMenuItem.Text = "Export";
            this.ExportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // MatchMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 701);
            this.Controls.Add(this.ShiftRightButton);
            this.Controls.Add(this.ShiftDownButton);
            this.Controls.Add(this.ShiftLeftButton);
            this.Controls.Add(this.ShiftUpButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SizeSubmitButton);
            this.Controls.Add(this.WidthUpDown);
            this.Controls.Add(this.LengthUpDown);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MatchMaker";
            this.Text = "MatchMaker (Unsaved)";
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.NumericUpDown LengthUpDown;
        private System.Windows.Forms.NumericUpDown WidthUpDown;
        private System.Windows.Forms.Button SizeSubmitButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ShiftUpButton;
        private System.Windows.Forms.Button ShiftLeftButton;
        private System.Windows.Forms.Button ShiftDownButton;
        private System.Windows.Forms.Button ShiftRightButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
    }
}

