using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    public class AccountSoftContext: DbContext
    {
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<AnioFiscal> AnioFiscal { get; set; }

        public AccountSoftContext() 
            : base ("AccountSoftConectionString")
        {
        }


    }
}