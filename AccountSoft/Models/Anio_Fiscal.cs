using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    [Table("Anio_Fiscal")]
    public class Anio_Fiscal: Entidad
    {
        public override string descripcion { get; set; }

        public DateTime fecha_inicio { get; set; }

        public DateTime fecha_fin { get; set; }

        public int abierto { get; set; }

    }
}