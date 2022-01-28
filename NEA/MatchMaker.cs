using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA
{
    public partial class MatchMaker : System.Windows.Forms.Form
    {
        private int gridLength = 20; //   initial size of grid
        private int gridWidth = 9;
        private NoteButton[,] notes;
        private int gridSizeHorizontal = 270; //initial pixel dimensions of the grid
        private int gridSizeVertical = 600;
        private const int topBuffer = 90;
        private const int sideBuffer = 50;

        private bool leftMouseToggle = false;
        private bool rightMouseToggle = false;
        private bool middleMouseToggle = false;

        public MatchMaker()
        {
            InitializeComponent();
            MatchMaker_Load();
        }

        public void MatchMaker_Load()
        {
            notes = new NoteButton[gridWidth, gridLength];
            notes = CreateBlankGrid(gridWidth, gridLength);
            ShowGrid(notes);
        }

        private NoteButton[,] CreateBlankGrid(int width, int length)
        {
            NoteButton[,] dummyGrid = new NoteButton[width, length];
            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    dummyGrid[i, j] = new NoteButton()
                    {
                        BackColor = Color.Transparent,
                        Colour = 0
                    };
                }
            }
            return dummyGrid;
        }

        /* 
         * 
         */
        public void ShowGrid(NoteButton[,] newnotes)
        {
            notes = newnotes;
            int buttonWidth = gridSizeHorizontal / gridWidth;
            int buttonHeight = gridSizeVertical / gridLength;
            for (int j = 0; j < gridLength; j++)
            {
                for (int i = 0; i < gridWidth; i++)
                {
                    notes[i, j] = new NoteButton()
                    {
                        Location = new Point((i * buttonWidth) + sideBuffer, (j * buttonHeight) + topBuffer),
                        Size = new Size(buttonWidth, buttonHeight),
                        Colour = notes[i, j].Colour,
                        BackColor = notes[i, j].BackColor
                    };
                    notes[i, j].MouseDown += new MouseEventHandler(ClickHandler);
                    notes[i, j].MouseEnter += new EventHandler(NoteButton_MouseEnter);
                    Controls.Add(notes[i, j]);
                }
            }
        }

        public void RemoveGrid()
        {
            foreach(NoteButton note in notes)
            {
                Controls.Remove(note);
            }
        }

        /* Triggered when the mouse hovers over a button:
         * if LMouse is toggled, change button to colour 1
         * if RMouse is toggled, change button to colour 2
         * if MMouse is toggled, clear the colour.            */
        private void NoteButton_MouseEnter(object sender, EventArgs e)
        {
            NoteButton b = (NoteButton)sender;
            if (leftMouseToggle)
            {
                b.ChangeColour(1);
            }
            if (rightMouseToggle)
            {
                b.ChangeColour(2);
            }
            if (middleMouseToggle)
            {
                b.ChangeColour(0);
            }
        }

        private void SizeSubmitButton_Click(object sender, EventArgs e)
        {
            if(gridLength != LengthUpDown.Value || gridWidth != WidthUpDown.Value)
            {
                
                int length = (int)LengthUpDown.Value;
                int width = (int)WidthUpDown.Value;
                if(length < gridLength || width < gridWidth)
                {
                    if (SendWarning("Making the grid smaller will result in losing some notes. Continue?") == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                NoteButton[,] resizedGrid = CreateBlankGrid(width,length);
                for(int j = 0; j < gridLength && j < length; j++)
                {
                    for(int i = 0; i < gridWidth && i < width; i++)
                    {
                        resizedGrid[i, j] = notes[i, j];
                    }
                }
                RemoveGrid();
                notes = resizedGrid;
                gridLength = length;
                gridWidth = width;
                ShowGrid(notes);
            }
        }

        private DialogResult SendWarning(string v)
        {
            string title = "Warning";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(v, title, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
            return DialogResult;
        }

        /* Triggered when a NoteButton is clicked:
         * If LMouse was clicked, disable both RMouse and MMouse toggles:
            * If LMouse was already toggled, disable it too. Else, enable.
         * Likewise for RMouse and MMouse.
         * Then, change the colour of that button to the corresponding colour for the mouse button clicked.
        */
        private void ClickHandler(object sender, MouseEventArgs e)
        {
            if (Text[^1] != '*') Text += "*";
            NoteButton b = (NoteButton)sender;
            if (e.Button == MouseButtons.Left)
            {
                leftMouseToggle = !leftMouseToggle;
                rightMouseToggle = false;
                middleMouseToggle = false;
                b.ChangeColour(1);
            }
            if (e.Button == MouseButtons.Right)
            {
                rightMouseToggle = !rightMouseToggle;
                leftMouseToggle = false;
                middleMouseToggle = false;
                b.ChangeColour(2);
            }
            if (e.Button == MouseButtons.Middle)
            {
                middleMouseToggle = !middleMouseToggle;
                leftMouseToggle = false;
                rightMouseToggle = false;
                b.ChangeColour(0);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (SendWarning("This action cannot be undone. Continue?") == DialogResult.Cancel)
            {
                return;
            }
            RemoveGrid();
            ShowGrid(CreateBlankGrid(gridWidth,gridLength));
        }

        private void ShiftButton_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "ShiftUpButton":
                    if (CheckRowIsClear(0)) ShiftNotes(-1, 0);
                    else //expand 1 down if there are notes at top - same as pushing up into a new row above
                    {
                        LengthUpDown.Value++;
                        SizeSubmitButton_Click(SizeSubmitButton, null);
                    }
                    break;
                case "ShiftDownButton":
                    if(!CheckRowIsClear(gridLength-1)) //Make room to shift down if there isnt any
                    {
                        LengthUpDown.Value++;
                        SizeSubmitButton_Click(SizeSubmitButton, null);
                    }
                    ShiftNotes(1, 0);
                    break;
                case "ShiftLeftButton":
                    if(CheckColumnIsClear(0)) ShiftNotes(0, -1);
                    else //expand 2 right if there are notes on left - since the grid is centered on the middle, this is the same as expanding 1 on both sides then shifting left
                    {
                        WidthUpDown.Value += 2;
                        SizeSubmitButton_Click(SizeSubmitButton, null);
                    }
                    break;
                case "ShiftRightButton":
                    if(!CheckRowIsClear(gridWidth-1)) // Make room to shift right if there isnt any
                    {
                        WidthUpDown.Value += 2;
                        SizeSubmitButton_Click(SizeSubmitButton, null);
                    }
                    ShiftNotes(0, 1);
                    break;
                default:
                    throw new ArgumentException("Sender not a shift button?");
            }
        }

        private bool CheckColumnIsClear(int column)
        {
            for (int i = 0; i < gridLength; i++)
            {
                if (notes[column, i].Colour != 0) return false;
            }
            return true;
        }

        private bool CheckRowIsClear(int row)
        {
            for(int i = 0; i < gridWidth; i++)
            {
                if (notes[i, row].Colour != 0) return false;
            }
            return true;
        }

        private void ShiftNotes(int down, int right)
        {
            NoteButton[,] dummyNotes = CreateBlankGrid(gridWidth,gridLength);
            for(int j = down == -1 ? 1 : 0; j < gridLength; j++)
            {
                for(int i = right == -1 ? 1 : 0; i < gridWidth; i++)
                {
                    int X = i + right;
                    int Y = j + down;
                    if(X < gridWidth && Y < gridLength && i < gridWidth && j < gridLength)
                    {
                        dummyNotes[X, Y] = notes[i, j];
                    }
                }
            }
            RemoveGrid();
            ShowGrid(dummyNotes);
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                RestoreDirectory = true,
                Title = "Open...",
                DefaultExt = ".txt",
                Filter = "txt files (*.txt)|*.txt",
                CheckFileExists = true,
                CheckPathExists = true
            };
            openFileDialog1.ShowDialog();
            string file = "";
            using(StreamReader sr = new StreamReader(openFileDialog1.FileName))
            {
                file = sr.ReadToEnd();
                sr.Close();
            }
            NoteButton[,] newNotes = FileToGrid(file);
            RemoveGrid();
            notes = newNotes;
            gridWidth = notes.GetLength(0); WidthUpDown.Value = gridWidth;
            gridLength = notes.GetLength(1); LengthUpDown.Value = gridLength;
            ShowGrid(notes);
        }

        /* Creates a file dialog to pick which file to save the RLE to.
         * Then writes the RLE string to the selected file, and changes the name of the form to the saved filename.
         */
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog()
            {
                InitialDirectory = @"C:\",
                RestoreDirectory = true,
                Title = "Save As...",
                DefaultExt = ".txt",
                Filter = "txt files(*.txt)|*.txt",
                CheckFileExists = false,
                CheckPathExists = true
            };
            saveFileDialog1.ShowDialog();
            string encodedGrid = EncodeNoteGrid(notes);
            if(!File.Exists(saveFileDialog1.FileName))
            {
                File.Create(saveFileDialog1.FileName);
            }
            using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
            {
                sw.Write(encodedGrid);
                sw.Close();
            }
            Text = $"MatchMaker ({saveFileDialog1.FileName.Split('\\')[^1]})"; //changes form title to just the filename of the filepath
        }

        /* Encodes NoteButton grid into an RLE file:
         * first 3 characters width, second 3 characters length, remaining characters in pairs of 2: first for run colour, second for run length.
         */
        private string EncodeNoteGrid(NoteButton[,] notes)
        {
            string encodedGrid = "";
            encodedGrid += $"{gridWidth:000}{gridLength:000}"; //Padded to 3 spaces with leading zeroes
            encodedGrid += GridToRLE(notes);
            return encodedGrid;
        }

        private string GridToRLE(NoteButton[,] notes) //See EncodeNoteGrid() for description - this is encoding the notes themselves and not the width/length.
        {
            string rle = "";
            int currentColour = notes[0, 0].Colour;
            int currentRun = 1;
            for (int i = 0; i < gridWidth; i++)
            {
                for (int j = i == 0 ? 1 : 0; j < gridLength; j++)//If i is 0 (on the very first square) set j to 1 as 0,0 has already been accounted for.
                {
                    if (notes[i, j].Colour == currentColour && currentRun < 9)
                    {
                        currentRun++;
                    }
                    else
                    {
                        rle += $"{currentColour}{currentRun}";
                        currentColour = notes[i, j].Colour;
                        currentRun = 1;
                    }
                }
            }
            rle += $"{currentColour}{currentRun}";
            return rle;
        }

        // Converts the contents of the given .txt file as a string into a NoteButton[,], assigning each button the correct colour.
        private NoteButton[,] FileToGrid(string grid) 
        {
            int width = int.Parse(grid[0..3]); //First 3 characters are the width of the grid
            int length = int.Parse(grid[3..6]); //2nd 3 characters are the length of the grid
            string RLE = grid[6..]; //Remaining characters is RLE of the grid notes' colours.
            NoteButton[,] newNotes = new NoteButton[width, length];
            newNotes = CreateBlankGrid(width,length);

            int currentCell = 0;
            for(int i = 0; i < RLE.Length; i+=2)
            {
                int currentColour = int.Parse(RLE[i].ToString());
                int currentRun = int.Parse(RLE[i+1].ToString());
                for(int j = currentCell; j < currentCell + currentRun; j++)
                {
                    int X = j / length;
                    int Y = j % length;
                    newNotes[X, Y].ChangeColour(currentColour);
                }
                currentCell += currentRun;
            }
            return newNotes;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e) //Opens the exporting form
        {
            ExportForm export = new ExportForm();
            export.Show();
        }
    }
}

