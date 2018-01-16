using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntropiaWebAuc.Domain;

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

        // GET: Admin/Messages/Details/5
        public ActionResult Details(long? id)
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
