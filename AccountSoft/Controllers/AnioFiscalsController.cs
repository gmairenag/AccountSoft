using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountSoft.Models;

namespace AccountSoft.Controllers
{
    public class AnioFiscalsController : Controller
    {
        private AccountSoftContext db = new AccountSoftContext();

        // GET: AnioFiscals
        public ActionResult Index()
        {
            return View(db.AnioFiscal.ToList());
        }

        // GET: AnioFiscals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnioFiscal anioFiscal = db.AnioFiscal.Find(id);
            if (anioFiscal == null)
            {
                return HttpNotFound();
            }
            return View(anioFiscal);
        }

        // GET: AnioFiscals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnioFiscals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] AnioFiscal anioFiscal)
        {
            if (ModelState.IsValid)
            {
                db.AnioFiscal.Add(anioFiscal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anioFiscal);
        }

        // GET: AnioFiscals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnioFiscal anioFiscal = db.AnioFiscal.Find(id);
            if (anioFiscal == null)
            {
                return HttpNotFound();
            }
            return View(anioFiscal);
        }

        // POST: AnioFiscals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] AnioFiscal anioFiscal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anioFiscal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anioFiscal);
        }

        // GET: AnioFiscals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnioFiscal anioFiscal = db.AnioFiscal.Find(id);
            if (anioFiscal == null)
            {
                return HttpNotFound();
            }
            return View(anioFiscal);
        }

        // POST: AnioFiscals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnioFiscal anioFiscal = db.AnioFiscal.Find(id);
            db.AnioFiscal.Remove(anioFiscal);
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
