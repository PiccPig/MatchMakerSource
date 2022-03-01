
namespace NEA
{
    partial class ExportForm
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
            this.components = new System.ComponentModel.Container();
            this.ReplaceNotesCheckbox = new System.Windows.Forms.CheckBox();
            this.CurrentBeatUpDown = new System.Windows.Forms.NumericUpDown();
            this.StartingBeatLabel = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FileLoadedLabel = new System.Windows.Forms.Label();
            this.srtbFileLabel = new System.Windows.Forms.Label();
            this.BeatsPerNoteLabel = new System.Windows.Forms.Label();
            this.BeatsPerNoteUpDown = new System.Windows.Forms.NumericUpDown();
            this.GeneralToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ExportButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.DifficultyBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentBeatUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeatsPerNoteUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ReplaceNotesCheckbox
            // 
            this.ReplaceNotesCheckbox.AutoSize = true;
            this.ReplaceNotesCheckbox.Location = new System.Drawing.Point(34, 199);
            this.ReplaceNotesCheckbox.Name = "ReplaceNotesCheckbox";
            this.ReplaceNotesCheckbox.Size = new System.Drawing.Size(175, 19);
            this.ReplaceNotesCheckbox.TabIndex = 0;
            this.ReplaceNotesCheckbox.Text = "Replace existing notes in file";
            this.ReplaceNotesCheckbox.UseVisualStyleBackColor = true;
            // 
            // CurrentBeatUpDown
            // 
            this.CurrentBeatUpDown.DecimalPlaces = 4;
            this.CurrentBeatUpDown.Location = new System.Drawing.Point(160, 68);
            this.CurrentBeatUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.CurrentBeatUpDown.Name = "CurrentBeatUpDown";
            this.CurrentBeatUpDown.Size = new System.Drawing.Size(120, 23);
            this.CurrentBeatUpDown.TabIndex = 1;
            // 
            // StartingBeatLabel
            // 
            this.StartingBeatLabel.AutoSize = true;
            this.StartingBeatLabel.Location = new System.Drawing.Point(34, 70);
            this.StartingBeatLabel.Name = "StartingBeatLabel";
            this.StartingBeatLabel.Size = new System.Drawing.Size(77, 15);
            this.StartingBeatLabel.TabIndex = 2;
            this.StartingBeatLabel.Text = "Starting Beat:";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(160, 27);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 3;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // FileLoadedLabel
            // 
            this.FileLoadedLabel.AutoSize = true;
            this.FileLoadedLabel.Location = new System.Drawing.Point(241, 31);
            this.FileLoadedLabel.Name = "FileLoadedLabel";
            this.FileLoadedLabel.Size = new System.Drawing.Size(90, 15);
            this.FileLoadedLabel.TabIndex = 4;
            this.FileLoadedLabel.Text = "No file loaded...";
            // 
            // srtbFileLabel
            // 
            this.srtbFileLabel.AutoSize = true;
            this.srtbFileLabel.Location = new System.Drawing.Point(34, 31);
            this.srtbFileLabel.Name = "srtbFileLabel";
            this.srtbFileLabel.Size = new System.Drawing.Size(54, 15);
            this.srtbFileLabel.TabIndex = 5;
            this.srtbFileLabel.Text = ".srtb File:";
            // 
            // BeatsPerNoteLabel
            // 
            this.BeatsPerNoteLabel.AutoSize = true;
            this.BeatsPerNoteLabel.Location = new System.Drawing.Point(34, 111);
            this.BeatsPerNoteLabel.Name = "BeatsPerNoteLabel";
            this.BeatsPerNoteLabel.Size = new System.Drawing.Size(85, 15);
            this.BeatsPerNoteLabel.TabIndex = 6;
            this.BeatsPerNoteLabel.Text = "Beats per note:";
            // 
            // BeatsPerNoteUpDown
            // 
            this.BeatsPerNoteUpDown.DecimalPlaces = 4;
            this.BeatsPerNoteUpDown.Location = new System.Drawing.Point(160, 109);
            this.BeatsPerNoteUpDown.Name = "BeatsPerNoteUpDown";
            this.BeatsPerNoteUpDown.Size = new System.Drawing.Size(120, 23);
            this.BeatsPerNoteUpDown.TabIndex = 7;
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(311, 230);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 8;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(230, 230);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Location = new System.Drawing.Point(34, 154);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(58, 15);
            this.DifficultyLabel.TabIndex = 10;
            this.DifficultyLabel.Text = "Difficulty:";
            // 
            // DifficultyBox
            // 
            this.DifficultyBox.FormattingEnabled = true;
            this.DifficultyBox.Location = new System.Drawing.Point(160, 151);
            this.DifficultyBox.Name = "DifficultyBox";
            this.DifficultyBox.Size = new System.Drawing.Size(120, 23);
            this.DifficultyBox.TabIndex = 11;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 265);
            this.Controls.Add(this.DifficultyBox);
            this.Controls.Add(this.DifficultyLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.BeatsPerNoteUpDown);
            this.Controls.Add(this.BeatsPerNoteLabel);
            this.Controls.Add(this.srtbFileLabel);
            this.Controls.Add(this.FileLoadedLabel);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.StartingBeatLabel);
            this.Controls.Add(this.CurrentBeatUpDown);
            this.Controls.Add(this.ReplaceNotesCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExportForm";
            this.Text = "Export to SRXD";
            ((System.ComponentModel.ISupportInitialize)(this.CurrentBeatUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeatsPerNoteUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ReplaceNotesCheckbox;
        private System.Windows.Forms.NumericUpDown CurrentBeatUpDown;
        private System.Windows.Forms.Label StartingBeatLabel;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label FileLoadedLabel;
        private System.Windows.Forms.Label srtbFileLabel;
        private System.Windows.Forms.Label BeatsPerNoteLabel;
        private System.Windows.Forms.NumericUpDown BeatsPerNoteUpDown;
        private System.Windows.Forms.ToolTip GeneralToolTip;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.ComboBox DifficultyBox;
    }
}