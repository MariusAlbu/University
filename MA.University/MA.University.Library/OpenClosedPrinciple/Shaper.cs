using System;

namespace MA.University.Library.OpenClosedPrinciple
{
    public class ShapeComputer
    {
        private IShape _shape;

        public ShapeComputer(IShape circle)
        {
            _shape = circle;
        }

        public double GetMagicShapeNumber()
        {
            Random rand = new Random();

            return _shape.ComputeArea() * rand.Next(1000);
        }
    }
}
