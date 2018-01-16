namespace EntropiaWebAuc.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntropiaModelsDbContext : DbContext
    {
        public EntropiaModelsDbContext()
            : base("name=EntropiaModels")
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CustomItems> CustomItems { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<RoleOptions> RoleOptions { get; set; }
        public virtual DbSet<SelectedStandartItems> SelectedStandartItems { get; set; }
        public virtual DbSet<StandartItemCategories> StandartItemCategories { get; set; }
        public virtual DbSet<StandartItems> StandartItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasOptional(e => e.RoleOptions)
                .WithRequired(e => e.AspNetRoles)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.CustomItems)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.RecId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.SelectedStandartItems)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<CustomItems>()
                .Property(e => e.Price)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CustomItems>()
                .Property(e => e.Markup)
                .HasPrecision(6, 2);

            modelBuilder.Entity<CustomItems>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<SelectedStandartItems>()
                .Property(e => e.Markup)
                .HasPrecision(5, 2);

            modelBuilder.Entity<SelectedStandartItems>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<StandartItemCategories>()
                .HasMany(e => e.StandartItems)
                .WithOptional(e => e.StandartItemCategories)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<StandartItems>()
                .Property(e => e.Price)
                .HasPrecision(16, 2);

            modelBuilder.Entity<StandartItems>()
                .HasMany(e => e.SelectedStandartItems)
                .WithRequired(e => e.StandartItems)
                .HasForeignKey(e => e.ItemId)
                .WillCascadeOnDelete(false);
        }
    }
}
