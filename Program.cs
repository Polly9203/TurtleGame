using System;
using Microsoft.SmallBasic.Library;

namespace TurtleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            Turtle.PenUp();

            var x = 200;
            var y = 200;
            var counter = 0;

            var eat = Shapes.AddEllipse(13, 13);
            Shapes.HideShape(eat);
            CreateFood(x, y);

            Random rand = new Random();

            bool exit = true;

            int speed = 5;

            while (exit)
            {
                if (counter >= 3 && counter % 3 == 0)
                {
                    speed = 10;
                }
                else
                {
                    speed = 5;
                }
                Turtle.Move(10);
                Turtle.Speed = speed;
                if (Turtle.X >= x - 5 && Turtle.X <= x + 10 && Turtle.Y >= y - 5 && Turtle.Y <= y + 10)
                {
                    Shapes.HideShape(eat);
                    counter++;
                    x = rand.Next(0, GraphicsWindow.Width);
                    y = rand.Next(0, GraphicsWindow.Height);
                    if (counter == 20)
                    {
                        exit = false;
                    }
                    if (counter >= 3 && counter % 3 == 0)
                    {
                        CreateMagicFood(x, y);
                    }
                    else
                    {
                        CreateFood(x, y);
                    }
                }
            }
        }

        private static void CreateFood(int x, int y)
        {
            GraphicsWindow.BrushColor = "Red";
            var eat = Shapes.AddEllipse(13, 13);
            Shapes.Move(eat, x, y);
        }
        private static void CreateMagicFood(int x, int y)
        {
            GraphicsWindow.BrushColor = "Blue";
            var eat = Shapes.AddEllipse(13, 13);
            Shapes.Move(eat, x, y);
        }

        private static void GraphicsWindow_KeyDown()
        {
            if (GraphicsWindow.LastKey == "Up")
            {
                Turtle.Angle = 0;
            }
            if (GraphicsWindow.LastKey == "Right")
            {
                Turtle.Angle = 90;
            }
            if (GraphicsWindow.LastKey == "Down")
            {
                Turtle.Angle = 180;
            }
            if (GraphicsWindow.LastKey == "Left")
            {
                Turtle.Angle = 270;
            }
        }
    }
}
