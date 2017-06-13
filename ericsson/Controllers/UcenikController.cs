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
    public class UcenikController : Controller
    {
        private cs db = new cs();

        // GET: Ucenik
        public ActionResult Index()
        {
            return View(db.Ucenik.ToList());
        }

        // GET: Ucenik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ucenik ucenik = db.Ucenik.Find(id);
            if (ucenik == null)
            {
                return HttpNotFound();
            }
            return View(ucenik);
        }

        // GET: Ucenik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ucenik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,DatumRodenja,Adresa,ImeRoditelja")] Ucenik ucenik)
        {
            if (ModelState.IsValid)
            {
                db.Ucenik.Add(ucenik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ucenik);
        }

        // GET: Ucenik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ucenik ucenik = db.Ucenik.Find(id);
            if (ucenik == null)
            {
                return HttpNotFound();
            }
            return View(ucenik);
        }

        // POST: Ucenik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,DatumRodenja,Adresa,ImeRoditelja")] Ucenik ucenik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ucenik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ucenik);
        }

        // GET: Ucenik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ucenik ucenik = db.Ucenik.Find(id);
            if (ucenik == null)
            {
                return HttpNotFound();
            }
            return View(ucenik);
        }

        // POST: Ucenik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ucenik ucenik = db.Ucenik.Find(id);
            db.Ucenik.Remove(ucenik);
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
