using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Linq;

namespace NEA
{
    public partial class ExportForm : Form
    {
        private string filePathLoaded;
        private NoteButton[,] noteGrid { get; }
        private int gridWidth { get; }
        private int gridLength { get; }
        public ExportForm(NoteButton[,] notesP, int gridWidthP, int gridLengthP) //P for passed
        {
            noteGrid = notesP;
            gridWidth = gridWidthP;
            gridLength = gridLengthP;
            InitializeComponent();
            ExportForm_Load();
        }

        public void ExportForm_Load() //Sets tooltips explaining Starting Beat and Beats Per Note
        {
            GeneralToolTip.SetToolTip(this.StartingBeatLabel, "The \"Current Beat\" value shown on the left hand side of the ingame editor. Input the current beat value that you want the match pattern to start on.");
            GeneralToolTip.SetToolTip(this.BeatsPerNoteLabel, "How many \"Current Beat\" values you want to separate each note in the pattern. e.g. 1 = a quarter note, 0.25 = a sixteenth note, 0.01 is very close together.");
            DifficultyBox.Items.Add("Easy");
            DifficultyBox.Items.Add("Normal");
            DifficultyBox.Items.Add("Hard");
            DifficultyBox.Items.Add("Expert");
            DifficultyBox.Items.Add("XD");
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
            filePathLoaded = browseFileDialog.FileName;
            FileLoadedLabel.Text = Path.GetFileName(browseFileDialog.FileName);

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if(ExportErrorCheck())
            {
                return;
            }

            string file;
            using(StreamReader sr = new StreamReader(filePathLoaded))
            {
                file = sr.ReadToEnd();
                sr.Close();
            }
            srtbFile srtbFile = JsonConvert.DeserializeObject<srtbFile>(file);
            SO_TrackData trackData = JsonConvert.DeserializeObject<SO_TrackData>(srtbFile.largestringvaluescontainer.values[DifficultyBox.SelectedIndex+1].val);
            SO_ClipInfo clipInfo = JsonConvert.DeserializeObject<SO_ClipInfo>(srtbFile.largestringvaluescontainer.values[6].val);

            decimal firstBeat = CurrentBeatUpDown.Value;
            decimal lastBeat = firstBeat + (BeatsPerNoteUpDown.Value * gridLength);
            float firstNoteTime = FindTimeOfBeat((float)firstBeat, clipInfo, clipInfo.timeSignatureMarkers[0].startingBeat);
            float lastNoteTime = FindTimeOfBeat((float)lastBeat, clipInfo, clipInfo.timeSignatureMarkers[0].startingBeat);

            if(ReplaceNotesCheckbox.Checked)
            {
                RemoveNotesInRange(firstNoteTime, lastNoteTime, trackData);
            }
            AddNewNotes(firstNoteTime, trackData);

            srtbFile.largestringvaluescontainer.values[DifficultyBox.SelectedIndex+1].val = JsonConvert.SerializeObject(trackData);
            file = JsonConvert.SerializeObject(srtbFile);
            File.WriteAllText(filePathLoaded, file);
            this.Close();
        }

        private void RemoveNotesInRange(float firstNoteTime, float lastNoteTime, SO_TrackData trackData)
        {
            int length = trackData.notes.Count;
            for(int i = 0; i < length; i++)
            {
                if(trackData.notes[i].time >= firstNoteTime && trackData.notes[i].time <= lastNoteTime)
                {
                    trackData.notes.RemoveAt(i);
                    length--;
                }
            }

        }
        private void AddNewNotes(float firstNoteTime, SO_TrackData trackData)
        {
            for (int i = gridLength-1; i >= 0; i--)
            {
                float time = firstNoteTime + (float)BeatsPerNoteUpDown.Value * (gridLength-i-1);
                for (int j = 0; j < gridWidth; j++)
                {
                    if(noteGrid[j,i].Colour != 0)
                    {
                        int column = FindColumn(j);
                        note note = new note()
                        {
                            time = time,
                            type = 1,
                            colorIndex = noteGrid[j, i].Colour - 1,
                            column = column,
                            m_size = 0
                        };
                        trackData.notes.Add(note);
                    }
                }
            }
            if (trackData.notes.Count != 0)
            {
                trackData.notes = trackData.notes.OrderBy(a => a.time).ToList();
            }
        }

        private int FindColumn(int j)
        {
            return j - gridWidth / 2;
        }

        private float FindTimeOfBeat(float beatToFind, SO_ClipInfo clipInfo, int startingBeat)
        {
            bpmMarker[] bpmMarkers = clipInfo.bpmMarkers; //for legibility
            float beat = (float)startingBeat;
            bool beatExceeded = false;
            int i = 0;
            if (bpmMarkers.Length > 1)
            {
                for (i = 0; i < bpmMarkers.Length && !beatExceeded; i++)
                {
                    float tempBeat = beat + (bpmMarkers[i + 1].clipTime - bpmMarkers[i].clipTime) / bpmMarkers[i].beatLength;
                    beatExceeded = tempBeat > beatToFind ? true : false;
                    if (!beatExceeded) beat = tempBeat;
                }
            }
            return bpmMarkers[i].clipTime + (beatToFind - beat) * bpmMarkers[i].beatLength;
        }

        //Check for errors in user input in Export form
        private bool ExportErrorCheck()
        {
            if(FileLoadedLabel.Text == "No file loaded...")
            {
                //!!!!!!!!!Send warning!!!!!!!!!!
                return true;
            }
            if(DifficultyBox.SelectedIndex == 0)
            {
                //!!!!!!!!!Send warning!!!!!!!!!!!
                return true;
            }
            return false;
        }
    }
}
