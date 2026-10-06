using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square("Blue", 5),
            new Rectangle("Red", 4, 6),
            new Circle("Green", 3)
        };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} shape area: {shape.GetArea():F2}");
        }
    }
}
