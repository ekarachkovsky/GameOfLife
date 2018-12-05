using GameOfLife.Classes;
using NUnit.Framework;

namespace Tests
{
    public class PointTests
    {
        [Test]
        public void IsAlive_When3Neighbors_IsAlive()
        {
            var point = new Point();
            point.SetUpPoints(
                null,
                null,
                new Point(true),
                new Point(true),
                new Point(true),
                new Point(false),
                new Point(false),
                null
                );

            point.Recalc();
            point.NextTurn();
            Assert.IsTrue(point.IsAlive);
        }

        [Test]
        public void IsAlive_When2NeighborsAndIsAlive_IsAlive()
        {
            var point = new Point(true);
            point.SetUpPoints(
                null,
                null,
                new Point(true),
                new Point(true),
                new Point(false),
                new Point(false),
                new Point(false),
                null
                );

            point.Recalc();
            point.NextTurn();
            Assert.IsTrue(point.IsAlive);
        }

        [Test]
        public void IsAlive_When4Neighbors_IsDead()
        {
            var point = new Point(true);
            point.SetUpPoints(
                null,
                null,
                new Point(true),
                new Point(true),
                new Point(false),
                new Point(true),
                new Point(true),
                null
                );

            point.Recalc();
            point.NextTurn();
            Assert.IsFalse(point.IsAlive);
        }

        [Test]
        public void IsAlive_When1Neighbor_IsDead()
        {
            var point = new Point(true);
            point.SetUpPoints(
                null,
                null,
                new Point(false),
                new Point(false),
                new Point(false),
                new Point(true),
                new Point(false),
                null
                );

            point.Recalc();
            point.NextTurn();
            Assert.IsFalse(point.IsAlive);
        }
    }
}