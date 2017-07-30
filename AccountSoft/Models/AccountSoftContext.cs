using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccountSoft.Models
{
    public class AccountSoftContext: DbContext
    {
        public AccountSoftContext() 
            : base ("AccountSoftConectionString")
        {
        }
    }
}