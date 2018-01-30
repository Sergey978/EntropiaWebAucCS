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
using PagedList;

namespace EntropiaWebAuc.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class MessagesController : Controller
    {
        private EntropiaModelsDbContext db = new EntropiaModelsDbContext();

        // GET: Admin/Messages
        public ActionResult Index(string sortOrder, int? page)
        {

            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewBag.NameSortParam = sortOrder == "SenderName" ? "name_desc" : "SenderName";

            var messages = db.Messages.Include(m => m.AspNetUsers);
            
            switch (sortOrder)
            {

                case "date_desc":
                    messages = messages.OrderByDescending(m => m.Date);
                    break;
                case "SenderName":
                    messages = messages.OrderBy(m => m.SenderName);
                    break;

                case "name_desc":
                    messages = messages.OrderByDescending(m => m.SenderName);
                    break;


                default:
                    messages = messages.OrderBy(m => m.Date);
                    break;


            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(messages.ToPagedList(pageNumber, pageSize));
           
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

            var messages = db.Messages.Where(u => u.RecId == adminId)
                .Include(m => m.AspNetUsers)
                .Select(mvm => new MessagesViewModel() { Message = mvm, IsSelected = false }).
               OrderByDescending(m => m.Message.Date);
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
