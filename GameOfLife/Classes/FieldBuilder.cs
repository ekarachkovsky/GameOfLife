using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Classes
{
    public class FieldBuilder
    {
        private int height;
        private int width;

        private List<Tuple<int, int>> livePoints = new List<Tuple<int, int>>();

        public FieldBuilder AddLivePoint(int y, int x)
        {
            livePoints.Add(new Tuple<int, int>(y, x));
            return this;
        }

        public FieldBuilder(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        internal Field Build()
        {
            var points = new Point[height, width];
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    points[i, j] = new Point(livePoints.Any(x => x.Item1 == i && x.Item2 == j));
                    if (i > 0)
                    {
                        points[i, j].Neighbors[0] = points[i - 1, j];
                        points[i - 1, j].Neighbors[4] = points[i, j];
                        if (j > 0)
                        {
                            points[i, j].Neighbors[7] = points[i - 1, j - 1];
                            points[i - 1, j - 1].Neighbors[3] = points[i, j];
                        }
                        if (j < width - 1)
                        {
                            points[i, j].Neighbors[1] = points[i - 1, j + 1];
                            points[i - 1, j + 1].Neighbors[5] = points[i, j];
                        }
                    }
                    if (j > 0)
                    {
                        points[i, j].Neighbors[6] = points[i, j - 1];
                        points[i, j - 1].Neighbors[2] = points[i, j];

                    }
                }
            }

            return new Field(points);
        }
    }
}
