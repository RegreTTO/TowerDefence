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
        bool finish;
        bool passable;
        Terrains.TerrainType role = TerrainType.Forest;
        private Terrains()
        {

        }
        public Terrains(Size s, Color c, Point p,Terrains.TerrainType role,bool passable, bool finish)
        {
            this.Location = p;
            this.BackColor = c;
            this.Size = s;
            this.role = role;
            this.passable = passable;
            this.finish = finish;
        }
        public enum TerrainType : int
        {
            Forest = 0,
            Road = 1,
            Target = 2,
            start = 3,
        }
        public bool IsPassable()
        {
            return passable;
        }
       public bool IsFinish()
        {
            return finish;
        }
       
    }

}
