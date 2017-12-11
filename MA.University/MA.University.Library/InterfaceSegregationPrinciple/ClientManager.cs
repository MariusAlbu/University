using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.University.Library.InterfaceSegregationPrinciple
{
    public class ClientManager : IClientProcessor
    {
        public string GetClientName()
        {
            throw new NotImplementedException();
        }
    }
}
