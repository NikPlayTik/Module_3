using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_3
{
    public delegate double AreaDelegate();
    public abstract class Figure
    {
        public abstract double CalculatingArea();
    }
    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double CalculatingArea()
        {
            return Math.PI * Math.Pow(radius, 2); // формула вычисления площади круга
        }
    }
    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double CalculatingArea()
        {
            return width * height;
        }
    }
    public class Triangle : Figure
    {
        private double footing;
        private double height;

        public Triangle(double footing, double height)
        {
            this.footing = footing;
            this.height = height;
        }
        public override double CalculatingArea()
        {
            return 0.5 * footing * height;
        }
    }

    public class FigureOutput
    {
        public double radiusC;
        public double widthR;
        public double heightR;
        public double footingT;
        public double heightT;
        public void OutputData()
        {
            Console.Write("Введите радиус для круга: " +
                "\nВведите ширину и высоту прямоугольника: " +
                "\nВведите основание и высоту треугольника: ");
            radiusC = double.Parse(Console.ReadLine());
            widthR = double.Parse(Console.ReadLine());
            heightR = double.Parse(Console.ReadLine());
            footingT = double.Parse(Console.ReadLine());
            heightT = double.Parse(Console.ReadLine());
            Figure circle = new Circle(radiusC);
            Figure rectangle = new Rectangle(widthR, heightR);
            Figure triangle = new Triangle(footingT, heightT);

            AreaDelegate circleDelegate = new AreaDelegate(circle.CalculatingArea);
            AreaDelegate rectangleDelegate = new AreaDelegate(rectangle.CalculatingArea);
            AreaDelegate triangleDelegate = new AreaDelegate(triangle.CalculatingArea);

            Console.WriteLine($"Площадь круга: {circleDelegate}");
            Console.WriteLine($"Площадь прямоугольника: {rectangleDelegate}");
            Console.WriteLine($"Площадь треугольника: {triangleDelegate}");
            Console.ReadLine();
        }
    }

    
}
