using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountSoft.Models;
using AccountSoft.ViewModels;

namespace AccountSoft.Controllers
{
    public class Anio_FiscalController : Controller
    {
        private AccountSoftContext db = new AccountSoftContext();


        public ActionResult AgregarPeriodo(int aniofiscal)
        {
            var PeriodoView = new AgregarPeriodoVM
            {
                id_anio_fiscal = aniofiscal,
            };

            return PartialView("AgregarPeriodo",PeriodoView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarPeriodo(AgregarPeriodoVM agregarPeriodo)
        {
            if (!ModelState.IsValid)
            {
                return View(agregarPeriodo);
            }

            var periodos = db.Periodo
                .Where(p => p.id_anio_fiscal == agregarPeriodo.id_anio_fiscal && p.id_periodo == agregarPeriodo.id_periodo)
                .FirstOrDefault();

            if (periodos != null)
            {
                ViewBag.Error = "El periodo ya existe.";
                return PartialView(agregarPeriodo);
            }

            periodos = new Periodo
            {
                id_anio_fiscal = agregarPeriodo.id_anio_fiscal,
                //id_periodo = agregarPeriodo.id_periodo,
                fecha_inicio = agregarPeriodo.fecha_inicio,
                fecha_fin = agregarPeriodo.fecha_fin,
                abierto = agregarPeriodo.abierto,
                tipo_periodo = agregarPeriodo.tipo_periodo,
            };

            db.Periodo.Add(periodos);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction(string.Format("Details/{0}", agregarPeriodo.id_anio_fiscal));
        }

        // GET: Anio_Fiscal
        public ActionResult Index()
        {
            return View(db.Anio_Fiscal.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anio_Fiscal anio_fiscal = db.Anio_Fiscal
                .Where(a =>a.id_anio_fiscal == id)
                .First();

            if (anio_fiscal == null)
            {
                return HttpNotFound();
            }

            var anioFiscalView = new AnioFiscalDetalleVM
            {
                id_anio_fiscal = anio_fiscal.id_anio_fiscal,
                descripcion = anio_fiscal.descripcion,
                fecha_inicio = anio_fiscal.fecha_inicio,
                fecha_fin = anio_fiscal.fecha_fin,
                abierto = anio_fiscal.abierto,
                periodoList = anio_fiscal.Periodo.ToList(),
            };

            return PartialView("details", anioFiscalView);
        }

        // GET: Anio_Fiscal/Create
        public ActionResult Create()
        {
            Anio_Fiscal anio_fiscal = new Anio_Fiscal();
            return PartialView("create", anio_fiscal);
        }

        // POST: Anio_Fiscal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Anio_Fiscal af)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
              .Select(x => new { x.Key, x.Value.Errors })
              .ToArray();
            if (ModelState.IsValid)
            {
                Anio_Fiscal anio_fiscal = new Anio_Fiscal();
                anio_fiscal.id_anio_fiscal = af.id_anio_fiscal;
                anio_fiscal.descripcion = af.descripcion;
                anio_fiscal.fecha_inicio = af.fecha_inicio;
                anio_fiscal.fecha_fin = af.fecha_fin;
                anio_fiscal.abierto = af.abierto;
                anio_fiscal.estado = "VIGENTE";
                db.Anio_Fiscal.Add(anio_fiscal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView("create",af);
        }

        // GET: Anio_Fiscal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anio_Fiscal anio_Fiscal = db.Anio_Fiscal.Find(id);
            if (anio_Fiscal == null)
            {
                return HttpNotFound();
            }
            return View(anio_Fiscal);
        }

        // POST: Anio_Fiscal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,fecha_inicio,fecha_fin,abierto,estado,usuario_reg,usuario_act,fecha_reg,fecha_act")] Anio_Fiscal anio_Fiscal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anio_Fiscal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anio_Fiscal);
        }

        // GET: Anio_Fiscal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anio_Fiscal anio_Fiscal = db.Anio_Fiscal.Find(id);
            if (anio_Fiscal == null)
            {
                return HttpNotFound();
            }
            return View(anio_Fiscal);
        }

        // POST: Anio_Fiscal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anio_Fiscal anio_Fiscal = db.Anio_Fiscal.Find(id);
            db.Anio_Fiscal.Remove(anio_Fiscal);
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
