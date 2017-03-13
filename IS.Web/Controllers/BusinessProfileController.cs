
namespace IS.Web.Controllers
{
    using Data;
    using Data.Contracts;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Mvc;
    using System.Web.Security;
    using ViewModels.BusinessProfileViewModels;
    using Web;

    [Authorize]
    public class BusinessProfileController : Controller
    {
        private ApplicationUserManager _userManager;
        public BusinessProfileController()
        {

        }

        public BusinessProfileController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: BusinessProfile
        [Authorize]
        public ActionResult Index()
        {
            BusinessProfileViewModel model = new BusinessProfileViewModel();
            ConfigureViewModel(model);
            return View(model);
        }

        // GET: BusinessProfile/Edit/
        public ActionResult Edit()
        {
            BusinessProfileViewModel model = new BusinessProfileViewModel();

            ConfigureViewModel(model);

           
            var service = new Service { };
            model.Services.Add(service);
            return View(model);
        }


        // POST: BusinessProfile/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Firm")]
        public ActionResult Edit(BusinessProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                EditProfile(model);
                return RedirectToAction("Edit", new { model = model });
            }
            else
            {
                return View(model);
            }
        }
        

        public ActionResult Ready()
        {
            return View("Success");
        }

        // GET: BusinessProfile/Delete/

        [Authorize(Roles = "Firm")]
        public ActionResult Delete()
        {
            return View();
        }

        // POST: BusinessProfile/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(BusinessProfileViewModel model)
        {
            ClearCookie();
            var context = ISDbContext.Create();
            ConfigureViewModel(model);
            var id = model.Id;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var firm = await UserManager.FindByIdAsync(id);

            var logins = firm.Logins;
            var rolesForUser = await UserManager.GetRolesAsync(id);
            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var login in logins.ToList())
                {
                    await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                }

                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser.ToList())
                    {
                        var result = await UserManager.RemoveFromRoleAsync(firm.Id, item);
                    }
                }
                
                await UserManager.DeleteAsync(firm);
                UserManager.Dispose();
                transaction.Commit();
                context.SaveChanges();
                return View("Welcome");
            }
        }

        private void ConfigureViewModel(BusinessProfileViewModel model)
        {
            var context = ISDbContext.Create();
            GenericRepository<Business> firmContext = new GenericRepository<Business>(context);
            var firm = firmContext.GetById(User.Identity.GetUserId());

            model.Id = firm.Id;
            model.FirmName = firm.FirmName;
            model.Email = firm.Email;
            model.Bulstat = firm.Bulstat;
            model.Telephone = firm.Telephone;
            model.Branches = firm.Branches;
            model.AdditionalInfo = firm.AdditionalInfo;
            model.Services = firm.Services;
            model.Image = firm.Image;
        }

        private void EditProfile(BusinessProfileViewModel model)
        {
            var context = ISDbContext.Create();
            GenericRepository<Business> firmContext = new GenericRepository<Business>(context);
            var firm = firmContext.GetById(User.Identity.GetUserId());


            firm.FirmName = model.FirmName;
            firm.Email = model.Email;
            firm.UserName = model.Email;
            firm.Bulstat = model.Bulstat;
            firm.Telephone = model.Telephone;
            firm.Branches = model.Branches;
            firm.AdditionalInfo = model.AdditionalInfo;

            context.SaveChanges();

            byte[] imageData = null;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase firmImage = Request.Files["businessProfile"];
                if (firmImage.ContentLength != 0)
                {
                    using (var binary = new BinaryReader(firmImage.InputStream))
                    {
                        imageData = binary.ReadBytes(firmImage.ContentLength);
                    }
                    firm.Image = imageData;
                }
                model.Image = firm.Image;
            }
            context.SaveChanges();
        }
        
        private void ClearCookie()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie cookie2 = new HttpCookie(sessionStateSection.CookieName, "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
        }
    }
}
