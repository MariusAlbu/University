using System;

namespace MA.University.Library.OpenClosedPrinciple
{
    public class TestOCP
    {
        public static void Test()
        {
            Circle circle = new Circle();
            circle.Radius = 5;

            Square square = new Square();
            square.SideLength = 7;

            ShapeComputer shaper = new ShapeComputer(circle);
            ShapeComputer shaper2 = new ShapeComputer(square);

            Console.WriteLine(shaper.GetMagicShapeNumber());
            Console.WriteLine(shaper.GetMagicShapeNumber());
        }
    }
}
