namespace CS460FallFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AuctionContext : DbContext
    {
        public AuctionContext()
            : base("name=AuctionContext")
        {
        }

        public virtual DbSet<BID> BIDs { get; set; }
        public virtual DbSet<BUYER> BUYERs { get; set; }
        public virtual DbSet<ITEM> ITEMs { get; set; }
        public virtual DbSet<SELLER> SELLERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BUYER>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BUYER>()
                .HasMany(e => e.BIDs)
                .WithRequired(e => e.BUYER1)
                .HasForeignKey(e => e.BUYER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.DECRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.BIDs)
                .WithRequired(e => e.ITEM1)
                .HasForeignKey(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SELLER>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SELLER>()
                .HasMany(e => e.ITEMs)
                .WithRequired(e => e.SELLER1)
                .HasForeignKey(e => e.SELLER)
                .WillCascadeOnDelete(false);
        }
    }
}
