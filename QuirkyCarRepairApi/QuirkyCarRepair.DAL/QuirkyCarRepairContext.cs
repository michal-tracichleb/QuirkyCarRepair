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

        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<ServiceOrderStatus> ServiceOrderStatuses { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        #endregion CarService

        #region WarehouseManagement

        public DbSet<Margin> Margins { get; set; }
        public DbSet<OperationalDocument> OperationalDocuments { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<PartCategory> PartCategories { get; set; }
        public DbSet<PartTransaction> PartTransactions { get; set; }
        public DbSet<TransactionStatus> TransactionStatuses { get; set; }

        #endregion WarehouseManagement

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseCollation("Polish_100_CI_AI");

            #region CarService

            modelBuilder.Entity<ServiceOrder>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(64)
                    .IsRequired();

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.ServiceOrders)
                    .HasForeignKey(p => p.VehicleId)
                    .HasConstraintName("FK_ServiceOrder_Vehicle");
            });

            modelBuilder.Entity<ServiceOrderStatus>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StartDate).IsRequired();

                entity.Property(e => e.Status)
                    .HasMaxLength(64)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsRequired(false);

                entity.HasOne(d => d.ServiceOrder)
                    .WithMany(p => p.ServiceOrderStatuses)
                    .HasForeignKey(p => p.ServiceOrderId)
                    .HasConstraintName("FK_ServiceOrder_ServiceOrderStatus");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.VIN)
                    .HasMaxLength(64)
                    .IsRequired(false);

                entity.Property(e => e.PlateNumber)
                    .HasMaxLength(64)
                    .IsRequired();

                entity.Property(e => e.Brand)
                    .HasMaxLength(64)
                    .IsRequired(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(64);

                entity.Property(e => e.Year)
                    .IsRequired(false);
            });

            #endregion CarService

            #region WarehouseManagement

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

            modelBuilder.Entity<OperationalDocument>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(64)
                    .IsRequired();

                entity.Property(e => e.TransactionDate)
                    .IsRequired();

                entity.Property(e => e.Type)
                    .HasMaxLength(64)
                    .IsRequired();

                entity.HasOne(d => d.ServiceOrder)
                    .WithMany(p => p.OperationalDocuments)
                    .HasForeignKey(d => d.ServiceOrderId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceOrder_OperationalDocument");
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

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(64)
                    .IsRequired(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(64)
                    .IsRequired(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(64)
                    .IsRequired(false);

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(64)
                    .IsRequired(false);

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired(false);

                entity.Property(e => e.Height)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired(false);

                entity.Property(e => e.Width)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired(false);

                entity.Property(e => e.Depth)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired(false);
            });

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

            modelBuilder.Entity<PartTransaction>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                entity.Property(e => e.MarginValue)
                    .HasColumnType("decimal(18, 2)")
                    .IsRequired();

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.PartTransactions)
                    .HasForeignKey(d => d.PartId)
                    .HasConstraintName("FK_Part_PartTransaction");

                entity.HasOne(d => d.OperationalDocument)
                    .WithMany(p => p.PartTransactions)
                    .HasForeignKey(d => d.OperationalDocumentId)
                    .HasConstraintName("FK_OperationalDocument_PartTransaction");
            });

            modelBuilder.Entity<TransactionStatus>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.StartDate).IsRequired();

                entity.Property(e => e.Status)
                    .HasMaxLength(64)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsRequired(false);

                entity.HasOne(d => d.OperationalDocument)
                    .WithMany(p => p.TransactionStatuses)
                    .HasForeignKey(p => p.OperationalDocumentid)
                    .HasConstraintName("FK_TransactionStatus_OperationalDocument");
            });

            #endregion WarehouseManagement
        }
    }
}