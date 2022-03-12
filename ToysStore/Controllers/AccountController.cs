using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToysStore.Controllers;
using ToysStore.Models;

namespace ToysStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup(ToysStore.Models.UserTabel T)
        {
            return View(T);
        }

    
        public ActionResult SubmitData(ToysStore.Models.UserTabel T)
        {

            if (ModelState.IsValid)
            {
                ToysStore.Models.savedata sd = new Models.savedata();
                sd.insertuser(T);
                ViewBag.name = T.UserName;
                return View("SubmitData");
            }
            else
            {
                return View("Signup");
            }

           
        }

        public ActionResult login(ToysStore.Models.UserTabel li)
        {
            return View(li);

        }



        public ActionResult Loginsearch(ToysStore.Models.UserTabel li)
        {
            ToysStore.Models.Searchuser ss = new Models.Searchuser();
            string pass = ss.searchk(li);

            if (pass == li.Userpassword)
            {

                return View("loadlogin");

            }
            @ViewBag.data = "invalide user";
            return View("login");

        }
        public ActionResult loadlogin()
        {

            return View();
        }

    }


    
}