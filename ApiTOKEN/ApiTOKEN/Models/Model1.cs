namespace ApiTOKEN.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.pass)
                .IsUnicode(false);
        }
    }
}
