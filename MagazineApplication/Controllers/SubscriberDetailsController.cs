using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagazineApplication.Models;

namespace MagazineApplication.Controllers
{
    public class SubscriberDetailsController : Controller
    {
        private SubscriberContext db = new SubscriberContext();

        // GET: SubscriberDetails
        public ActionResult Index()
        {
            return View(db.SubscriberDetails.ToList());
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
            return View(subscriberDetail);
        }

        // GET: SubscriberDetails/Create
        public ActionResult Create()
        {
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
