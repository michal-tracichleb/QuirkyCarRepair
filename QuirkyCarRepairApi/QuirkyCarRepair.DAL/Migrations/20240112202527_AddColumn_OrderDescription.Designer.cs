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
    [Migration("20240112202527_AddColumn_OrderDescription")]
    partial class AddColumn_OrderDescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Polish_100_CI_AI")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.MainCategoryService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MarginId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarginId");

                    b.ToTable("MainCategoriesServices");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MainCategoryServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MainCategoryServiceId");

                    b.ToTable("ServiceOffers");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateStartRepair")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderDescription")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("OrderOwnerId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderOwnerId")
                        .IsUnique();

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

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOrderId");

                    b.HasIndex("UserId");

                    b.ToTable("ServiceOrderStatuses");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("MarginValue")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ServiceOfferId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceOrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOfferId");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("ServiceTransactions");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Identity.Models.Role", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Identity.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailIsConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("FirstName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Shared.Models.Margin", b =>
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

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Shared.Models.OrderOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("OperationalDocumentId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int?>("ServiceOrderId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationalDocumentId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderOwners");
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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CountryOfOrigin")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal?>("Depth")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal?>("MinimumQuantity")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Model")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("PartCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("Width")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

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

                    b.Property<int?>("MarginId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarginId");

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

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.TransactionStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("OperationalDocumentid")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationalDocumentid");

                    b.HasIndex("UserId");

                    b.ToTable("TransactionStatuses");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.MainCategoryService", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Shared.Models.Margin", "Margin")
                        .WithMany("MainCategoriesServices")
                        .HasForeignKey("MarginId")
                        .HasConstraintName("FK_Margin_MainCategoriesServices");

                    b.Navigation("Margin");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOffer", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.CarService.Models.MainCategoryService", "MainCategoryService")
                        .WithMany("ServiceOffers")
                        .HasForeignKey("MainCategoryServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainCategoryService");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Shared.Models.OrderOwner", "OrderOwner")
                        .WithOne("ServiceOrder")
                        .HasForeignKey("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", "OrderOwnerId");

                    b.HasOne("QuirkyCarRepair.DAL.Areas.CarService.Models.Vehicle", "Vehicle")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ServiceOrder_Vehicle");

                    b.Navigation("OrderOwner");

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

                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.Models.User", "User")
                        .WithMany("ServiceOrderStatuses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_ServiceOrderStatuses");

                    b.Navigation("ServiceOrder");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceTransaction", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOffer", "ServiceOffer")
                        .WithMany("ServiceTransactions")
                        .HasForeignKey("ServiceOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ServiceOffer_ServiceTransactions");

                    b.HasOne("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", "ServiceOrder")
                        .WithMany("ServiceTransactions")
                        .HasForeignKey("ServiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ServiceOrder_ServiceTransactions");

                    b.Navigation("ServiceOffer");

                    b.Navigation("ServiceOrder");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.Vehicle", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.Models.User", "User")
                        .WithMany("Vehicles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_User_Vehicles");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Identity.Models.User", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_Role");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Shared.Models.OrderOwner", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Warehouse.Models.OperationalDocument", "OperationalDocument")
                        .WithMany()
                        .HasForeignKey("OperationalDocumentId");

                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.Models.User", "User")
                        .WithMany("OrderOwners")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_User_OrderOwners");

                    b.Navigation("OperationalDocument");

                    b.Navigation("User");
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
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Warehouse.Models.PartCategory", "PartCategory")
                        .WithMany("Parts")
                        .HasForeignKey("PartCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_PartCategory_Part");

                    b.Navigation("PartCategory");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.PartCategory", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Shared.Models.Margin", "Margin")
                        .WithMany("PartCategories")
                        .HasForeignKey("MarginId")
                        .HasConstraintName("FK_Margin_PartCategories");

                    b.HasOne("QuirkyCarRepair.DAL.Areas.Warehouse.Models.PartCategory", "ParentCategory")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentCategoryId")
                        .HasConstraintName("FK_ParentCategory_Subcategories");

                    b.Navigation("Margin");

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

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.TransactionStatus", b =>
                {
                    b.HasOne("QuirkyCarRepair.DAL.Areas.Warehouse.Models.OperationalDocument", "OperationalDocument")
                        .WithMany("TransactionStatuses")
                        .HasForeignKey("OperationalDocumentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_TransactionStatus_OperationalDocument");

                    b.HasOne("QuirkyCarRepair.DAL.Areas.Identity.Models.User", "User")
                        .WithMany("TransactionStatuses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_User_TransactionStatuses");

                    b.Navigation("OperationalDocument");

                    b.Navigation("User");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.MainCategoryService", b =>
                {
                    b.Navigation("ServiceOffers");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOffer", b =>
                {
                    b.Navigation("ServiceTransactions");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.ServiceOrder", b =>
                {
                    b.Navigation("OperationalDocuments");

                    b.Navigation("ServiceOrderStatuses");

                    b.Navigation("ServiceTransactions");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.CarService.Models.Vehicle", b =>
                {
                    b.Navigation("ServiceOrders");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Identity.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Identity.Models.User", b =>
                {
                    b.Navigation("OrderOwners");

                    b.Navigation("ServiceOrderStatuses");

                    b.Navigation("TransactionStatuses");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Shared.Models.Margin", b =>
                {
                    b.Navigation("MainCategoriesServices");

                    b.Navigation("PartCategories");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Shared.Models.OrderOwner", b =>
                {
                    b.Navigation("ServiceOrder");
                });

            modelBuilder.Entity("QuirkyCarRepair.DAL.Areas.Warehouse.Models.OperationalDocument", b =>
                {
                    b.Navigation("PartTransactions");

                    b.Navigation("TransactionStatuses");
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