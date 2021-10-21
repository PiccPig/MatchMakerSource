
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
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(12, 29);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(30, 15);
            this.SizeLabel.TabIndex = 0;
            this.SizeLabel.Text = "Size:";
            // 
            // LengthLabel
            // 
            this.LengthLabel.AutoSize = true;
            this.LengthLabel.Location = new System.Drawing.Point(54, 3);
            this.LengthLabel.Name = "LengthLabel";
            this.LengthLabel.Size = new System.Drawing.Size(47, 15);
            this.LengthLabel.TabIndex = 1;
            this.LengthLabel.Text = "Length:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(115, 2);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(42, 15);
            this.WidthLabel.TabIndex = 2;
            this.WidthLabel.Text = "Width:";
            // 
            // LengthUpDown
            // 
            this.LengthUpDown.Location = new System.Drawing.Point(54, 27);
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
            this.WidthUpDown.Location = new System.Drawing.Point(115, 27);
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
            this.WidthUpDown.ValueChanged += new System.EventHandler(this.WidthUpDown_ValueChanged);
            // 
            // SizeSubmitButton
            // 
            this.SizeSubmitButton.Location = new System.Drawing.Point(197, 25);
            this.SizeSubmitButton.Name = "SizeSubmitButton";
            this.SizeSubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SizeSubmitButton.TabIndex = 5;
            this.SizeSubmitButton.Text = "Submit";
            this.SizeSubmitButton.UseVisualStyleBackColor = true;
            this.SizeSubmitButton.Click += new System.EventHandler(this.SizeSubmitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(373, 25);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MatchMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SizeSubmitButton);
            this.Controls.Add(this.WidthUpDown);
            this.Controls.Add(this.LengthUpDown);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.LengthLabel);
            this.Controls.Add(this.SizeLabel);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MatchMaker";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.LengthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void WidthUpDown_ValueChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label LengthLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.NumericUpDown LengthUpDown;
        private System.Windows.Forms.NumericUpDown WidthUpDown;
        private System.Windows.Forms.Button SizeSubmitButton;
        private System.Windows.Forms.Button ClearButton;
    }
}

