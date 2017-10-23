namespace InventoryEngine.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CAPA_INVContext : DbContext
    {
        public CAPA_INVContext()
            : base("name=CAPA_INVConn")
        {
        }

        public virtual DbSet<cat_TicketType> cat_TicketType { get; set; }
        public virtual DbSet<InventoryEvent> InventoryEvents { get; set; }
        public virtual DbSet<MOTagCount> MOTagCounts { get; set; }
        public virtual DbSet<MOTagHeader> MOTagHeaders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketCount> TicketCounts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MOTagCount>()
                .Property(e => e.UM)
                .IsFixedLength();

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.MOTagHeaders)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Identicon64)
                .IsUnicode(false);
        }
    }
}
