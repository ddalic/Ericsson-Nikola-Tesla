using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ericsson.DAL.DataAccess
{
    public class cs : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public cs() : base("name=cs")
        {
        }

        public System.Data.Entity.DbSet<ericsson.Models.Ucenik> Ucenik { get; set; }
        public System.Data.Entity.DbSet<ericsson.Models.Ocjena> Ocjena { get; set; }
        public System.Data.Entity.DbSet<ericsson.Models.Predmet> Predmet { get; set; }
        public System.Data.Entity.DbSet<ericsson.Models.Imenik> Imenik { get; set; }

        //singular form
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
