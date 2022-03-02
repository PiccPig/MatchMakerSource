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

        #region Setup

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

        private DialogResult SendWarning(string v)
        //Shows a general OK/Cancel warning dialog box with a specified message. Returns the result clicked by the user.
        {
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(v, title, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            return DialogResult;
        }

        public void ExportForm_Load()
        //Sets tooltips explaining Starting Beat and Beats Per Note, also sets 
        {
            GeneralToolTip.SetToolTip(this.StartingBeatLabel, "The \"Current Beat\" value shown on the left hand side of the ingame editor. Input the current beat value that you want the match pattern to start on.");
            GeneralToolTip.SetToolTip(this.BeatsPerNoteLabel, "How many \"Current Beat\" values you want to separate each note in the pattern. e.g. 1 = a quarter note, 0.25 = a sixteenth note, 0.01 is very close together.");
            DifficultyBox.Items.Add("Easy");
            DifficultyBox.Items.Add("Normal");
            DifficultyBox.Items.Add("Hard");
            DifficultyBox.Items.Add("Expert");
            DifficultyBox.Items.Add("XD");
        }

        #endregion

        #region Buttons

        private void CancelButton_Click(object sender, EventArgs e)
        //Closes the form.
        {
            this.Close();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        //Opens a file dialog to select a .srtb file to write to.
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
        //Checks for errors from user before exporting.
        {
            if (ExportErrorCheck())
            {
                return;
            }
            Export();
        }

        private bool ExportErrorCheck()
        //Check for errors in user input in Export form. Returns true if either check comes back true, otherwise returns false.
        {
            if (FileLoadedLabel.Text == "No file loaded...")
            {
                DialogResult dr = SendWarning("No file selected! Please try again.");
                return true;
            }
            if (DifficultyBox.SelectedIndex == 0)
            {
                DialogResult dr = SendWarning("No difficulty selected! Please try again.");
                return true;
            }
            return false;
        }

        #endregion

        #region Export

        private void Export()
        {
            string file;
            using (StreamReader sr = new StreamReader(filePathLoaded))
            {
                file = sr.ReadToEnd();
                sr.Close();
            }
            srtbFile srtbFile = JsonConvert.DeserializeObject<srtbFile>(file);
            SO_TrackData trackData = JsonConvert.DeserializeObject<SO_TrackData>(srtbFile.largeStringValuesContainer.values[DifficultyBox.SelectedIndex + 1].val); //deserialises the selected difficulties TrackData from the srtb object
            SO_ClipInfo clipInfo = JsonConvert.DeserializeObject<SO_ClipInfo>(srtbFile.largeStringValuesContainer.values[6].val); //Deserialises the ClipInfo from the srtb object

            //gather user inputs from form controls
            decimal firstBeat = CurrentBeatUpDown.Value;
            decimal lastBeat = firstBeat + (BeatsPerNoteUpDown.Value * gridLength);

            float[] values = FindTimeOfBeat((float)firstBeat, clipInfo);
            float firstNoteTime = values[0];
            float beatLength = values[1];

            float lastNoteTime = FindTimeOfBeat((float)lastBeat, clipInfo)[0];

            if (ReplaceNotesCheckbox.Checked)
            {
                trackData = RemoveNotesInRange(firstNoteTime, lastNoteTime, trackData); //Remove existing notes from the TrackData
            }

            //add new notes to the TrackData object
            AddNewNotes(firstNoteTime, trackData, beatLength);

            //re-serialise the objects
            srtbFile.largeStringValuesContainer.values[DifficultyBox.SelectedIndex + 1].val = JsonConvert.SerializeObject(trackData);
            file = JsonConvert.SerializeObject(srtbFile);
            File.WriteAllText(filePathLoaded, file);
            this.Close();
        }

        private float[] FindTimeOfBeat(float beatToFind, SO_ClipInfo clipInfo)
        {
            bpmMarker[] bpmMarkers = clipInfo.bpmMarkers; //for legibility
            int startingBeat = clipInfo.timeSignatureMarkers[0].startingBeat;
            float beat = startingBeat < 0 ? startingBeat * -1 : 0; //Some charts may have a time signature marker before the first bpm marker, so beat 0 will come earlier, this needs to be accounted for, but only if startingbeat is less than 0.
            float bufferTime = startingBeat < 0 ? startingBeat * -1 * bpmMarkers[0].beatLength : 0;
            bool beatExceeded = false;
            int i = 0;
            if (bpmMarkers.Length > 1)
            {
                for (i = 0; i < bpmMarkers.Length - 1 && !beatExceeded; i++)
                {
                    float tempBeat = beat + (bpmMarkers[i + 1].clipTime - bpmMarkers[i].clipTime) / bpmMarkers[i].beatLength; //new beat = old + (change in time/time per beat)
                    beatExceeded = tempBeat > beatToFind;
                    if (!beatExceeded) beat = tempBeat;
                }
                i--; // is incremented by 1 after last iteration for loop, need to decrement it again.
            }
            float[] values = new float[2] { bpmMarkers[i].clipTime + bufferTime + (beatToFind - beat) * bpmMarkers[i].beatLength, bpmMarkers[i].beatLength }; //2nd value is the beat length, which is needed for AddNewNotes.
            return values; // time = time of current marker + distance in beats from beat * time per beat
        }

        private SO_TrackData RemoveNotesInRange(float firstNoteTime, float lastNoteTime, SO_TrackData trackData)
        //Removes all notes in the time range calculated. Returns TrackData with the modified notes.
        {
            int length = trackData.notes.Count;
            for(int i = 0; i < length; i++) //for each existing note
            {
                if(trackData.notes[i].time >= firstNoteTime && trackData.notes[i].time <= lastNoteTime) //if note is in the given range, remove the note
                {
                    trackData.notes.RemoveAt(i);
                    length--; //avoiding index not in range
                }
            }
            return trackData;
        }

        private void AddNewNotes(float firstNoteTime, SO_TrackData trackData, float beatLength)
        //takes notebuttons from the note grid, take values from it and put into a note object, add to the list in TrackData.
        {
            for (int i = gridLength-1; i >= 0; i--) //for each row
            {
                float time = firstNoteTime + beatLength * (float)BeatsPerNoteUpDown.Value * (gridLength-i-1); ; //index 0 is at the top of the grid, so we need to take the notes in reverse order from the grid.
                for (int j = 0; j < gridWidth; j++) //for each note in current row
                {
                    if(noteGrid[j,i].Colour != 0) //if note is not transparent
                    {
                        int column = FindColumn(j);
                        note note = new note()
                        {
                            time = time,
                            type = 0, //match note value
                            colorIndex = noteGrid[j, i].Colour - 1, //blue = 0, red = 1
                            column = column,
                            m_size = 0
                        };
                        trackData.notes.Add(note);
                    }
                }
            }
            if (trackData.notes.Count != 0)
            {
                trackData.notes = trackData.notes.OrderBy(a => a.time).ToList(); //Order the notes in the list. Technically not needed, but keeps it in the format the game does it.
            }
        }

        private int FindColumn(int j)
        {
            return (j - gridWidth / 2)*-1; //needs to be horizontally flipped for some reason
        }

        #endregion
    }
}
