using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger2023.DTO;
using ZeroHunger2023.EF;

namespace ZeroHunger2023.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant

        public RequestDTO ConvertToDTO(Request request)
        {
            var dto = new RequestDTO()
            {
                FoodName = request.FoodName,
                FoodQuantity = request.FoodQuantity,
                RestaurantID = request.RestaurantID,
                PreserveTime = request.PreserveTime,
                Status = request.Status

            };
            return dto;
        }

        public TemRequest ConvertFormToDTO(RequestDTO request)
        {
            var dto = new TemRequest()
            {
                FoodName = request.FoodName,
                FoodQuantity = request.FoodQuantity,
                RestaurantID = request.RestaurantID,
                PreserveTime = request.PreserveTime,
                Status = request.Status
            };
            return dto;
        }
        public ActionResult RestuarantProfile()
        {
            var db = new ZeroHunger2023Entities();
            var data = db.Restaurants.Find(Session["ID"]);
            return View(data);

        }

        [HttpGet]

        public ActionResult RequestAdd()
        {
            return View();
        }

        [HttpPost]

        public ActionResult RequestAdd(RequestDTO request)
        {
            if (ModelState.IsValid)
            {
                TemRequest request1 = ConvertFormToDTO(request);
                var db = new ZeroHunger2023Entities();
                db.TemRequests.Add(request1);
                db.SaveChanges();
                return RedirectToAction("RequestAdd");
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult RequestEdit(int ID)
        {

            ZeroHunger2023Entities db = new ZeroHunger2023Entities();
            var data = db.Restaurants.Find(ID);
            return View(data);
        }

        [HttpPost]
        public ActionResult RequestEdit(Request request)
        {
            ZeroHunger2023Entities db = new ZeroHunger2023Entities();
            var data = db.Requests.Find(request.ID);
            data.FoodName = request.FoodName;
            data.FoodQuantity = request.FoodQuantity;
            data.PreserveTime = request.PreserveTime;
            data.RestaurantID = request.RestaurantID;
            data.EmployeeID = request.EmployeeID;
            data.Status = request.Status;

            db.SaveChanges();
            return RedirectToAction("RestaurantList");

        }

        public ActionResult RequestDelete(int ID)
        {
            ZeroHunger2023Entities db = new ZeroHunger2023Entities();

            var data = db.Requests.Find(ID);
            db.Requests.Remove(data);
            db.SaveChanges();
            return RedirectToAction("RestaurantList");

        }

        public ActionResult ResturantRequestList()
        {
            var db = new ZeroHunger2023Entities();
            var data = db.Restaurants.Find(Session["ID"]);
            return View(data);
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Login");
        }


    }
}