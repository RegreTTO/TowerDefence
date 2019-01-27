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
        Terrains.TerrainType role = TerrainType.Forest;
        private Terrains()
        {

        }
        public Terrains(Size s, Color c, Point p,int role,int passable, bool finsh)
        {
            this.Location = p;
            this.BackColor = c;
            this.Size = s;
            this.role = TerrainType.Forest;

        }
        enum TerrainType : int
        {
            Forest = 0,
            Road = 1,
            Target = 2,
            start = 3,
        }
       
    }

}
