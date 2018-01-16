using System.Web.Http;

namespace MA.University.API.Controllers
{
    //Web API will generate the URL for the controller based on the naming convention. Will cut Controller from
    //the name.
    public class ConventionalRoutingController : ApiController
    {
        #region Methods
        //With verb in the name
        //GET /api/conventionalrouting
        public int Get()
        {
            return 100;
        }

        //With Verb attribute so we are not bound to name the method with a name containing the verb.
        //GET /api/conventionalrouting/{id}
        [HttpGet]
        public int ReadById(int id)
        {
            return 1;
        }
        #endregion
    }
}