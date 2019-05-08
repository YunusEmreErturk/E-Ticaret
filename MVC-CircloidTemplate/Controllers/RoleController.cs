using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_CircloidTemplate.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role

        public RoleController()
        {
            ViewBag.RoleSelected = "selected";
        }
        public ActionResult Index()
        {
            List<string> rolesList =  Roles.GetAllRoles().ToList();
            return View(rolesList);
        }


        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]


        public ActionResult AddRole(string RoleName)
        {
            Roles.CreateRole(RoleName);

            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult DeleteRole(string RoleName)
        {
            Roles.DeleteRole(RoleName);
            return RedirectToAction("Index");
        }


    }
}