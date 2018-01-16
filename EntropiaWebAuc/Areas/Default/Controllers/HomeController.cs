using EntropiaWebAuc.Areas.Default.Models;
using EntropiaWebAuc.Areas.Default.ViewModels;
using EntropiaWebAuc.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntropiaWebAuc.Areas.Default.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel contactMessage)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    String adminId;
                    using (var Db   = new ApplicationDbContext()){
                       String adminRoleId = Db.Roles.FirstOrDefault(r => r.Name == "SuperAdmin").Id;
                      adminId =  Db.Users.FirstOrDefault(user => user.Roles.Select(r => r.RoleId).Contains(adminRoleId)).Id;
                    }

                    using (var Db = new EntropiaModelsDbContext())
                    {

                        Messages newMessage =
                                               new Messages()
                                               {
                                                   SenderEmail = contactMessage.Email,
                                                   SenderName = contactMessage.Name,
                                                   RecId = adminId,
                                                   Date = DateTime.UtcNow,
                                                   Title = contactMessage.Title,
                                                   Text = contactMessage.Text,
                                                   Sent = false,
                                                   Read = false

                                               };

                        Db.Messages.Add(newMessage);
                        Db.SaveChanges();
                    }
                    ViewBag.SuccesMessage = "Message was sended!";

                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "An error has occurred!" + ex.Message;
                    //ViewBag.ErrorMessage = "An error has occurred!";
                    return View();
                }
            }
            return View(contactMessage);
        }
    }
}