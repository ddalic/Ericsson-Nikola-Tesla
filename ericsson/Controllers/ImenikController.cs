using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ericsson.DAL.DataAccess;
using ericsson.Models;

namespace ericsson.Controllers
{
    public class ImenikController : Controller
    {
        private cs db = new cs();

        // GET: Imenik
        public ActionResult Index()
        {
            return View(db.Imenik.ToList());
        }

        // GET: Imenik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imenik imenik = db.Imenik.Find(id);
            if (imenik == null)
            {
                return HttpNotFound();
            }
            return View(imenik);
        }

        // GET: Imenik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Imenik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImenikID")] Imenik imenik)
        {
            if (ModelState.IsValid)
            {
                db.Imenik.Add(imenik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imenik);
        }

        // GET: Imenik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imenik imenik = db.Imenik.Find(id);
            if (imenik == null)
            {
                return HttpNotFound();
            }
            return View(imenik);
        }

        // POST: Imenik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImenikID")] Imenik imenik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imenik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imenik);
        }

        // GET: Imenik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imenik imenik = db.Imenik.Find(id);
            if (imenik == null)
            {
                return HttpNotFound();
            }
            return View(imenik);
        }

        // POST: Imenik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imenik imenik = db.Imenik.Find(id);
            db.Imenik.Remove(imenik);
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
