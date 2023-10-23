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

        public virtual DbSet<PartCategory> PartCategories { get; set; }

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
                    .HasForeignKey(p => p.ParentCategoryId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParentCategory_Subcategories");
            });

            #endregion WarehouseManagement
        }
    }
}