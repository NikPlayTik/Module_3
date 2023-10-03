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

    public abstract class Rectangle : Figure
    {

    }
}
