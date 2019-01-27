using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Enemy : PictureBox
    {
        Form1 form;
        public int Speed = 1;
        public int HP = 1;
        private int Direction = 1;
        public int Damage = 1;
        public int Level = 1;
        public int Gold = 1;
        private Enemy()
        {
            
        }
        public Enemy(Size en, Color co, Point l)
        {
            this.BackColor = co;
            this.Size = en;
            this.Location =l;
            this.Visible = true;
            this.BringToFront();
        }
        public new void Move(List<Terrains> Terrains)
        {
            Point move1 = new Point(Location.X, Location.Y - Speed);
            Point move2 = new Point(Location.X, Location.Y + Speed);
            Point move3 = new Point(Location.X + Speed, Location.Y);
            Point move4 = new Point(Location.X - Speed, Location.Y);
            Point selfLoc = new Point(this.Location.X,this.Location.Y);
                foreach(Terrains terr in Terrains)
            {
                if(terr.finish)
                {
                    if(terr.Location.Equals(selfLoc))
                    {
                        form.hp--;
                    }
                }
            }
            

            switch (Direction)
            {
                case 1:
                    if (CheckCollisions(this, move1, Terrains))
                    {
                        Location = move1;
                    }
                    else if (CheckCollisions(this, move3, Terrains))
                    {
                        Direction = 3;
                    }
                    else if (CheckCollisions(this, move4, Terrains))
                    {
                        Direction = 4;
                    }
                    break;
                case 2:
                    if (CheckCollisions(this, move2, Terrains))
                    {
                        Location = move2;
                    }
                    else if (CheckCollisions(this, move3, Terrains))
                    {
                        Direction = 3;
                    }
                    else if (CheckCollisions(this, move4, Terrains))
                    {
                        Direction = 4;
                    }
                    break;
                case 3:
                    if (CheckCollisions(this, move3, Terrains))
                    {
                        Location = move3;
                    }
                    else if (CheckCollisions(this, move1, Terrains))
                    {
                        Direction = 1;
                    }
                    else if (CheckCollisions(this, move2, Terrains))
                    {
                        Direction = 2;
                    }
                    break;

                case 4:
                    if (CheckCollisions(this, move4, Terrains))
                    {
                        Location = move4;
                    }
                    else if (CheckCollisions(this, move1, Terrains))
                    {
                        Direction = 1;
                    }
                    else if (CheckCollisions(this, move2, Terrains))
                    {
                        Direction = 2;
                    }
                    break;

            }
        }

        private bool CheckCollision(Point p, Control pl, Terrains terr)
        {
            Rectangle plRect = new Rectangle(p, pl.Size);
            Rectangle ColRect = new Rectangle(terr.Location, terr.Size);
            return plRect.IntersectsWith(ColRect);
        }

        private bool CheckCollisions(Control enemy, Point p, List<Terrains> terrains)
        {
            foreach (Terrains terrain in terrains)
            {
                if (CheckCollision(p, enemy, terrain) == true)
                {
                    return false;
                }

            }
            return true;
        }

        public bool Finished(List<Terrains> terrains)
        {
            return false;
        }
    }
}
