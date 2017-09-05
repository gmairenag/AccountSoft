using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    public class Entidad
    {
        public string estado { get; set; }
        public string usuario_reg { get; set; }
        public string usuario_act { get; set; }
        public DateTime? fecha_reg { get; set; }
        public DateTime? fecha_act { get; set; }
    }
}