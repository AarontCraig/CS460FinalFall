using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS460FallFinal.Models;
using CS460FallFinal.Models.ViewModels;
using System.Web.Helpers;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace CS460FallFinal.Controllers
{
    public class ITEMsController : Controller
    {
        private AuctionContext db = new AuctionContext();

        // GET: ITEMs
        [HttpGet]
        public ActionResult Index()
        {
            //var iTEMs = db.ITEMs.Include(i => i.SELLER1);
            Item_Bid_VM toReturn = new Item_Bid_VM
            {
                CurrentBids = db.BIDs.OrderByDescending(a => a.PRICE).ToList(),
                Items = db.ITEMs.ToList()
            };

            return View(toReturn);
        }

        
        public string UpdateBids()
        {
            JavaScriptSerializer formatter = new JavaScriptSerializer();

            var toReturn = db.BIDs.ToList(); //This doesn't seem to work

            var seriealizedResult = formatter.Serialize(toReturn);

            return (seriealizedResult);
            //return Json(formatter.Serialize(toReturn), JsonRequestBehavior.AllowGet);
        }

        // GET: ITEMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEMs.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            return View(iTEM);
        }

        // GET: ITEMs/Create
        public ActionResult Create()
        {
            ViewBag.SELLER = new SelectList(db.SELLERs, "ID", "NAME");
            return View();
        }

        // POST: ITEMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,DECRIPTION,SELLER")] ITEM iTEM)
        {
            if (ModelState.IsValid)
            {
                db.ITEMs.Add(iTEM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SELLER = new SelectList(db.SELLERs, "ID", "NAME", iTEM.SELLER);
            return View(iTEM);
        }

        // GET: ITEMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEMs.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            ViewBag.SELLER = new SelectList(db.SELLERs, "ID", "NAME", iTEM.SELLER);
            return View(iTEM);
        }

        // POST: ITEMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,DECRIPTION,SELLER")] ITEM iTEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SELLER = new SelectList(db.SELLERs, "ID", "NAME", iTEM.SELLER);
            return View(iTEM);
        }

        // GET: ITEMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEMs.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            return View(iTEM);
        }

        // POST: ITEMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEM iTEM = db.ITEMs.Find(id);
            db.ITEMs.Remove(iTEM);
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
