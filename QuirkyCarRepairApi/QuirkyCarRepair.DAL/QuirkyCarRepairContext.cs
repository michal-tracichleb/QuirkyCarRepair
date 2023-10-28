using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuirkyCarRepair.DAL.Areas.CarService.Models;
using QuirkyCarRepair.DAL.Areas.Identity;
using QuirkyCarRepair.DAL.Areas.Warehouse.Models;

namespace QuirkyCarRepair.DAL
{
    public class QuirkyCarRepairContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public QuirkyCarRepairContext()
        {
        }

        public QuirkyCarRepairContext(DbContextOptions<QuirkyCarRepairContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<User> Users { get; set; }

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

        #endregion WarehouseManagement

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseCollation("Polish_100_CI_AI");

            #region Identity

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Id)
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int")
                      .HasColumnName("Id");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(entity.Property<int>("Id"), 1L, 1);

                entity.Property<int>("AccessFailedCount")
                    .HasColumnType("int");

                entity.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("nvarchar(max)");

                entity.Property<string>("Email")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                entity.Property<bool>("EmailConfirmed")
                    .HasColumnType("bit");

                entity.Property<bool>("LockoutEnabled")
                    .HasColumnType("bit");

                entity.Property<DateTimeOffset?>("LockoutEnd")
                    .HasColumnType("datetimeoffset");

                entity.Property<string>("NormalizedEmail")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                entity.Property<string>("NormalizedUserName")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                entity.Property<string>("PasswordHash")
                    .HasColumnType("nvarchar(max)");

                entity.Property<string>("PhoneNumber")
                    .HasColumnType("nvarchar(max)");

                entity.Property<bool>("PhoneNumberConfirmed")
                    .HasColumnType("bit");

                entity.Property<string>("SecurityStamp")
                    .HasColumnType("nvarchar(max)");

                entity.Property<bool>("TwoFactorEnabled")
                    .HasColumnType("bit");

                entity.Property<string>("UserName")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                entity.HasKey("Id");

                entity.HasIndex("NormalizedEmail")
                    .HasDatabaseName("EmailIndex");

                entity.HasIndex("NormalizedUserName")
                    .IsUnique()
                    .HasDatabaseName("UserNameIndex")
                    .HasFilter("[NormalizedUserName] IS NOT NULL");

                entity.ToTable("AspNetUsers", (string)null);
            });

            modelBuilder.Entity<IdentityRole<int>>(entity =>
            {
                entity.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(entity.Property<int>("Id"), 1L, 1);

                entity.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("nvarchar(max)");

                entity.Property<string>("Name")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                entity.Property<string>("NormalizedName")
                    .HasMaxLength(256)
                    .HasColumnType("nvarchar(256)");

                entity.HasKey("Id");

                entity.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasDatabaseName("RoleNameIndex")
                    .HasFilter("[NormalizedName] IS NOT NULL");

                entity.ToTable("AspNetRoles", (string)null);
            });

            modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(entity.Property<int>("Id"), 1L, 1);

                entity.Property<string>("ClaimType")
                    .HasColumnType("nvarchar(max)");

                entity.Property<string>("ClaimValue")
                    .HasColumnType("nvarchar(max)");

                entity.Property<int>("RoleId")
                    .HasColumnType("int");

                entity.HasKey("Id");

                entity.HasIndex("RoleId");

                entity.ToTable("AspNetRoleClaims", (string)null);

                entity.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(entity.Property<int>("Id"), 1L, 1);

                entity.Property<string>("ClaimType")
                    .HasColumnType("nvarchar(max)");

                entity.Property<string>("ClaimValue")
                    .HasColumnType("nvarchar(max)");

                entity.Property<int>("UserId")
                    .HasColumnType("int");

                entity.HasKey("Id");

                entity.HasIndex("UserId");

                entity.ToTable("AspNetUserClaims", (string)null);

                entity.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.Property<string>("LoginProvider")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                entity.Property<string>("ProviderKey")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                entity.Property<string>("ProviderDisplayName")
                    .HasColumnType("nvarchar(max)");

                entity.Property<int>("UserId")
                    .HasColumnType("int");

                entity.HasKey("LoginProvider", "ProviderKey");

                entity.HasIndex("UserId");

                entity.ToTable("AspNetUserLogins", (string)null);

                entity.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", null)
                     .WithMany()
                     .HasForeignKey("UserId")
                     .OnDelete(DeleteBehavior.Cascade)
                     .IsRequired();
            });

            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.Property<int>("UserId")
                    .HasColumnType("int");

                entity.Property<int>("RoleId")
                    .HasColumnType("int");

                entity.HasKey("UserId", "RoleId");

                entity.HasIndex("RoleId");

                entity.ToTable("AspNetUserRoles", (string)null);

                entity.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                entity.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.Property<int>("UserId")
                    .HasColumnType("int");

                entity.Property<string>("LoginProvider")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                entity.Property<string>("Name")
                    .HasMaxLength(128)
                    .HasColumnType("nvarchar(128)");

                entity.Property<string>("Value")
                    .HasColumnType("nvarchar(max)");

                entity.HasKey("UserId", "LoginProvider", "Name");

                entity.ToTable("AspNetUserTokens", (string)null);

                entity.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            #endregion Identity

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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ServiceOrders)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_ServiceOrder_User");
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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ServiceOrderStatuses)
                    .HasForeignKey(p => p.UserId)
                    .HasConstraintName("FK_ServiceOrderStatus_User");
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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(p => p.UserId)
                    .HasConstraintName("FK_Vehicle_User");
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

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OperationalDocuments)
                    .HasForeignKey(p => p.UserId)
                    .HasConstraintName("FK_OperationalDocument_User");
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

            #endregion WarehouseManagement
        }
    }
}