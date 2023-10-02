using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp007
{
    internal class Point
    {
        private int _x;
        private int _y;

        public Point() { }
        public Point(int x,int y)
        {
            this._x = x;
            this._y = y;
        }

        public int x { get => _x; set
            {
                _x = value;
            } }
        public int y { get => _y;set{ _y = value; } }

        public static Point operator +(Point point_1,Point point_2)
        {
            Point point = new Point();
            point.x = point_1.x + point_2.x;
            point.y = point_1.y + point_2.y;
            return point;
        }
        public static Point operator -(Point point_1, Point point_2) 
            => new Point(point_1.x - point_2.x, point_1.y - point_2.y);

        public override string ToString()
        {
            return $"({x};{y})";
        }
        public void ShowData()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
