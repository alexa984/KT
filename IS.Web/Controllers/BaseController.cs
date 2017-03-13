
namespace IS.Web.Controllers
{
    using Data;
    using IS.Data.Contracts;
    using IS.Data.Models;
    using IS.Models;
    using Microsoft.AspNet.Identity;
    using System.Web.Mvc;
    using System.Web.Routing;

    [HandleError]
    public abstract class BaseController : Controller
    {
        // GET: Base
        //TODO: Implement basic functionality as access to repositories and db files

            
        protected IISData Data { get; private set; }
 
        protected string UserProfileId { get; private set; }

        public BaseController()
        {

        }
        public BaseController(IISData data)
        {
            this.Data = data;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (User.Identity.IsAuthenticated)
            {
                UserProfileId = User.Identity.GetUserId();
            }
            
        }

    }
}