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
        double cx;
        double cy;
        Point currentstep;
        Queue<Point> way = new Queue<Point>();
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
            this.Location = l;
            this.Visible = true;
            this.BringToFront();
            this.cx = this.Location.X;
            this.cy = this.Location.Y;
        }
        public new void Move(List<Terrains> Terrains)
        {
            Point move1 = new Point(Location.X, Location.Y - Speed);
            Point move2 = new Point(Location.X, Location.Y + Speed);
            Point move3 = new Point(Location.X + Speed, Location.Y);
            Point move4 = new Point(Location.X - Speed, Location.Y);
            Point selfLoc = new Point(this.Location.X, this.Location.Y);
            foreach (Terrains terr in Terrains)
            {
                if (terr.IsFinish())
                {
                    if (terr.Location.Equals(selfLoc))
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
        public void TakeWay(Queue<Point> way)
        {
            this.way = way;
        }
        public void NewMove()
        {
            //если текущий шаг не существует
            if (currentstep.Equals(new Point(0, 0)) || currentstep.Equals(this.Location))
            {
                //если есть путь
                if (way.Count > 0)
                {
                    currentstep = way.Dequeue();
                }
                else
                {

                    return;
                }
            }

            double dx = currentstep.X - this.Location.X;
            double dy = currentstep.Y - this.Location.Y;

            double a = 0;
            if (dx == 0)
            {
                if (dy > 0)
                {
                    a = Math.PI / 2;
                }
                else if (dy < 0)
                {
                    a = -Math.PI / 2;
                }
            }

            double tan = dy / dx;
            a = Math.Atan(tan);
            if (dx < 0)
            {
                a += Math.PI;
            }
            dx = Speed * Math.Cos(a);
            dy = Speed * Math.Sin(a);

            cx += dx;
            cy += dy;

            this.Location = new Point((int)Math.Round(cx), (int)Math.Round(cy));
        }
    }
}
