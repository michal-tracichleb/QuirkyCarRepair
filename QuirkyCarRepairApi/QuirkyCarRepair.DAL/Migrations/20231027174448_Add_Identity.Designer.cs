﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuirkyCarRepair.DAL;

#nullable disable

namespace QuirkyCarRepair.DAL.Migrations
{
    [DbContext(typeof(QuirkyCarRepairContext))]
    [Migration("20231027174448_Add_Identity")]
    partial class Add_Identity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Polish_100_CI_AI")
                .HasAnnotation("ProductVersion", "8.0.0-rc.2.23480.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ServiceOrders");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("ServiceOrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderId");

                    b.HasIndex("UserId");

                    b.ToTable("ServiceOrderStatuses");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Model")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VIN")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoriesCompletedTotal")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Margin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Margins");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.OperationalDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("ServiceOrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderId");

                    b.HasIndex("UserId");

                    b.ToTable("OperationalDocuments");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int?>("MarginId")
                        .HasColumnType("int");

                    b.Property<decimal?>("MinimumQuantity")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("PartCategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("MarginId");

                    b.HasIndex("PartCategoryId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.PartCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("PartCategories");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.PartTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("MarginValue")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("OperationalDocumentId")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("OperationalDocumentId");

                    b.HasIndex("PartId");

                    b.ToTable("PartTransactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", "User")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_ServiceOrder_User");

                    b.HasOne("QuirkyCarRepair.DAL.Areas.CarService.Models.Vehicle", "Vehicle")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ServiceOrder_Vehicle");

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrderStatus", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", "ServiceOrder")
                        .WithMany("ServiceOrderStatuses")
                        .HasForeignKey("ServiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ServiceOrder_ServiceOrderStatus");

                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", "User")
                        .WithMany("ServiceOrderStatuses")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_ServiceOrderStatus_User");

                    b.Navigation("ServiceOrder");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.Vehicle", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Vehicle_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.OperationalDocument", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", "ServiceOrder")
                        .WithMany("OperationalDocuments")
                        .HasForeignKey("ServiceOrderId")
                        .HasConstraintName("FK_ServiceOrder_OperationalDocument");

                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.User", "User")
                        .WithMany("OperationalDocuments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_OperationalDocument_User");

                    b.Navigation("ServiceOrder");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Part", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Margin", "Margin")
                        .WithMany("Parts")
                        .HasForeignKey("MarginId")
                        .HasConstraintName("FK_Margin_Parts");

                    b.HasOne("QuirkyCarRepair.DAL.Areas.Warehouse.Models.PartCategory", "PartCategory")
                        .WithMany("Parts")
                        .HasForeignKey("PartCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PartCategory_Part");

                    b.Navigation("Margin");

                    b.Navigation("PartCategory");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.PartCategory", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Warehouse.Models.PartCategory", "ParentCategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentCategoryId")
                        .HasConstraintName("FK_ParentCategory_Subcategories");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.PartTransaction", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Warehouse.Models.OperationalDocument", "OperationalDocument")
                        .WithMany("PartTransactions")
                        .HasForeignKey("OperationalDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_OperationalDocument_PartTransaction");

                    b.HasOne("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Part", "Part")
                        .WithMany("PartTransactions")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Part_PartTransaction");

                    b.Navigation("OperationalDocument");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", b =>
                {
                    b.Navigation("OperationalDocuments");

                    b.Navigation("ServiceOrderStatuses");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.Vehicle", b =>
                {
                    b.Navigation("ServiceOrders");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Identity.User", b =>
                {
                    b.Navigation("OperationalDocuments");

                    b.Navigation("ServiceOrderStatuses");

                    b.Navigation("ServiceOrders");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Margin", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.OperationalDocument", b =>
                {
                    b.Navigation("PartTransactions");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Part", b =>
                {
                    b.Navigation("PartTransactions");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.PartCategory", b =>
                {
                    b.Navigation("Parts");

                    b.Navigation("Subcategories");
                });
#pragma warning restore 612, 618
        }
    }
}
