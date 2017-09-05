using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    [Table("Cta_Cat")]
    public class Cta_Cat
    {
        [Key]
        [StringLength(20)]
        public string id_cta { get; set; }
        [StringLength(100)]
        public string descripcion { get; set; }
        [StringLength(2)]
        public string nat_cta { get; set; }
        public bool acept_mov { get; set; }
        public bool activa { get; set; }
        public virtual ICollection<Det_Partida> Det_Partida { get; set; }
    }
}