namespace MA.University.Library.OpenClosedPrinciple
{
    public class Square: IShape
    {
        public int SideLength
        {
            get;
            set;
        }

        public int Color
        {
            get; set;
        }

        public double ComputeArea()
        {
            return SideLength * SideLength;
        }
    }
}
