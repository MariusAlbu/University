using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.University.Library.InterfaceSegregationPrinciple
{
    public class BigComputer : IClientProcessor, IUserProcessor
    {
        public string GetClientName()
        {
            throw new NotImplementedException();
        }

        public void ResetUserPassword()
        {
            throw new NotImplementedException();
        }
    }
}
