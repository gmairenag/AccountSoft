using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AccountSoft.Models
{
    public class AnioFiscal: Entidad
    {
        [Remote("IsAnioNameExist", "Validation", ErrorMessage = "Descripción de Año ya Existe", AdditionalFields = "")]
        public override string Nombre { get; set; }
    }
}