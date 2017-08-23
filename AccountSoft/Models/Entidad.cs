using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    public class Entidad
    {
        [Key]
        public int id { get; set; }
        public virtual string descripcion { get; set; }
        public string estado { get; set; }
        public string usuario_reg { get; set; }
        public string usuario_act { get; set; }
        public DateTime fecha_reg { get; set; }
        public DateTime fecha_act { get; set; }
    }
}