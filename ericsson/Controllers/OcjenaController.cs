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
    public class OcjenaController : Controller
    {
        private cs db = new cs();

        // GET: Ocjena
        public ActionResult Index()
        {
            var ocjene = db.Ocjena.ToList();
            for (int i = 0; i < ocjene.Count; i++)
            {
                var ucenikID = ocjene[i].UcenikID;
                var predmetID = ocjene[i].PredmetID;
                Ucenik ucenik = db.Ucenik.Where(t => t.UcenikID == ucenikID).Single();
                ocjene[i].ucenik = ucenik;
                Predmet predmet = db.Predmet.Where(t => t.PredmetID == predmetID).Single();
                ocjene[i].predmet = predmet;
            }
            return View(ocjene);
        }

        // GET: Ocjena/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocjena ocjena = db.Ocjena.Find(id);
            if (ocjena == null)
            {
                return HttpNotFound();
            }
            return View(ocjena);
        }

        // GET: Ocjena/Create
        public ActionResult Create()
        {
            ViewBag.PredmetList = db.Predmet.ToDictionary(t => t.PredmetID, t => t.ImePredmeta);
            ViewBag.UcenikList = db.Ucenik.ToDictionary(t => t.UcenikID, t => (t.Ime + " " + t.Prezime));
            return View();
        }

        // POST: Ocjena/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OcjenaID,Grade,datum,komentar,PredmetID,UcenikID")] Ocjena ocjena)
        {
            if (ocjena.IsValid())
            {
                db.Ocjena.Add(ocjena);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Pogreska"] = ocjena.ErrorMessage;
            }

            return View(ocjena);
        }

        // GET: Ocjena/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocjena ocjena = db.Ocjena.Find(id);
            if (ocjena == null)
            {
                return HttpNotFound();
            }
            return View(ocjena);
        }

        // POST: Ocjena/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OcjenaID,Grade,datum,komentar,PredmetID,UcenikID")] Ocjena ocjena)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocjena).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ocjena);
        }

        // GET: Ocjena/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ocjena ocjena = db.Ocjena.Find(id);
            var ucenikID = ocjena.UcenikID;
            var predmetID = ocjena.PredmetID;
            Ucenik ucenik = db.Ucenik.Where(t => t.UcenikID == ucenikID).Single();
            ocjena.ucenik = ucenik;
            Predmet predmet = db.Predmet.Where(t => t.PredmetID == predmetID).Single();
            ocjena.predmet = predmet;
            if (ocjena == null)
            {
                return HttpNotFound();
            }
            return View(ocjena);
        }

        // POST: Ocjena/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ocjena ocjena = db.Ocjena.Find(id);
            db.Ocjena.Remove(ocjena);
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
