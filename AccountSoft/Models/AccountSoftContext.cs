using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    public class AccountSoftContext : DbContext
    {
        public DbSet<Anio_Fiscal> Anio_Fiscal { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
        public DbSet<Tipo_Partida> Tipo_Partida { get; set; }
        public AccountSoftContext() 
            : base ("AccountSoftConectionString")
        {
        }


    }
}