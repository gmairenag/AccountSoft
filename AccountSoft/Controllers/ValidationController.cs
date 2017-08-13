using AccountSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountSoft.Controllers
{
     public class ValidationController : Controller
    {
        private AccountSoftContext db = new AccountSoftContext();
        [HttpGet]
        public JsonResult IsAnioNameExist(string Nombre)
        {

            bool isExist = db.AnioFiscal.Where(anio => anio.Nombre.ToLower().Equals(Nombre.ToLower())).FirstOrDefault() != null;
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
    }
}