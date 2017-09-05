using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    [Table("Periodo")]
    public class Periodo: Entidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Display(Name = "Periodo:")]
        public int id_periodo { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public bool abierto { get; set; }
        public int tipo_periodo { get; set; }

        #region FOREINGKEYS
        [Display(Name = "Año Fiscal")]
        public int id_anio_fiscal { get; set; }

        [ForeignKey("id_anio_fiscal")]
        public virtual Anio_Fiscal Anio_Fiscal { get; set; }
        public virtual ICollection<Enc_Partida> enc_partida { get; set; }

        #endregion

    }
}