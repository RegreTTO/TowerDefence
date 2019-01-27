using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Map
    {
        int maxX;
        int maxY;
        bool[,] roadMap;
        private Map()
        {

        }
        public Map(bool[,] roadMap)
        {
            this.roadMap = roadMap;
            maxX = roadMap.GetLength(0) - 1;
            maxY = roadMap.GetLength(1) - 1;
        }
        private List<Point> getNeighboors(Point loc)
        {

        }
        public Queue<Point> GivemeTheWay(Point start, Point end)
        {
            bool finish = false;
            int stepindex = 0;
            int[,] stepnum = new int[roadMap.GetLength(0), roadMap.GetLength(1)];
            List<Point> currentsteps = new List<Point>();

            currentsteps.Add(end);
            while (!finish)
            {
                stepindex++;
                List<Point> newcurrentsteps = new List<Point>();
                foreach (Point p in currentsteps)
                {
                    if(p.Equals(start))
                    {
                        finish = true;
                        break;
                    }
                    List<Point> neighboors = getNeighboors(p);
                    foreach (Point n in neighboors)
                    {
                        if (roadMap[n.X, n.Y] && (stepnum[n.X, n.Y] != 0))
                        {
                            newcurrentsteps.Add(n);
                            stepnum[n.X, n.Y] = stepindex;
                        }
                    }
                }
                currentsteps = newcurrentsteps;
               
            }
            Queue<Point> way = new Queue<Point>();
            Point currentstep = start;
            
            finish = false;
            //заполнить очередь шагов
            while(!finish)
            {
                int currentstepnum = stepnum[start.X, start.Y];
            }
        }
    }
}
