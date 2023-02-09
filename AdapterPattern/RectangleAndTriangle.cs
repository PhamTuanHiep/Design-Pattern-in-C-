using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    #region Interface
    public interface IRectangle
    {
        void AboutRectangle();
        double CalculateAreaOfRectangle();
    }
    public interface ITriangle
    {
        void AboutTriangle();
        double CalculateAreaOfTriangle();
    }
    #endregion
    #region Rect and Tria
    public class Rectangle:IRectangle
    {
        public double length;
        public double width;
        public Rectangle(double l, double w)
        {
            length = l;
            width = w;
        }
        public double CalculateAreaOfRectangle()
        {
            return length * width;
        }
        public void AboutRectangle()
        {
            Console.WriteLine("This is Rectangle");
        }
    }
    public class Triangle : ITriangle
    {
        public double hypotenues;
        public double height;
        public Triangle(double b, double h)
        {
            hypotenues = b;
            height = h;
        }
        public double CalculateAreaOfTriangle()
        {
            return 0.5 * hypotenues * height;
        }
        public void AboutTriangle()
        {
            Console.WriteLine("This is Triangle");
        }
    }
    #endregion
    public class TriangleAdapter : IRectangle
    {
        Triangle triangle;
        public TriangleAdapter(Triangle t)
        {
            this.triangle = t;
        }
        public double CalculateAreaOfRectangle()
        {
             return triangle.CalculateAreaOfTriangle();
        }
        public void AboutRectangle()
        {
           triangle.AboutTriangle();
        }
    }
    class Start
    {
        public static void Main()
        {
            Console.WriteLine("Adapter Design Pattern:");

            Rectangle r = new Rectangle(20, 10);
            Console.WriteLine("\n Area of Rectangle is {0} square unit", r.CalculateAreaOfRectangle());

            Triangle t = new Triangle(20,10);
            Console.WriteLine("\n Area of Triangle is {0} square unit \n", t.CalculateAreaOfTriangle());

            IRectangle adapter = new TriangleAdapter(t);
            Console.WriteLine(" Area of Triangle is {0} square unit", GetArea(adapter));
            double GetArea(IRectangle ir)
            {
                ir.AboutRectangle();
                return ir.CalculateAreaOfRectangle();
            }
            Console.ReadLine();
        }
    }
}
