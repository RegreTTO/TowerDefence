using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public class Tower : PictureBox
    {
        public int Damage = 1;
        public int Cost = 1;
        public int AttackSpeed = 1;
        public int Level = 1;
        public int radius = 1;
        public int returnCost = 1;
        private Tower()
        {

        }
        public Tower(int cost, System.Drawing.Color color, int damage, int attackSpeed, int radius, int returnCost, int level, System.Drawing.Point point, System.Drawing.Size size)
        {
            this.Size = size;
            this.Location = point;
            this.BackColor = color;
        }
    }
}
