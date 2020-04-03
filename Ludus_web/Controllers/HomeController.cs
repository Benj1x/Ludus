using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ludus.Service;
using Ludus_web.Models;

namespace Ludus_web.Controllers
{
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
        public ActionResult Students(Student student)
        {
            if (ModelState.IsValid)
            {
                simDB.Add(student);
                return RedirectToAction("StudentList", new {id = student.Id});
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = simDB.getDetails(id);
            if (model == null)
            {
                return View("Not Found");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                simDB.update(student);
                return RedirectToAction("Edit", new {id = student.Id});
            }

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