﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SohaService.DataLayer.Context;

namespace SohaService.DataLayer.Migrations
{
    [DbContext(typeof(SohaServiceContext))]
    [Migration("20210905190518_mig_AddRepair")]
    partial class mig_AddRepair
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SohaService.DataLayer.Entities.Company.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanyPhone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Customer.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CustomerFamily")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerMobile")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerUNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Expert.Expert", b =>
                {
                    b.Property<int>("ExpertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExpertFamily")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ExpertMobile")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("ExpertName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("ExpertId");

                    b.ToTable("Experts");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Orders.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("DamageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("DiscountTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoneDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstimatedAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EstimatedToSendExpertTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderChangeLevelDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderLevelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderSetDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReceivedAmount")
                        .HasColumnType("int");

                    b.Property<int>("RemainingAmount")
                        .HasColumnType("int");

                    b.Property<int>("TotalCost")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExpertId");

                    b.HasIndex("OrderLevelId");

                    b.HasIndex("UnitId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Orders.OrderLevel", b =>
                {
                    b.Property<int>("OrderLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderLevelTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderLevelId");

                    b.ToTable("OrderLevels");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Orders.SendToCompany", b =>
                {
                    b.Property<int>("SendToCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AssemblingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReturn")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSend")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SetDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("UnitStatusId")
                        .HasColumnType("int");

                    b.HasKey("SendToCompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.HasIndex("UnitId");

                    b.HasIndex("UnitStatusId");

                    b.ToTable("SendToCompanies");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Pay.Pay", b =>
                {
                    b.Property<int>("PayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PayId");

                    b.HasIndex("OrderId");

                    b.ToTable("Pay");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Permission.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentID")
                        .HasColumnType("int");

                    b.Property<string>("PermissionTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("PermissionId");

                    b.HasIndex("ParentID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Permission.RolePermission", b =>
                {
                    b.Property<int>("RP_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RP_Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Repair.Repair", b =>
                {
                    b.Property<int>("RepairId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("DamageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("DiscountTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoneDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstimatedAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EstimatedToSendUnitDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReady")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRepair")
                        .HasColumnType("bit");

                    b.Property<int>("ReceivedAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReceivedUnitDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RemainingAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("RepairDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SendUnitDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalCost")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("UnitStatusId")
                        .HasColumnType("int");

                    b.HasKey("RepairId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UnitId");

                    b.HasIndex("UnitStatusId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Today.ToDay", b =>
                {
                    b.Property<int>("ToDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ToDayTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ToDayId");

                    b.ToTable("ToDays");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Unit.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Unit.UnitStatus", b =>
                {
                    b.Property<int>("UnitStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("UnitStatusTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UnitStatusId");

                    b.ToTable("UnitStatus");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.User.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAvatar")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.User.UserRole", b =>
                {
                    b.Property<int>("UR_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UR_ID");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Orders.Order", b =>
                {
                    b.HasOne("SohaService.DataLayer.Entities.Customer.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.Expert.Expert", "Expert")
                        .WithMany("Orders")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.Orders.OrderLevel", "OrderLevel")
                        .WithMany("Orders")
                        .HasForeignKey("OrderLevelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.Unit.Unit", "Unit")
                        .WithMany("Orders")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Expert");

                    b.Navigation("OrderLevel");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Orders.SendToCompany", b =>
                {
                    b.HasOne("SohaService.DataLayer.Entities.Company.Company", "Company")
                        .WithMany("SendToCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.Orders.Order", "Order")
                        .WithOne("SendToCompany")
                        .HasForeignKey("SohaService.DataLayer.Entities.Orders.SendToCompany", "OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.Unit.Unit", "Unit")
                        .WithMany("SendToCompanies")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.Unit.UnitStatus", "UnitStatus")
                        .WithMany("SendToCompanies")
                        .HasForeignKey("UnitStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Order");

                    b.Navigation("Unit");

                    b.Navigation("UnitStatus");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Pay.Pay", b =>
                {
                    b.HasOne("SohaService.DataLayer.Entities.Orders.Order", "Order")
                        .WithMany("Pays")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Permission.Permission", b =>
                {
                    b.HasOne("SohaService.DataLayer.Entities.Permission.Permission", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Permission.RolePermission", b =>
                {
                    b.HasOne("SohaService.DataLayer.Entities.Permission.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.User.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Repair.Repair", b =>
                {
                    b.HasOne("SohaService.DataLayer.Entities.Company.Company", "Company")
                        .WithMany("Repairs")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.Customer.Customer", "Customer")
                        .WithMany("Repairs")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.Unit.Unit", "Unit")
                        .WithMany("Repairs")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.Unit.UnitStatus", "UnitStatus")
                        .WithMany("Repairs")
                        .HasForeignKey("UnitStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Customer");

                    b.Navigation("Unit");

                    b.Navigation("UnitStatus");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.User.UserRole", b =>
                {
                    b.HasOne("SohaService.DataLayer.Entities.User.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SohaService.DataLayer.Entities.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Company.Company", b =>
                {
                    b.Navigation("Repairs");

                    b.Navigation("SendToCompanies");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Customer.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Expert.Expert", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Orders.Order", b =>
                {
                    b.Navigation("Pays");

                    b.Navigation("SendToCompany");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Orders.OrderLevel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Permission.Permission", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Unit.Unit", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Repairs");

                    b.Navigation("SendToCompanies");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.Unit.UnitStatus", b =>
                {
                    b.Navigation("Repairs");

                    b.Navigation("SendToCompanies");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.User.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("SohaService.DataLayer.Entities.User.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
