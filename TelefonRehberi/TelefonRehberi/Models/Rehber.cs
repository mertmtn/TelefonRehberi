namespace TelefonRehberi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class Rehber : DbContext
    {
        
        public Rehber()
            : base("name=Rehber")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();        
        }


        public virtual DbSet<Personel> tbl_Personel { get; set; }
        public virtual DbSet<Departman> tbl_Departman { get; set; }
        public virtual DbSet<Login> tbl_Login { get; set; }
    }


}