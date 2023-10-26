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
    [Migration("20231025133756_NewTables_OperationalDocuments_PartTransactions")]
    partial class NewTables_OperationalDocuments_PartTransactions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Polish_100_CI_AI")
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("ServiceOrders");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("ServiceOrderStatuses");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.Property<string>("VIN")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Margin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Margins");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.OperationalDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("OperationalDocuments");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int?>("MarginId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("MinimumQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("PartCategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("MarginValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OperationalDocumentId")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OperationalDocumentId");

                    b.HasIndex("PartId");

                    b.ToTable("PartTransactions");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.CarService.Models.Vehicle", "Vehicle")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ServiceOrder_Vehicle");

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

                    b.Navigation("ServiceOrder");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.OperationalDocument", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", "ServiceOrder")
                        .WithMany("OperationalDocuments")
                        .HasForeignKey("ServiceOrderId")
                        .HasConstraintName("FK_ServiceOrder_OperationalDocument");

                    b.Navigation("ServiceOrder");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Part", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Warehouse.Models.Margin", "Margin")
                        .WithMany("Parts")
                        .HasForeignKey("MarginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
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
