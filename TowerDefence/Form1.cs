using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int hp;
        int gold = 5;
        int TowerCost = 1;
        Terrains[,] terrains = new Terrains[30, 30];
        List<Terrains> Terrain = new List<Terrains>();
        List<Enemy> enemylist = new List<Enemy>();
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = gold + "";

            int[,] mass = new int[30, 30];
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    mass[i, j] = 0;
                }
            }
            mass[1, 29] = 1;
            mass[1, 28] = 1;
            mass[1, 27] = 1;
            mass[1, 26] = 1;
            mass[1, 25] = 1;
            mass[2, 25] = 1;
            mass[3, 25] = 1;
            mass[4, 25] = 1;
            mass[5, 25] = 1;
            mass[6, 25] = 1;
            mass[7, 25] = 1;
            mass[8, 25] = 1;
            mass[9, 25] = 1;
            mass[10, 25] = 1;
            mass[11, 25] = 1;
            mass[11, 24] = 1;
            mass[11, 23] = 1;
            mass[11, 22] = 1;
            mass[12, 22] = 1;
            mass[13, 22] = 1;
            mass[14, 22] = 1;
            mass[15, 22] = 1;
            mass[16, 22] = 1;
            mass[17, 22] = 1;
            mass[17, 21] = 1;
            mass[17, 20] = 1;
            mass[16, 20] = 1;
            mass[15, 20] = 1;
            mass[14, 20] = 1;
            mass[13, 20] = 1;
            mass[12, 20] = 1;
            mass[11, 20] = 1;
            mass[10, 20] = 1;
            mass[9, 20] = 1;
            mass[8, 20] = 2;



            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {

                    Terrains picturebox;
                    switch (mass[i, j])
                    {
                        case 0:

                            picturebox = new Terrains(new Size(32, 32), Color.Green, new Point(i * 32, j * 32), Terrains.TerrainType.Forest, false, false);
                            picturebox.BackColor = Color.Green;
                            terrains[i, j] = picturebox;
                            picturebox.Click += new System.EventHandler(this.picturebox_Click);
                            this.Controls.Add(picturebox);
                            break;

                        case 1:

                            picturebox = new Terrains(new Size(32, 32), Color.Green, new Point(i * 32, j * 32), Terrains.TerrainType.Road, true, false);
                            picturebox.BackColor = Color.FromArgb(202, 187, 147);
                            terrains[i, j] = picturebox;
                            this.Controls.Add(picturebox);
                            break;
                        case 2:
                            picturebox = new Terrains(new Size(32, 32), Color.Green, new Point(i * 32, j * 32), Terrains.TerrainType.start, true, true);
                            picturebox.BackColor = Color.Blue;
                            terrains[i, j] = picturebox;
                            this.Controls.Add(picturebox);
                            break;
                        default:
                            {
                                picturebox = new Terrains(new Size(32, 32), Color.Green, new Point(i * 32, j * 32), Terrains.TerrainType.Target, true, false);
                                picturebox.BackColor = Color.Green;
                                terrains[i, j] = picturebox;
                                picturebox.Click += new System.EventHandler(this.picturebox_Click);
                                this.Controls.Add(picturebox);
                                break;
                            }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Enemy enemy = new Enemy(new Size(32, 32), Color.OrangeRed, new Point(32, 29 * 32));
            this.Controls.Add(enemy);
            enemylist.Add(enemy);
        }

        public void timer2_Tick(object sender, EventArgs e)
        {

            foreach (Enemy en in enemylist)
            {
                en.Move(Terrain);
                en.BringToFront();
            }
        }
        public void picturebox_Click(object sender, EventArgs e)
        {
            if (gold >= TowerCost)
            {
                gold -= TowerCost;
                label1.Text = gold + "";
                Tower tower = new Tower(1, Color.Black, 1, 1, 1, 1, 1, (sender as PictureBox).Location, (sender as PictureBox).Size);
                this.Controls.Add(tower);
                tower.BringToFront();
            }
        }
        public Map GenerateMap(Terrains[,] terrains)
        {
            int x = 0;
            bool[,] roadmap = new bool[terrains.GetLength(0),terrains.GetLength(1)];
                for(int i = 0;0<terrains.GetLength(0); i++)
            {
                for(int j = 0;0<terrains.GetLength(1);j++)
                {

                    roadmap[i,j] = 
                }
            }
        }
    }
}
