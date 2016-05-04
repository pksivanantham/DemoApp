using DemoApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Data
{
    public class DemoAppContext : DbContext, IDemoAppContext
    {
        public  DemoAppContext():base("DemoAppContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public new IDbSet<T> Set<T>() where T:class
        {
            return base.Set<T>();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<EquipmentTag>().ToTable("EquipmentTag");
            modelBuilder.Entity<Maintenance>().ToTable("Maintenance");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
