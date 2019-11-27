using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SVEUCILISNA_KNJIZNICA.Models;

namespace SVEUCILISNA_KNJIZNICA.Controllers
{
    public class TransakcijaController : Controller
    {
        private Entities db = new Entities();

        // GET: Transakcija
        public ActionResult Index()
        {
            var transakcijas = db.Transakcijas.Include(t => t.BrojDokumenta).Include(t => t.Korisnik);
            return View(transakcijas.ToList());
        }

        // GET: Transakcija/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transakcija transakcija = db.Transakcijas.Find(id);
            if (transakcija == null)
            {
                return HttpNotFound();
            }
            return View(transakcija);
        }

        // GET: Transakcija/Create
        public ActionResult Create()
        {
            ViewBag.BrojDokumentaID = new SelectList(db.BrojDokumentas, "BrojDokumentaID", "NazivDokumenta");
            ViewBag.KorisnikID = new SelectList(db.Korisniks, "KorisnikID", "Ime");
            return View();
        }

        // POST: Transakcija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransakcijaID,BrojDokumentaID,DatumTransakcije,KorisnikID")] Transakcija transakcija)
        {
            if (ModelState.IsValid)
            {
                db.Transakcijas.Add(transakcija);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrojDokumentaID = new SelectList(db.BrojDokumentas, "BrojDokumentaID", "NazivDokumenta", transakcija.BrojDokumentaID);
            ViewBag.KorisnikID = new SelectList(db.Korisniks, "KorisnikID", "Ime", transakcija.KorisnikID);
            return View(transakcija);
        }

        // GET: Transakcija/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transakcija transakcija = db.Transakcijas.Find(id);
            if (transakcija == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrojDokumentaID = new SelectList(db.BrojDokumentas, "BrojDokumentaID", "NazivDokumenta", transakcija.BrojDokumentaID);
            ViewBag.KorisnikID = new SelectList(db.Korisniks, "KorisnikID", "Ime", transakcija.KorisnikID);
            return View(transakcija);
        }

        // POST: Transakcija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransakcijaID,BrojDokumentaID,DatumTransakcije,KorisnikID")] Transakcija transakcija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transakcija).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrojDokumentaID = new SelectList(db.BrojDokumentas, "BrojDokumentaID", "NazivDokumenta", transakcija.BrojDokumentaID);
            ViewBag.KorisnikID = new SelectList(db.Korisniks, "KorisnikID", "Ime", transakcija.KorisnikID);
            return View(transakcija);
        }

        // GET: Transakcija/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transakcija transakcija = db.Transakcijas.Find(id);
            if (transakcija == null)
            {
                return HttpNotFound();
            }
            return View(transakcija);
        }

        // POST: Transakcija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transakcija transakcija = db.Transakcijas.Find(id);
            db.Transakcijas.Remove(transakcija);
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
