using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    [Table("Det_Partida")]
    public class Det_Partida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_correlativo { get; set; }
        [StringLength(20)]
        public string id_cuenta { get; set; }
        [StringLength(200)]
        public string concepto { get; set; }
        public bool cargo { get; set; }
        public decimal monto { get; set; }

        #region FOREINGKEYS
        [Display(Name = "Número Partida")]
        public int id_partida { get; set; }
        [ForeignKey("id_partida")]
        public virtual Enc_Partida enc_partida { get; set; }

        [Display(Name = "Número Cuenta")]
        [StringLength(20)]
        public string id_cta { get; set; }
        [ForeignKey("id_cta")]
        public virtual Cta_Cat cta_cat { get; set; }
        #endregion
    }
}