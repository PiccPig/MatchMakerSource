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
        private Color transparent = Color.FromArgb(0, 0, 0, 0);
        public int Colour { get; set; }

        public void ChangeColour()
        {
            this.Colour = (this.Colour + 1) % 3;
            switch (this.Colour)
            {
                case 1:
                    this.BackColor = colour1;
                    break;
                case 2:
                    this.BackColor = colour2;
                    break;
                default:
                    this.BackColor = transparent;
                    break;
            }
            this.Invalidate();
        }
    }
}
