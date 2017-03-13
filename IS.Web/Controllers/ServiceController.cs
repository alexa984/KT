

namespace IS.Web.Controllers
{
    using App_Start;
    using AutoMapper;
    using Data;
    using Data.Contracts;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using ViewModels.CommentViewModels;
    using ViewModels.ServiceViewModels;


    public class ServiceController : BaseController
    {
       
        private ISDbContext context = new ISDbContext();
        private readonly IMapper _mapper;

        public ServiceController(IISData data)
            :base(data)
        {
            _mapper = AutoMapperConfig.Execute();
        }

        // GET: Service/Index        
        public ActionResult Index(string searchString)
        {
            var services = from s in context.Services
                           select s;

            List<Service> servicesList = services.ToList();
            


            if (!string.IsNullOrEmpty(searchString))
            {
                servicesList = services.Where(s => s.Firm.FirmName.Contains(searchString) || s.Description.Contains(searchString))
                   .ToList();
            }
            return View(servicesList);
        }

        // GET: Service/AddService
        [HttpGet]
        [Authorize(Roles = "Firm")]
        public ActionResult AddService()
        {
            return View();
        }

        // POST: Service/AddService
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Firm")]
        public ActionResult AddService(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                ConfigureViewModel(model, context);
                Service service = new Service() { };
                service.Type = model.Type;
                service.Description = model.Description;
                service.Firm = model.Firm;
                context.Services.Add(service);
                context.SaveChanges();
                return View("Success");
            }
            else
            {
                return View(model);
            }

        }

        // POST: Service/DeleteService

        [Authorize(Roles = "Firm")]
        public ActionResult DeleteService(int? id)
        {
            GenericRepository<Service> serviceContext = new GenericRepository<Service>(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var service = serviceContext.GetById(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            context.Services.Remove(service);
            context.SaveChanges();
            return RedirectToAction("Index", "BusinessProfile");
        }

        // GET: Service/ViewService
        public ActionResult ViewService(int? id)
        {
            GenericRepository<Service> serviceContext = new GenericRepository<Service>(context);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var service = serviceContext.GetById(id);
            if (service == null)
            {
                return HttpNotFound();
            }

            ServiceViewModel model = new ServiceViewModel();
            model = _mapper.Map(service, model);
            return View(model);
        }       
    


        private void ConfigureViewModel(ServiceViewModel model, ISDbContext context)
        {
            GenericRepository<Business> firmContext = new GenericRepository<Business>(context);
            var firm = firmContext.GetById(User.Identity.GetUserId());
            model.Firm = firm;

        }
    }
}

// GET: Service
/* TODO:// Write the logic for visualising /Service/ tab in navigation.
 * It should contain functionality for sorting services, searching in services by service name, 
 * by firm name, by town of distribution.
 * It should also be possible to mark a service, to value a service.
 * After clicking on a particular service, the application should suggest you relative services below.
 */
