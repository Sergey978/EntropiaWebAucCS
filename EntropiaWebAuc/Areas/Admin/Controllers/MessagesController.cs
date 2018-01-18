using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Domain;
using EntropiaWebAuc.Areas.Default.Models;
using EntropiaWebAuc.Areas.Admin.ViewModel;

namespace EntropiaWebAuc.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class MessagesController : Controller
    {
        private EntropiaModelsDbContext db = new EntropiaModelsDbContext();

        // GET: Admin/Messages
        public ActionResult Index()
        {
            var messages = db.Messages.Include(m => m.AspNetUsers).OrderByDescending(m => m.Date);
            return View(messages.ToList());
        }
        // GET: Admin/Messages/Incoming
        public ActionResult Incoming()
        {
            String adminId;
            using (var Db = new ApplicationDbContext())
            {
                String adminRoleId = Db.Roles.FirstOrDefault(r => r.Name == "SuperAdmin").Id;
                adminId = Db.Users.FirstOrDefault(user => user.Roles.Select(r => r.RoleId).Contains(adminRoleId)).Id;
            }

            var messages = db.Messages.Where(u => u.RecId == adminId).Include(m => m.AspNetUsers).OrderByDescending(m => m.Date);
            return View(messages.ToList());
        }

        // GET: Admin/Messages/Outgoing
        public ActionResult Outgoing()
        {
            String adminId;
            using (var Db = new ApplicationDbContext())
            {
                String adminRoleId = Db.Roles.FirstOrDefault(r => r.Name == "SuperAdmin").Id;
                adminId = Db.Users.FirstOrDefault(user => user.Roles.Select(r => r.RoleId).Contains(adminRoleId)).Id;
            }

            var messages = db.Messages.Where(u => u.SenderId == adminId).Include(m => m.AspNetUsers).OrderByDescending(m => m.Date);
            return View(messages.ToList());
        }
        // GET: Admin/Messages/Details/5
        public ActionResult Details(long? id, bool isAdmin = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }

            if (isAdmin)
            {
                messages.Read = true;
                db.SaveChanges();

            }
            return View(messages);
        }

        // GET: Admin/Messages/Create
        public ActionResult Create()
        {
            ViewBag.RecId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Admin/Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SenderId,SenderEmail,SenderName,Date,RecId,Title,Text,Sent,Read")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecId = new SelectList(db.AspNetUsers, "Id", "Email", messages.RecId);
            return View(messages);
        }

        // GET: Admin/Messages/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecId = new SelectList(db.AspNetUsers, "Id", "Email", messages.RecId);
            return View(messages);
        }

        // POST: Admin/Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SenderId,SenderEmail,SenderName,Date,RecId,Title,Text,Sent,Read")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecId = new SelectList(db.AspNetUsers, "Id", "Email", messages.RecId);
            return View(messages);
        }

        // GET: Admin/Messages/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // POST: Admin/Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Messages messages = db.Messages.Find(id);
            db.Messages.Remove(messages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: Admin/Messages/MessagesAct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MessageAct(IList<MessageViewModel> messages, FormCollection form)
        {
            String action = Convert.ToString(form["actionId"]);
            bool test = messages[0].IsSelected;
            switch (action)
            {
                case "notRead":
                    {

                    }
                    break;
                case "remove":
                    {

                    }
                    break;
            }
                

            return RedirectToAction("Incoming");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
