using System;

namespace GameOfLife.Classes
{
    public class Field
    {
        private readonly Point[,] _points;

        public int Height { get { return _points.GetLength(0); } }
        public int Width { get { return _points.GetLength(1); } }

        public Point this[int y, int x]
        {
            get
            {
                return _points[y, x];
            }
        }

        public Field(Point[,] points)
        {
            _points = points;
        }
        
        public void Recalc()
        {
            _recalc(_points[0, 0]);
        }

        private void _recalc(Point point)
        {
            point.Recalc();

            if (point.Neighbors[2] != null && !point.Neighbors[2].Recalculated)
                _recalc(point.Neighbors[2]);

            if (point.Neighbors[4] != null && !point.Neighbors[4].Recalculated)
                _recalc(point.Neighbors[4]);
        }

        public void NextTurn()
        {
            _nextTurn(_points[0, 0]);
        }

        private void _nextTurn(Point point)
        {

            point.NextTurn();

            if (point.Neighbors[2] != null && point.Neighbors[2].Recalculated)
                _nextTurn(point.Neighbors[2]);

            if (point.Neighbors[4] != null && point.Neighbors[4].Recalculated)
                _nextTurn(point.Neighbors[4]);
        }

        public Point GetStartPoint()
        {
            return _points[0, 0];
        }
    }
}
