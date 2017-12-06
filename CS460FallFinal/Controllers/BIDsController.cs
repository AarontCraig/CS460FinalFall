using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS460FallFinal.Models;

namespace CS460FallFinal.Controllers
{
    public class BIDsController : Controller
    {
        private AuctionContext db = new AuctionContext();

        // GET: BIDs
        public ActionResult Index()
        {
            var bIDs = db.BIDs.Include(b => b.BUYER1).Include(b => b.ITEM1);
            return View(bIDs.ToList());
        }

        // GET: BIDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BID bID = db.BIDs.Find(id);
            if (bID == null)
            {
                return HttpNotFound();
            }
            return View(bID);
        }

        // GET: BIDs/Create
        public ActionResult Create()
        {
            ViewBag.BUYER = new SelectList(db.BUYERs, "ID", "NAME");
            ViewBag.ITEM = new SelectList(db.ITEMs, "ID", "NAME");
            return View();
        }

        // POST: BIDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ITEM,BUYER,PRICE")] BID bID)
        {
            bID.TIME = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second
                ); //Update the time when the user submits the bid

            if (ModelState.IsValid)
            {
                db.BIDs.Add(bID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BUYER = new SelectList(db.BUYERs, "ID", "NAME", bID.BUYER);
            ViewBag.ITEM = new SelectList(db.ITEMs, "ID", "NAME", bID.ITEM);
            return View(bID);
        }

        // GET: BIDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BID bID = db.BIDs.Find(id);
            if (bID == null)
            {
                return HttpNotFound();
            }
            ViewBag.BUYER = new SelectList(db.BUYERs, "ID", "NAME", bID.BUYER);
            ViewBag.ITEM = new SelectList(db.ITEMs, "ID", "NAME", bID.ITEM);
            return View(bID);
        }

        // POST: BIDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ITEM,BUYER,PRICE,TIME")] BID bID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BUYER = new SelectList(db.BUYERs, "ID", "NAME", bID.BUYER);
            ViewBag.ITEM = new SelectList(db.ITEMs, "ID", "NAME", bID.ITEM);
            return View(bID);
        }

        // GET: BIDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BID bID = db.BIDs.Find(id);
            if (bID == null)
            {
                return HttpNotFound();
            }
            return View(bID);
        }

        // POST: BIDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BID bID = db.BIDs.Find(id);
            db.BIDs.Remove(bID);
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
