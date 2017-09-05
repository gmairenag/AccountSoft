using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    [Table("Enc_Partida")]
    public class Enc_Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_partida { get; set; }
        public DateTime fecha_partida { get; set; }
        [StringLength(200)]
        public string concepto { get; set; }
        [StringLength(50)]
        public string usuario_ingreso { get; set; }
        [StringLength(50)]
        public string usuario_autorizo { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_autorizo { get; set; }
        public bool cuadrada { get; set; }
        public bool autorizada { get; set; }

        #region FOREINGKEYS
        [Display(Name = "Año Fiscal")]
        public int id_anio_fiscal { get; set; }
        [ForeignKey("id_anio_fiscal")]
        public virtual Anio_Fiscal Anio_Fiscal { get; set; }

        [Display(Name = "Periodo")]
        public int id_periodo { get; set; }
        [ForeignKey("id_periodo")]
        public virtual Periodo Periodo { get; set; }

        [Display(Name = "Tipo Partida")]
        [StringLength(2)]
        public string id_tipo_partida { get; set; }
        [ForeignKey("id_tipo_partida")]
        public virtual Tipo_Partida tipo_partida { get; set; }

        public virtual ICollection<Det_Partida> det_partida { get; set; }

        #endregion


    }
}