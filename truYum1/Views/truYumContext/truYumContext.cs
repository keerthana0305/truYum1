using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using truYum1.Models;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace truYum1.Views.truYumContext
{
    public class truYumContext : DbContext
    {
        public truYumContext() : base("name=truYumconn")
        {

        }
        public DbSet<menu> menus
        {
            get;
            set;

        }
        public DbSet<cart> carts
        {
            get;
            set;

        }
    }
}