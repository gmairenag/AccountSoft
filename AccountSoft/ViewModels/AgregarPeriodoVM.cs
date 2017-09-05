using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountSoft.ViewModels
{
    public class AgregarPeriodoVM
    {
        public int id_anio_fiscal { get; set; }
        public int id_periodo { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public bool abierto { get; set; }
        public int tipo_periodo { get; set; }
    }
}