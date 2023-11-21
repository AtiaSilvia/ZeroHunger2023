using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger2023.EF;

namespace ZeroHunger2023.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(int ID, string Password)
        {
            var db = new ZeroHunger2023Entities();
            var data = db.Admins.Find(ID);
            var data1 = db.Employees.Find(ID);
            var data2 = db.Restaurants.Find(ID);

            if(data != null &&  data.Password == Password )
            {
                Session["ID"] = ID;
                return RedirectToAction("EmployeeList","Admin");
                
            }

            if(data1 != null && data1.Password == Password )
            {
                Session["ID"] = ID;
                 return RedirectToAction("RequestList","Employee");
            }
            
            if(data2 != null && data2.Password == Password )
            {
                Session["ID"] = ID;
                 return RedirectToAction("RequestAdd","Restaurant");
            }



            return View();
        }


        
    }
}