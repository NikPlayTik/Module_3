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

        public bool flagNegative;

        public FigureOutput()
        {
            flagNegative = true;
        }
        public void OutputData()
        {
            while (flagNegative)
            {
                Console.Write("Введите радиус для круга: ");
                if (double.TryParse(Console.ReadLine(), out radiusC))
                {      
                    if (radiusC < 0)
                    {
                        Console.WriteLine("Радиус должен быть положительным числом\n");
                        continue;
                    }                    
                }
                else
                {
                    Console.WriteLine("Радиус должен быть представлен в цифровом виде\n");
                    continue;
                }
                //!!!
                Console.Write("Введите ширину и высоту прямоугольника: ");
                if (!double.TryParse(Console.ReadLine(), out widthR) || widthR < 0 ||
                    !double.TryParse(Console.ReadLine(), out heightR) || heightR < 0)
                {
                    Console.WriteLine("Ширина и высота должны быть положительными числами. Пожалуйста, введите положительные числа.");
                    continue;
                }

                Console.Write("Введите основание и высоту треугольника: ");
                if (!double.TryParse(Console.ReadLine(), out footingT) || footingT < 0 ||
                    !double.TryParse(Console.ReadLine(), out heightT) || heightT < 0)
                {
                    Console.WriteLine("Основание и высота должны быть положительными числами. Пожалуйста, введите положительные числа.");
                    continue;
                }

                Figure circle = new Circle(radiusC); // реализация полиморфизма
                Figure rectangle = new Rectangle(widthR, heightR);
                Figure triangle = new Triangle(footingT, heightT);

                AreaDelegate circleDelegate = new AreaDelegate(circle.CalculatingArea);
                AreaDelegate rectangleDelegate = new AreaDelegate(rectangle.CalculatingArea);
                AreaDelegate triangleDelegate = new AreaDelegate(triangle.CalculatingArea);

                Console.WriteLine($"Площадь круга: {circleDelegate.Invoke():F2}");
                Console.WriteLine($"Площадь прямоугольника: {rectangleDelegate.Invoke():F2}");
                Console.WriteLine($"Площадь треугольника: {triangleDelegate.Invoke():F2}");
                Console.ReadLine();
                flagNegative = false;
            }
        }
    }
}
