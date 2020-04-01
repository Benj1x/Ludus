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

        public ActionResult Index()
        {
            var model = simDB.getAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult StudentList()
        {
            var model = simDB.getAll();
            return View(model);
        }
        public ActionResult Students(Student student)
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