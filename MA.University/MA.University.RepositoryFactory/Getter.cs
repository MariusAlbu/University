using MA.University.Repository.Core;
using MA.University.RepositoryAbstraction.Core;

namespace MA.University.RepositoryFactory
{
    public class Getter
    {
        public static IRepositoryContext GetRepository()
        {
            //Get data from config.
            bool isADONetRepositoryRequested = true;
            if (isADONetRepositoryRequested)
                return new RepositoryContext();

            return default(IRepositoryContext);
        }
    }
}
