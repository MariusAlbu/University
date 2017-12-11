using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.University.Library.InterfaceSegregationPrinciple
{
    public interface IBigBadInterface
    {
        int ComputeArea();
        int GetPerimeter();
        string GetClientName();
        void ResetUserPassword();
    }
}
