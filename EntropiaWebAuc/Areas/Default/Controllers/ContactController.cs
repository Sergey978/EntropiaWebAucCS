using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntropiaWebAuc.Areas.Default.Controllers
{
    public class ContactController : Controller
    {
        // GET: Default/Contact
        public ActionResult Index()
        {
            return View();
        }

     

        // POST: Default/Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
