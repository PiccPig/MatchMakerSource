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
        private int gridLength = 20;
        private int gridWidth = 9;
        private NoteButton[,] notes;
        private int gridSizeHorizontal = 270;
        private int gridSizeVertical = 600;

        public MatchMaker()
        {
            InitializeComponent();
            MatchMaker_Load();
        }

        public void MatchMaker_Load()
        {
            CreateGrid(gridLength, gridWidth, gridSizeVertical, gridSizeHorizontal,50,50);
        }

        public void CreateGrid(int gridLength, int gridWidth, int gridSizeVertical, int gridSizeHorizontal, int topBuffer, int sideBuffer)
        {
            int buttonWidth = gridSizeHorizontal / gridWidth;
            int buttonHeight = gridSizeVertical / gridLength;
            notes = new NoteButton[gridWidth, gridLength];
            for(int j = 0 ; j < gridLength ; j++ )
            {
                for (int i = 0; i < gridWidth; i++)
                {
                    notes[i, j] = new NoteButton()
                    {
                        Location = new Point((i * buttonWidth) + sideBuffer, (j * buttonHeight) + topBuffer),
                        Size = new Size(buttonWidth, buttonHeight),
                        BackColor = Color.Gray,
                        ForeColor = Color.DarkGray,
                        Colour = 0
                    };
                    notes[i, j].Click += new EventHandler(NoteButton_Click);
                    Controls.Add(notes[i, j]);
                    
                }
            }
        }

        private void NoteButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SizeSubmitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
