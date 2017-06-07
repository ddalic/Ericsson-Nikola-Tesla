using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ericsson.Models;

namespace ericsson.DAL
{
    public class DataAccess
    {
        public class SkolskiImenik : DbContext
        {
            public SkolskiImenik() : base("hackintosh.master")
            {
            }

            public DbSet<Predmet> Predmeti { get; set; }
            public DbSet<Ucenik> Ucenici { get; set; }
            public DbSet<Ocjena> Ocjene { get; set; }
            public DbSet<Imenik> Imenik { get; set; }

            //singular form
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    }
}