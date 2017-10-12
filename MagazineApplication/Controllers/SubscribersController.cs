using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagazineApplication.Models;
using PagedList;

namespace MagazineApplication.Controllers
{ 
    public class SubscribersController : Controller
    {
        private SubscriberContext db = new SubscriberContext();

        // GET: Subscribers
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            // this creates tempary sorting order (which will be default if it's null)
            ViewBag.CurrentSort = sortOrder;


            //check if the searchstring is null or not and if it's null then list via default (from the id order) chronological
            if (searchString != null)
            {
                page = 1;

            }
            else
            {
                //if the searchString is NULL (There is no value) then set searchstring to whatever filter the user sets up (decending alphabetical order)
                searchString = currentFilter;
            }

            //THERE IS NO DATABASE




            // filtering the values of the database
            var Results = (IQueryable<subscriber>)db.Subscribers;

            //assign searchString to whatever the currentFilter is
            ViewBag.CurrentFilter = searchString;

            //whatever the user sets as CurrentFilter, then sort the "table" of subscribers to whatever the user decides to sort as...
            switch (sortOrder)
            {
                case "Name":
                    Results = Results.OrderByDescending(x => x.Name);
                    break;
                case "Description":
                    Results = Results.OrderByDescending(x => x.Description);
                    break;
                case "Address":
                    Results = Results.OrderByDescending(x => x.Address);
                    break;
                case "Email":
                    Results = Results.OrderByDescending(x => x.Email);
                    break;
                    //Add the rest of the "coins"

                default:
                    Results = Results.OrderByDescending(x => x.Id);
                    break;
            }


            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(Results.ToPagedList(pageNumber, pageSize));

            //var subscribers = db.Subscribers.Include(s => s.SubscriberDetails);
            //return View(subscribers.ToList());
        }

        // GET: Subscribers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // GET: Subscribers/Create
        public ActionResult Create()
        {
            ViewBag.SubscriberDetailId = new SelectList(db.SubscriberDetails, "Id", "Notes");
            return View();
        }

        // POST: Subscribers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Address,Email,Phone,SubscriberDetailId")] subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                db.Subscribers.Add(subscriber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubscriberDetailId = new SelectList(db.SubscriberDetails, "Id", "Notes", subscriber.SubscriberDetailId);
            return View(subscriber);
        }

        // GET: Subscribers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubscriberDetailId = new SelectList(db.SubscriberDetails, "Id", "Notes", subscriber.SubscriberDetailId);
            return View(subscriber);
        }

        // POST: Subscribers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Address,Email,Phone,SubscriberDetailId")] subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubscriberDetailId = new SelectList(db.SubscriberDetails, "Id", "Notes", subscriber.SubscriberDetailId);
            return View(subscriber);
        }

        // GET: Subscribers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: Subscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subscriber subscriber = db.Subscribers.Find(id);
            db.Subscribers.Remove(subscriber);
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
