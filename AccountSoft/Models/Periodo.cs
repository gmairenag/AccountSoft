using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    [Table("Periodos")]
    public class Periodo : Entidad
    {
        public string c_empresa { get; set; }

        public int c_anio_fiscal { get; set; }

        public string c_periodo { get; set; }

        public DateTime f_inicio { get; set; }

        public DateTime f_fin { get; set; }

        public int b_periodo_abierto { get; set; }

        public char m_tipo_periodo {get; set;}

        public string c_usuario_creo { get; set; }

        public DateTime f_creado { get; set; }

        public string c_usuario_modifico { get; set; }

        public DateTime f_modificado { get; set; }
    }
}