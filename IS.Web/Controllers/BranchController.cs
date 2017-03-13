
namespace IS.Web.Controllers
{
    using Data;
    using Data.Contracts;
    using IS.Web.ViewModels.BranchViewModels;
    using Microsoft.AspNet.Identity;
    using Models;
    using System.Net;
    using System.Web.Mvc;

    [Authorize(Roles ="Firm")]
    public class BranchController : Controller
    {
        private ISDbContext context = new ISDbContext();

        // GET: Branch
        public ActionResult Index()
        {
            return View();
        }

        // GET: Branch/AddBranch
        [HttpGet]
        public ActionResult AddBranch()
        {
            return View();
        }

        // POST: Branch/AddBranch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBranch(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                ConfigureViewModel(model, context);
                Branch branch = new Branch() { };
                branch.Town = model.Town;
                branch.Address = model.Address;
                branch.Firm = model.Firm;
                context.Branches.Add(branch);
                context.SaveChanges();
                return View("Success");
            }
            else
            {
                return View(model);
            }

        }

        // POST: Branch/DeleteBranch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBranch(int? id)
        {
            GenericRepository<Branch> branchContext = new GenericRepository<Branch>(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var branch = branchContext.GetById(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            context.Branches.Remove(branch);
            context.SaveChanges();
            return RedirectToAction("Index", "BusinessProfile");
        }

        private void ConfigureViewModel(BranchViewModel model, ISDbContext context)
        {
            GenericRepository<Business> firmContext = new GenericRepository<Business>(context);
            var firm = firmContext.GetById(User.Identity.GetUserId());
            model.Firm = firm;

        }
    }
}