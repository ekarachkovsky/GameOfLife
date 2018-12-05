using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Classes
{
    public class Point
    {
        private bool isAlive;
        private Point[] _neighbors;
        private bool willBeAlive;
        private bool _recalculated;

        public Point(bool isAlive=false)
        {
            this.isAlive = isAlive;
            _neighbors = new Point[8];
        }

        public void SetUpPoints(
            Point top, 
            Point topRight, 
            Point right, 
            Point rightBottom, 
            Point bottom, 
            Point bottomLeft, 
            Point left, 
            Point leftTop)
        {
            _neighbors = new Point[8]
            {
                top, topRight, right, rightBottom, bottom, bottomLeft, left, leftTop
            };
        }

        public void Recalc()
        {
            var cnt = Neighbors.Where(x => x?.IsAlive==true).Count();
            willBeAlive = cnt == 3 || (cnt == 2 && isAlive);
            _recalculated = true;
        }

        public void NextTurn()
        {
            this.isAlive = willBeAlive;
            _recalculated = false;
        }

        public Point[] Neighbors { get { return _neighbors; } }

        public bool IsAlive { get {
                return isAlive;
            } }

        public bool Recalculated { get { return _recalculated; } }
    }
}
