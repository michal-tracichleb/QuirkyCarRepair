using Microsoft.EntityFrameworkCore;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL
{
    public class QuirkyCarRepairContext : DbContext
    {
        public QuirkyCarRepairContext()
        {
        }

        public QuirkyCarRepairContext(DbContextOptions<QuirkyCarRepairContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        #region CarService

        public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }

        #endregion CarService

        #region WarehouseManagement

        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<PartCategory> PartCategories { get; set; }
        public virtual DbSet<Margin> Margins { get; set; }

        #endregion WarehouseManagement

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Polish_100_CI_AI");

            #region CarService

            modelBuilder.Entity<ServiceOrder>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(64)
                    .IsRequired();
            });

            #endregion CarService

            #region WarehouseManagement

            modelBuilder.Entity<PartCategory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsRequired();

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentCategory_Subcategories");

                entity.HasMany(d => d.Parts)
                    .WithOne(p => p.PartCategory)
                    .HasForeignKey(p => p.PartCategoryId)
                    .HasConstraintName("FK_PartCategory_Part");
            });

            modelBuilder.Entity<Margin>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsRequired();

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                entity.HasMany(d => d.Parts)
                    .WithOne(p => p.Margin)
                    .HasForeignKey(p => p.MarginId)
                    .HasConstraintName("FK_Margin_Parts");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsRequired(false);

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                entity.Property(e => e.MinimumQuantity)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired(false);

                entity.Property(e => e.UnitType)
                    .HasMaxLength(64)
                    .IsRequired();

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();
            });

            #endregion WarehouseManagement
        }
    }
}