using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEA
{
    public partial class MatchMaker : Form
    {
        private int gridLength = 20; //   initial size of grid
        private int gridWidth = 9;
        private NoteButton[,] notes;
        private int gridSizeHorizontal = 270; //initial pixel dimensions of the grid
        private int gridSizeVertical = 600;

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
            CreateGrid(gridLength, gridWidth, gridSizeVertical, gridSizeHorizontal, 70, 50);
        }

        public void CreateGrid(int gridLength, int gridWidth, int gridSizeVertical, int gridSizeHorizontal, int topBuffer, int sideBuffer)
        {
            int buttonWidth = gridSizeHorizontal / gridWidth;
            int buttonHeight = gridSizeVertical / gridLength;
            notes = new NoteButton[gridWidth, gridLength];
            for (int j = 0; j < gridLength; j++)
            {
                for (int i = 0; i < gridWidth; i++)
                {
                    notes[i, j] = new NoteButton()
                    {
                        Location = new Point((i * buttonWidth) + sideBuffer, (j * buttonHeight) + topBuffer),
                        Size = new Size(buttonWidth, buttonHeight),
                        BackColor = Color.Transparent,
                        Colour = 0
                    };
                    notes[i, j].MouseDown += new MouseEventHandler(ClickHandler);
                    notes[i, j].MouseEnter += new EventHandler(NoteButton_MouseEnter);
                    Controls.Add(notes[i, j]);

                }
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
            if(rightMouseToggle)
            {
                b.ChangeColour(2);
            }
            if(middleMouseToggle)
            {
                b.ChangeColour(0);
            }
        }

        private void SizeSubmitButton_Click(object sender, EventArgs e)
        {

        }

        /* Triggered when a NoteButton is clicked:
         * If LMouse was clicked, disable both RMouse and MMouse toggles:
            * If LMouse was already toggled, disable it too. Else, enable.
         * Likewise for RMouse and MMouse.
         * Then, change the colour of that button to the corresponding colour for the mouse button clicked.
        */
        private void ClickHandler(object sender, MouseEventArgs e)
        {
            NoteButton b = (NoteButton)sender;
            if (e.Button == MouseButtons.Left)
            {
                leftMouseToggle = !leftMouseToggle;
                rightMouseToggle = false;
                middleMouseToggle = false;
                b.ChangeColour(1);
            }
            if(e.Button == MouseButtons.Right)
            {
                rightMouseToggle = !rightMouseToggle;
                leftMouseToggle = false;
                middleMouseToggle = false;
                b.ChangeColour(2);
            }
            if(e.Button == MouseButtons.Middle)
            {
                middleMouseToggle = !middleMouseToggle;
                leftMouseToggle = false;
                rightMouseToggle = false;
                b.ChangeColour(0);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {

        }

        private void ShiftButton_Click(object sender, EventArgs e)
        {
            NoteButton b = sender as NoteButton;
            switch(b.Name)
            {
                case "ShiftUpButton":
                    ShiftNotes(-1, 0);
                    break;
                case "ShiftDownButton":
                    ShiftNotes(1, 0);
                    break;
                case "ShiftLeftButton":
                    ShiftNotes(0, -1);
                    break;
                case "ShiftRightButton":
                    ShiftNotes(0, 1);
                    break;
                default:
                    throw new ArgumentException("Sender not a shift button?");
            }
        }
    }       
}
