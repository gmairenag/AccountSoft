using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    [Table("Anio_Fiscal")]
    public class Anio_Fiscal: Entidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Display(Name = "Año:")]
        public int id_anio_fiscal { get; set; }
        [StringLength(100)]
        public string descripcion { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public bool abierto { get; set; }
        public virtual ICollection<Periodo> Periodo { get; set; }
    }
}