using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Classes
{
    public class Drawer
    {
        internal void Draw(Field field)
        {
            Console.Clear();
            for (var i = 0; i < field.Height; i++)
            {
                for (var j = 0; j < field.Width; j++)
                {
                    Console.Write(field[i, j].IsAlive ? "X" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}
