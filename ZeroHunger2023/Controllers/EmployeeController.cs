using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger2023.EF;

namespace ZeroHunger2023.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        public ActionResult RequestList()
        {
            var db = new ZeroHunger2023Entities();
            var data = db.Employees.Find(Session["ID"]);
            return View(data);
          
        }


        [HttpGet]
        public ActionResult EmployeeRequestDetails(int ID)
        {

            var db = new ZeroHunger2023Entities();
            var data = db.Requests.Find(ID);
            
            return View(data);
        }


        [HttpPost]
        public ActionResult EmployeeRequestDetails(Request request)
        {
            var db = new ZeroHunger2023Entities();
            var data = db.Requests.Find(request.ID);
            data.Status = request.Status;
          
            db.SaveChanges();

            return RedirectToAction("RequestList");
        }


        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Profile()
        {
            var db = new ZeroHunger2023Entities();
            var data = db.Employees.Find(Session["ID"]);
            return View(data);

        }


    }
}