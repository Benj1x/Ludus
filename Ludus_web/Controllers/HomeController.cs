using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ludus.Service;
using Ludus_web.Models;

namespace Ludus_web.Controllers
{
    [Authorize(Users = "Admin")]
    public class HomeController : Controller
    {
        public SqlLudusData simDB;

        public HomeController(SqlLudusData simDB)
        {
            this.simDB = simDB;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = simDB.getAll();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        [HttpGet]
        public ActionResult StudentList()
        {
            var model = simDB.getAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult DeleteStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {
            if (ModelState.IsValid)
            {
                var model = simDB.getDetails(id);
                simDB.Remove(model);
                return RedirectToAction("Index", simDB.getAll());
            }

            return View();
        }
        
        [HttpGet]
        public ActionResult StudentDetails(int id)
        {
            var model = simDB.getDetails(id);
            if (model == null)
            {
                return View("Index");
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult EditStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                simDB.update(student);
                return RedirectToAction("EditStudent", new {id = student.Id});
            }

            return View();
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                simDB.Add(student);
                return RedirectToAction("StudentList", new {id = student.Id});
            }
            return View();
        }
    }
}