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
        public ActionResult Index(int UcenikID = -1)
        {
            Ucenik ucenik;
            if (UcenikID == -1) ucenik = db.Ucenik.FirstOrDefault();
            else ucenik = db.Ucenik.Where(t => t.UcenikID == UcenikID).FirstOrDefault();

            if (ucenik == null) return RedirectToAction("Index", "Home");

            ucenik.Predmeti = db.Predmet.OrderBy(t => t.ImePredmeta).ToList();
            ucenik.Ocjene = db.Ocjena.Where(t => t.UcenikID == ucenik.UcenikID).ToList();

            ViewBag.UcenikList = db.Ucenik.ToDictionary(t => t.UcenikID, t => t.ImeIPrezime);
            ImenikViewModel model = new ImenikViewModel
            {
                Ucenik = ucenik,
                NextUcenikID = ucenik.UcenikID
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ImenikViewModel model)
        {
            Ucenik ucenik = db.Ucenik.Where(t => t.UcenikID == model.NextUcenikID).FirstOrDefault();
            if (ucenik == null) return RedirectToAction("Index", "Home");

            ucenik.Predmeti = db.Predmet.OrderBy(t => t.ImePredmeta).ToList();
            ucenik.Ocjene = db.Ocjena.Where(t => t.UcenikID == ucenik.UcenikID).ToList();

            ViewBag.UcenikList = db.Ucenik.ToDictionary(t => t.UcenikID, t => t.ImeIPrezime);
            ImenikViewModel newmodel = new ImenikViewModel
            {
                Ucenik = ucenik,
                NextUcenikID = ucenik.UcenikID
            };

            return View(newmodel);
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
