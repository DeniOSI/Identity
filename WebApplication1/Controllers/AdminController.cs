using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Infrastructure;
using WebApplication1.Models;
using System;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }
        public AppUserManager UserManager { get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateUser model)
        {
            if(ModelState.IsValid)
            {
                AppUser user = new AppUser() { UserName = model.Name, Email = model.Name };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFormResult(result);
                }
            }
            return View(model);
        }

        private void AddErrorsFormResult(IdentityResult result)
        {
            foreach (var value in result.Errors)
            {
                ModelState.AddModelError("", value);
            }
            
        }
    }
}