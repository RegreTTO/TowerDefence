using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace WindowsFormsApplication1
{
    public class Terrains : PictureBox
    {
        public bool finish;
        int passable;
        int role = 0;

        private Terrains()
        {

        }
        public Terrains(Size s, Color c, Point p, int role, int passable, bool finsh)
        {
            this.Location = p;
            this.BackColor = c;
            this.Size = s;

        }

       
    }

}
