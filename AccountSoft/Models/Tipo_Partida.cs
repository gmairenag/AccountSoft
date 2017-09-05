using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    [Table("Tipo_Partida")]
    public class Tipo_Partida
    {
        [Key]
        [StringLength(2)]
        public string id_tipo_partida { get; set; }
        [StringLength(100)]
        public string descripcion { get; set; }
        public virtual ICollection<Enc_Partida> Enc_Partida { get; set; }
    }
}