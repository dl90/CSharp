using System;

namespace week_05
{
    class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(Point newPoint)
        {
            if (newPoint == null)
            {
                // defensive programming
                throw new ArgumentNullException("point is null");
            }
            this.X = newPoint.X;
            this.Y = newPoint.Y;
        }
    }
}
