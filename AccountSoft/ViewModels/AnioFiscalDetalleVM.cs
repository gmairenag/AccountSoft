using AccountSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountSoft.ViewModels
{
    public class AnioFiscalDetalleVM
    {
        public int id_anio_fiscal { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public bool abierto { get; set; }
        public List<Periodo> periodoList { get; set; }

    }
}