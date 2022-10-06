using AssignmentFormValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentFormValidation.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(Form form)
        {
            if(ModelState.IsValid)
            {
                TempData["form"] = form;
                return RedirectToAction("Index");
            }
            return View(form);
        }

    }
}