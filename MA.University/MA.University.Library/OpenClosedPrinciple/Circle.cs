using System;

namespace MA.University.Library.OpenClosedPrinciple
{
    public class Circle: IShape
    {
        public int Radius
        {
            get;
            set;
        }

        public int Color
        {
            get;set;
        }

        public double ComputeArea()
        {
            return Math.Pow(Radius, 2) * Math.PI;
        }
    }
}
