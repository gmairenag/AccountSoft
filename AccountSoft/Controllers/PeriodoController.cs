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
    public class PeriodoController : Controller
    {
        private AccountSoftContext db = new AccountSoftContext();

        // GET: Periodo
        public ActionResult Index()
        {
            return View(db.Periodos.ToList());
        }

        // GET: Periodo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        // GET: Periodo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Periodo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,c_empresa,c_anio_fiscal,c_periodo,f_inicio,f_fin,b_periodo_abierto,c_usuario_creo,f_creado,c_usuario_modifico,f_modificado,Nombre")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Periodos.Add(periodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(periodo);
        }

        // GET: Periodo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        // POST: Periodo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,c_empresa,c_anio_fiscal,c_periodo,f_inicio,f_fin,b_periodo_abierto,c_usuario_creo,f_creado,c_usuario_modifico,f_modificado,Nombre")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(periodo);
        }

        // GET: Periodo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periodo periodo = db.Periodos.Find(id);
            if (periodo == null)
            {
                return HttpNotFound();
            }
            return View(periodo);
        }

        // POST: Periodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Periodo periodo = db.Periodos.Find(id);
            db.Periodos.Remove(periodo);
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
