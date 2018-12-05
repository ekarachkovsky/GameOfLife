using GameOfLife.Classes;
using System;
using System.Linq;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var fieldBuilder = new FieldBuilder(50,80);
            fieldBuilder
                .AddLivePoint(10, 10)
                .AddLivePoint(10, 11)
                .AddLivePoint(10, 12)
                .AddLivePoint(9, 12)
                .AddLivePoint(8, 11);

            var field = fieldBuilder.Build();
            var drawer = new Drawer();

            while (true)
            {
                drawer.Draw(field);
                field.Recalc();
                field.NextTurn();
                Thread.Sleep(300);
            }
        }
    }
}
