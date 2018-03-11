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
using EntropiaWebAuc.Areas.Default.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using PagedList;

namespace EntropiaWebAuc.Areas.Default.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private EntropiaModelsDbContext db = new EntropiaModelsDbContext();

       
        // GET: Default/Messages/Incoming
        public ActionResult Incoming(string sortOrder, int? page)
        {
            String userId;

            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.NameSortParam = sortOrder == "SenderName" ? "name_desc" : "SenderName";
            
            using (var Db = new ApplicationDbContext())
            {

               userId =  User.Identity.GetUserId();
            }

            var messages = db.Messages.Where(u => u.RecId == userId)
                .Include(m => m.AspNetUsers)
                .Select(mvm => new MessagesViewModel() { Message = mvm, IsSelected = false });

            switch (sortOrder)
            {

                case "Date":
                    messages = messages.OrderBy(m => m.Message.Date);
                    break;
                case "SenderName":
                    messages = messages.OrderBy(m => m.Message.SenderName);
                    break;

                case "name_desc":
                    messages = messages.OrderByDescending(m => m.Message.SenderName);
                    break;


                default:
                    messages = messages.OrderByDescending(m => m.Message.Date);
                    break;


            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(messages.ToPagedList(pageNumber, pageSize));
        }

        // GET: Default/Messages/Outgoing
        public ActionResult Outgoing(string sortOrder, int? page)
        {
            String userId;

            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.NameSortParam = sortOrder == "SenderName" ? "name_desc" : "SenderName";

            using (var Db = new ApplicationDbContext())
            {
                userId = User.Identity.GetUserId();
            }

            var messages = db.Messages.Where(u => u.SenderId == userId)
                .Include(m => m.AspNetUsers)
                .Select(mvm => new MessagesViewModel() { Message = mvm, IsSelected = false });

            switch (sortOrder)
            {

                case "Date":
                    messages = messages.OrderBy(m => m.Message.Date);
                    break;
                case "SenderName":
                    messages = messages.OrderBy(m => m.Message.SenderName);
                    break;

                case "name_desc":
                    messages = messages.OrderByDescending(m => m.Message.SenderName);
                    break;


                default:
                    messages = messages.OrderByDescending(m => m.Message.Date);
                    break;


            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(messages.ToPagedList(pageNumber, pageSize));
        }
        // GET: Default/Messages/Details/5
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
            
                messages.Read = true;
                db.SaveChanges();

            
            return View(messages);
        }

        // GET: Default/Messages/Create
        public ActionResult Create()
        {
            ViewBag.RecId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Default/Messages/Create
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

        // GET: Default/Messages/Edit/5
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

        // POST: Default/Messages/Edit/5
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

        // GET: Default/Messages/Delete/5
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

        // POST: Default/Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Messages messages = db.Messages.Find(id);
            db.Messages.Remove(messages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: Default/Messages/MessagesAct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MessageAct(List<MessagesViewModel> messages, FormCollection form)
        {
            String action = Convert.ToString(form["actionId"]);

            switch (action)
            {
                case "notRead":
                    {
                        //Select and change property "Read"
                        List<long> editMessagesId = messages.Where(m => m.IsSelected == true)
                            .Select(m => m.Message.Id).ToList();
                        try
                        {
                            var editMessages = db.Messages
                                                        .Where(m => editMessagesId.Contains(m.Id)).ToList();


                            editMessages.ForEach(m => m.Read = false);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }
                    break;
                case "remove":
                    {
                        List<long> removeMessagesId = messages.Where(m => m.IsSelected == true)
                            .Select(m => m.Message.Id).ToList();
                        try
                        {
                            var removeMessages = db.Messages
                                                        .Where(m => removeMessagesId.Contains(m.Id));


                            db.Messages.RemoveRange(removeMessages);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }


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
