using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger2023.DTO;
using ZeroHunger2023.EF;

namespace ZeroHunger2023.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        public ActionResult AdminProfile()
        {
            var db = new ZeroHunger2023Entities();
            var data = db.Admins.Find(Session["ID"]);
            return View(data);

        }

        //-------------------

        public EmployeeDTO ConvertToDTO(Employee employee)
        {
            var dto = new EmployeeDTO()
            {
                Name = employee.Name,
                DateOfBirth = employee.DateOfBirth, 
                Password = employee.Password,   
                Phone = employee.Phone
            };
            return dto;
        }

        public Employee ConvertFormToDTO(EmployeeDTO employee)
        {
            var dto = new Employee()
            {
                Name = employee.Name,
                DateOfBirth = employee.DateOfBirth,
                Password = employee.Password,
                Phone = employee.Phone
            };
            return dto;
        }


        public ActionResult EmployeeList()
        {
            var db = new ZeroHunger2023Entities();
            var data = db.Employees.ToList();
            return View(data);
        }

        [HttpGet]

        public ActionResult EmployeeAdd()
        {
            return View();
        }

        [HttpPost]

        public ActionResult EmployeeAdd(EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                Employee employee1 = ConvertFormToDTO(employee);
                var db = new ZeroHunger2023Entities();
                db.Employees.Add(employee1);
                db.SaveChanges();
                return RedirectToAction("EmployeeList");

            }
            return View();
            
        }

        [HttpGet]
        public ActionResult EmployeeEdit(int ID)
        {

            ZeroHunger2023Entities db = new ZeroHunger2023Entities();
            var data = db.Employees.Find(ID);
            return View(data);
        }

        [HttpPost]
        public ActionResult EmployeeEdit(Employee employee)
        {
            ZeroHunger2023Entities db = new ZeroHunger2023Entities();
            var data = db.Employees.Find(employee.ID);
            data.Name = employee.Name;
            data.Phone = employee.Phone;
            data.DateOfBirth = employee.DateOfBirth;
            data.Password = employee.Password;

            db.SaveChanges();
            return RedirectToAction("EmployeeList");

        }

        public ActionResult EmployeeDelete(int ID)
        {
            ZeroHunger2023Entities db = new ZeroHunger2023Entities();

            var data = db.Employees.Find(ID);
            db.Employees.Remove(data);
            db.SaveChanges();
            return RedirectToAction("EmployeeList");

        }


        //Restuarant


        public RestuarentDTO ConvertToDTO(Restaurant restaurant)
        {
            var dto = new RestuarentDTO()
            {
                Name = restaurant.Name,
                Address = restaurant.Address,
                Password = restaurant.Password,
                Phone = restaurant.Phone
                
            };
            return dto;
        }

        public Restaurant ConvertFormToDTO(RestuarentDTO restaurant)
        {
            var dto = new Restaurant()
            {
                Name = restaurant.Name,
                Address = restaurant.Address,
                Password = restaurant.Password,
                Phone = restaurant.Phone
            };
            return dto;
        }
        public ActionResult RestaurantList()
        {
            var db = new ZeroHunger2023Entities();
            var data = db.Restaurants.ToList();
            return View(data);
        }

        [HttpGet]

        public ActionResult RestaurantAdd()
        {
            return View();
        }

        [HttpPost]

        public ActionResult RestaurantAdd(RestuarentDTO restaurant)
        {
            if (ModelState.IsValid)
            {
                Restaurant restaurant1 = ConvertFormToDTO(restaurant);
                var db = new ZeroHunger2023Entities();
                db.Restaurants.Add(restaurant1);
                db.SaveChanges();
                return RedirectToAction("RestaurantList");
            }
            return View();
        }

        [HttpGet]
        public ActionResult RestaurantEdit(int ID)
        {

            ZeroHunger2023Entities db = new ZeroHunger2023Entities();
            var data = db.Restaurants.Find(ID);
            return View(data);
        }

        [HttpPost]
        public ActionResult RestaurantEdit(Restaurant restaurant)
        {
            ZeroHunger2023Entities db = new ZeroHunger2023Entities();
            var data = db.Restaurants.Find(restaurant.ID);
            data.Name = restaurant.Name;
            data.Phone = restaurant.Phone;
            data.Address = restaurant.Address;
            data.Password = restaurant.Password;

            db.SaveChanges();
            return RedirectToAction("RestaurantList");

        }

        public ActionResult RestaurantDelete(int ID)
        {
            ZeroHunger2023Entities db = new ZeroHunger2023Entities();

            var data = db.Restaurants.Find(ID);
            db.Restaurants.Remove(data);
            db.SaveChanges();
            return RedirectToAction("RestaurantList");

        }



        //Request


        public ActionResult RequestList()
        {

            var db = new ZeroHunger2023Entities();
            var data = db.TemRequests.ToList();
           
            return View(data);
        }
        
        public ActionResult AcceptedRequestList()
        {

            var db = new ZeroHunger2023Entities();
            var data = db.Requests.ToList();
           
            return View(data);
        }
        public ActionResult RejecetRequestList(int ID)
        {

            var db = new ZeroHunger2023Entities();
            var temp = db.TemRequests.Find(ID);
            db.TemRequests.Remove(temp);
            db.SaveChanges();

            return RedirectToAction("RequestList");
        }

        [HttpGet]
        public ActionResult RequestDetails(int ID)
        {

            var db = new ZeroHunger2023Entities();
            var data = db.TemRequests.Find(ID);
            var data1 = db.Employees.ToList();
            ViewBag.employee = data1;

            return View(data);
        }


        [HttpPost]
        public ActionResult RequestDetails(Request request)
        {
            request.Status = "Accepted";
           
            var db = new ZeroHunger2023Entities();
            db.Requests.Add(request);
            db.SaveChanges();

            return RedirectToAction("AcceptedRequestList");
        }


        public ActionResult Logout()
        {
            return RedirectToAction("Login", "Login");
        }












        [HttpGet]

        public ActionResult RequestAdd()
        {
            return View();
        }

        [HttpPost]

        public ActionResult RequestAdd(Request request)
        {
            var db = new ZeroHunger2023Entities();
            db.Requests.Add(request);
            db.SaveChanges();
            return RedirectToAction("RequestList");
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
            data.FoodQuantity= request.FoodQuantity;
            data.PreserveTime = request.PreserveTime;
            data.RestaurantID = request.RestaurantID;
            data.EmployeeID= request.EmployeeID;
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
    }
}