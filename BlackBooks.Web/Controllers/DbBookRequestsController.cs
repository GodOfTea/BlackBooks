using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlackBooks.Web.Models;

namespace GoHome.Web.Controllers
{
    public class DbRideRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DbRideRequests
        public ActionResult Index()
        {
            return View(db.BookRequests.ToList());
        }

        // GET: DbRideRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbBookRequest dbRideRequest = db.BookRequests.Find(id);
            if (dbRideRequest == null)
            {
                return HttpNotFound();
            }
            return View(dbRideRequest);
        }

        // GET: DbRideRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DbRideRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Filled,FullName,Price,NonSmokingDriver,BabySeat")] DbBookRequest dbRideRequest)
        {
            if (ModelState.IsValid)
            {
                db.BookRequests.Add(dbRideRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dbRideRequest);
        }

        // GET: DbRideRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbBookRequest dbRideRequest = db.BookRequests.Find(id);
            if (dbRideRequest == null)
            {
                return HttpNotFound();
            }
            return View(dbRideRequest);
        }

        // POST: DbRideRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Filled,FullName,Price,NonSmokingDriver,BabySeat")] DbBookRequest dbRideRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dbRideRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dbRideRequest);
        }

        // GET: DbRideRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DbBookRequest dbRideRequest = db.BookRequests.Find(id);
            if (dbRideRequest == null)
            {
                return HttpNotFound();
            }
            return View(dbRideRequest);
        }

        // POST: DbRideRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DbBookRequest dbRideRequest = db.BookRequests.Find(id);
            dbRideRequest.BookDetails.Clear();
            db.BookRequests.Remove(dbRideRequest);
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
