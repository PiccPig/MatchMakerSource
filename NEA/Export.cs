using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NEA
{
    public partial class ExportForm : Form
    {
        public ExportForm()
        {
            InitializeComponent();
            ExportForm_Load();
        }

        public void ExportForm_Load() //Sets tooltips explaining Starting Beat and Beats Per Note
        {
            GeneralToolTip.SetToolTip(this.StartingBeatLabel, "The \"Current Beat\" value shown on the left hand side of the ingame editor. Input the current beat value that you want the match pattern to start on.");
            GeneralToolTip.SetToolTip(this.BeatsPerNoteLabel, "How many \"Current Beat\" values you want to separate each note in the pattern. e.g. 1 = a quarter note, 0.25 = a sixteenth note, 0.01 is very close together.");
        }

        private void CancelButton_Click(object sender, EventArgs e) //Closes the form.
        {
            this.Close();
        }

        private void BrowseButton_Click(object sender, EventArgs e) //Opens a file dialog to select a .srtb file to write to.
        {
            OpenFileDialog browseFileDialog = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Title = "Select .srtb file",
                DefaultExt = ".srtb",
                Filter = "srtb files (*.srtb)|*.srtb",
                CheckFileExists = true,
                CheckPathExists = true
            };
            browseFileDialog.ShowDialog();
            FileLoadedLabel.Text = Path.GetFileName(browseFileDialog.FileName);

        }
    }
}
