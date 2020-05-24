
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ludus_web.Models;
using Ludus.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity;


namespace Ludus_web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        
    }
}
