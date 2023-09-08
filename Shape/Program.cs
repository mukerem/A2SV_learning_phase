using System;

public abstract class Shape
{
    public string Name { get; set; }

    public virtual double CalculateArea()
    {
        return 0;
    }
}

public class Circle : Shape
{
    private double Radius { get; set; }

    public Circle(double radius)
    {
        Name = "Circle";
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    private double Width { get; set; }
    private double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Name = "Rectangle";
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Triangle : Shape
{
    private double Base { get; set; }
    private double Height { get; set; }

    public Triangle(double baseLength, double height)
    {
        Name = "Triangle";
        Base = baseLength;
        Height = height;
    }

    public override double CalculateArea()
    {
        return (Base * Height) / 2;
    }
}

public class Program
{
    public static void PrintShapeArea(Shape shape)
    {
        Console.WriteLine($"{shape.Name} Area: {shape.CalculateArea()}");
    }

    static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Rectangle rectangle = new Rectangle(4, 6);
        Triangle triangle = new Triangle(3, 4);

        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
    }
}



