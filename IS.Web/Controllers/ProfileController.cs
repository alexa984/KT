
namespace IS.Web.Controllers
{
    using App_Start;
    using AutoMapper;
    using Data;
    using Data.Contracts;
    using Data.Models;
    using IS.Web.ViewModels.ProfileViewModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Mvc;
    using System.Web.Security;

    [Authorize]
    public class ProfileController : BaseController
    {
        private ApplicationUserManager _userManager;
        private readonly IMapper _mapper;

        public ProfileController(IISData data)
            :base(data)
        {
            _mapper = AutoMapperConfig.Execute();
        }

        public ProfileController(IISData data, ApplicationUserManager userManager)
            :base(data)
        {
            UserManager = userManager;
            _mapper = AutoMapperConfig.Execute();
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
        // GET: Profile/Index
        [Authorize]
        public ActionResult Index()
        {
            var currentUser = UserManager.FindById(UserProfileId);            
            var model = _mapper.Map<ISUser, ProfileViewModel>(currentUser);
            return View(model);
        }

        // GET: Profile/Edit/
        [Authorize(Roles="User")]
        public ActionResult Edit()
        {
            var currentUser = UserManager.FindById(UserProfileId);
            var model = _mapper.Map<ISUser, ProfileViewModel>(currentUser);
            return View(model);
        }

        // POST: Profile/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                EditProfile(model);
                return View("Success");
            }
            else
            {
                return View(model);
            }
        }
        

        // GET: Profile/Delete/
        [Authorize(Roles="User")]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ProfileViewModel model)
        {
            ClearCookie();
            var context = ISDbContext.Create();
            ConfigureViewModel(model);
            var id = model.Id;
            if(!ModelState.IsValid)
            {
                return View("Error");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            var logins = user.Logins;
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
                        var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
                    }
                }
                await UserManager.DeleteAsync(user);
                UserManager.Dispose();
                transaction.Commit();
                context.SaveChanges();
                return View("Welcome");
            }
        }


        private void ConfigureViewModel(ProfileViewModel model)
        {
            var context = ISDbContext.Create();
            GenericRepository<ISUser> userContext = new GenericRepository<ISUser>(context);
            var user = userContext.GetById(User.Identity.GetUserId());

            model.Id = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.Town = user.Town;
            model.Image = user.Image;
        }
        
        private void EditProfile(ProfileViewModel model)
        {
            var context = ISDbContext.Create();
            GenericRepository<ISUser> userContext = new GenericRepository<ISUser>(context);
            var user = userContext.GetById(User.Identity.GetUserId());

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.UserName = model.Email;
            user.Town = model.Town;
          

            byte[] imageData = null;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase userImage = Request.Files["profile"];
                if (userImage.ContentLength != 0)
                {
                    using (var binary = new BinaryReader(userImage.InputStream))
                    {
                        imageData = binary.ReadBytes(userImage.ContentLength);
                    }
                    user.Image = imageData;
                }
                model.Image = user.Image;
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
