using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.University.Library.InterfaceSegregationPrinciple
{
    public class ShapeComputer : IShape
    {
        public int ComputeArea()
        {
            throw new NotImplementedException();
        }

        public int GetPerimeter()
        {
            throw new NotImplementedException();
        }
    }
}
