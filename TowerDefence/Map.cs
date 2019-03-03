using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Map
    {
        int cellsize;
        int maxX;
        int maxY;
        //массив, где хранится проходимая/непроходимая ячейка
        bool[,] roadMap;

        private Map()
        {

        }
        public Map(bool[,] roadMap, int cellsize)
        {
            this.cellsize = cellsize;
            this.roadMap = roadMap;
            //GetLength возвращает кол-во элементов массива в заданом измерении
            maxX = roadMap.GetLength(0) - 1;
            maxY = roadMap.GetLength(1) - 1;
        }
        //возвращает true если кординаты точки входят в массив 
        private bool InMap(Point loc)
        {
            return loc.X >= 0 && loc.X <= maxX && loc.Y >= 0 && loc.Y <= maxY;
        }
        //списк сосоедей для точки 
        private List<Point> getNeighboors(Point loc)
        {
            List<Point> result = new List<Point>();
            Point left = new Point(loc.X - 1, loc.Y);
            if (InMap(left))
            {
                result.Add(left);
            }

            Point up = new Point(loc.X, loc.Y - 1);
            if (InMap(up))
            {
                result.Add(up);
            }
            Point right = new Point(loc.X + 1, loc.Y);
            if (InMap(right))
            {
                result.Add(right);
            }
            Point down = new Point(loc.X, loc.Y + 1);
            if (InMap(down))
            {
                result.Add(down);
            }
            return result;

        }
        private Queue<Point> GivemeTheWay(Point start, Point end)
        {
            bool finish = false;
            //номер текущего шага
            int stepindex = 0;
            //кол-во шагов от финиша до конкретной координаты
            int[,] stepnum = new int[roadMap.GetLength(0), roadMap.GetLength(1)];
            List<Point> currentsteps = new List<Point>();
            //добавление координаты финиша в текущие шаги
            currentsteps.Add(end);
            while (!finish)
            {
                //увеличение номера шага на 1
                stepindex++;
                //объявление нового списка
                List<Point> newcurrentsteps = new List<Point>();
                //для каждого текущего шага
                foreach (Point p in currentsteps)
                {
                    //если координата точки совпадает с координатой старта, то это финиш и цикл while заканчивается
                    if (p.Equals(start))
                    {
                        finish = true;
                        break;
                    }
                    //получение соседей текущего шага
                    List<Point> neighboors = getNeighboors(p);
                    //для каждого соседа
                    foreach (Point n in neighboors)
                    {
                        //если сосед проходим и через него ни разу не прошли
                        if (roadMap[n.X, n.Y] && (stepnum[n.X, n.Y] != 0))
                        {
                            //добавление точки в новые текущие шаги
                            newcurrentsteps.Add(n);
                            //номер шага на котором был найден сосед
                            stepnum[n.X, n.Y] = stepindex;
                        }
                    }
                }
                //заменяем текущие шаги на новые
                currentsteps = newcurrentsteps;
                
            }
            //очередь шагов от старта до финиша
            Queue<Point> way = new Queue<Point>();
            //координата текущего шага
            Point currentstep = start;
            finish = false;
            // № текущего шага
            int currentstepnum = stepnum[start.X, start.Y];

            while (!finish)
            {  
                currentstepnum--;
                List<Point> neighboors = getNeighboors(currentstep);
                foreach(Point p in neighboors)
                {
                    if (p.Equals(end))
                    {
                        finish = true;
                        way.Enqueue(p);
                            break;
                    }
                    //если сосед является следующем шагом
                    if (stepnum[p.X, p.Y] == currentstepnum)
                    {
                        currentstep = p;
                        way.Enqueue(p);
                        break;
                    }
                }

            }
            return way;
        }
        //получение координат точек пути
        public Queue<Point> CalculateWay(Point start, Point end)
        {
            Queue<Point> way = GivemeTheWay(start,end);
            Queue<Point> result = new Queue<Point>();
            while(way.Count >0)
            {
              Point temp = way.Dequeue();
                temp.X = temp.X * cellsize;
                temp.Y = temp.Y * cellsize;
                result.Enqueue(temp);
               
            }
            return result;
        }
    }
}
