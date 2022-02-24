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
    public class NoteButton : Button
    {
        private Color colour1 = Color.FromArgb(255, 67, 143, 250);  // default match colours
        private Color colour2 = Color.FromArgb(255, 247, 32, 32);
        private Color transparent = Color.FromArgb(0, 255, 255, 255);
        public int Colour { get; set; } //Used to easily convert colour to the .srtb colour type.

        public void ChangeColour(int c)
        //Changes the control's BackColor, as well as its Colour value. 
        {
            switch (c)
            {
                case 1:
                    this.BackColor = colour1;
                    this.Colour = 1;
                    break;
                case 2:
                    this.BackColor = colour2;
                    this.Colour = 2;
                    break;
                default:
                    this.BackColor = transparent;
                    this.Colour = 0;
                    break;
            }
            this.Invalidate();
        }
    }
}
