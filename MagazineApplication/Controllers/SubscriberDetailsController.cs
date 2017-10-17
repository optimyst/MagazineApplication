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
    public class SubscriberDetailsController : Controller
    {
        private SubscriberContext db = new SubscriberContext();

        // GET: SubscriberDetails
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)

        {
            // this creates temorary sorting order (which will be default if null)
            ViewBag.CurrentSort = sortOrder;


            //check if searchstring null or not and if null then list via default (from id order) chronologically
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                //if searchString is null (nada) then set searchString to user's chosen filter (descending alpha order)
                searchString = currentFilter;
            }
            //THERE IS NO DATABASE

            //filetering the values of the database
            var Results = (IQueryable<subscriber>)db.Subscribers;

            //assign searchString to whatever the currentFilter is
            ViewBag.CurrentFilter = searchString;

            //whatever the user sets as CurrentFilter, then sort the table THIS IS THE SWITCH

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
            //return View9subscribers.ToList());
        }


        // GET: SubscriberDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriberDetail subscriberDetail = db.SubscriberDetails.Find(id);
            if (subscriberDetail == null)
            {
                return HttpNotFound();
            }
            return View(model: subscriberDetail);
        }

        // GET: SubscriberDetails/Create
        public ActionResult Create()
        {
            ViewBag.SubscriberDetailId = new SelectList(db.SubscriberDetails, "Id", "Notes");
            return View();
        }

        // POST: SubscriberDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Notes")] SubscriberDetail subscriberDetail)
        {
            if (ModelState.IsValid)
            {
                db.SubscriberDetails.Add(subscriberDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubscriberDetailId = new SelectList(db.SubscriberDetails, "Id", "Notes");
            return View(subscriberDetail);
        }

        // GET: SubscriberDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriberDetail subscriberDetail = db.SubscriberDetails.Find(id);
            if (subscriberDetail == null)
            {
                return HttpNotFound();
            }
            return View(subscriberDetail);
        }

        // POST: SubscriberDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Notes")] SubscriberDetail subscriberDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriberDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscriberDetail);
        }

        // GET: SubscriberDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubscriberDetail subscriberDetail = db.SubscriberDetails.Find(id);
            if (subscriberDetail == null)
            {
                return HttpNotFound();
            }
            return View(subscriberDetail);
        }

        // POST: SubscriberDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubscriberDetail subscriberDetail = db.SubscriberDetails.Find(id);
            db.SubscriberDetails.Remove(subscriberDetail);
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
