﻿// <auto-generated />
using System;
using Almox.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Almox.Persistence.Migrations
{
    [DbContext(typeof(AlmoxContext))]
    [Migration("20250530124239_RefreshTokenMigration")]
    partial class RefreshTokenMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Almox.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(35)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Almox.Domain.Entities.Delivery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<DateTime>("ExpectedDate")
                        .HasColumnType("timestamptz")
                        .HasColumnName("expected_date");

                    b.Property<short>("Status")
                        .HasColumnType("smallint")
                        .HasColumnName("status");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasColumnType("varchar(35)")
                        .HasColumnName("supplier");

                    b.Property<string>("Tracking")
                        .IsRequired()
                        .HasColumnType("char(16)")
                        .HasColumnName("tracking");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("deliveries", (string)null);
                });

            modelBuilder.Entity("Almox.Domain.Entities.DeliveryItem", b =>
                {
                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_id");

                    b.Property<Guid>("DeliveryId")
                        .HasColumnType("uuid")
                        .HasColumnName("delivery_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<decimal>("SupplierPrice")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("supplier_price");

                    b.HasKey("ItemId", "DeliveryId");

                    b.HasIndex("DeliveryId");

                    b.ToTable("delivery_items", (string)null);
                });

            modelBuilder.Entity("Almox.Domain.Entities.DeliveryStatusUpdate", b =>
                {
                    b.Property<Guid>("DeliveryId")
                        .HasColumnType("uuid")
                        .HasColumnName("delivery_id");

                    b.Property<short>("Status")
                        .HasColumnType("smallint")
                        .HasColumnName("status");

                    b.Property<string>("Observations")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("observations");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("updated_by_id");

                    b.HasKey("DeliveryId", "Status");

                    b.ToTable("delivery_status_updates", (string)null);
                });

            modelBuilder.Entity("Almox.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("departments", (string)null);
                });

            modelBuilder.Entity("Almox.Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("items", (string)null);
                });

            modelBuilder.Entity("Almox.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<string>("Observations")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("observations");

                    b.Property<short>("Priority")
                        .HasColumnType("smallint")
                        .HasColumnName("priority");

                    b.Property<short>("Status")
                        .HasColumnType("smallint")
                        .HasColumnName("status");

                    b.Property<string>("Tracking")
                        .IsRequired()
                        .HasColumnType("char(16)")
                        .HasColumnName("tracking");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("Almox.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid")
                        .HasColumnName("item_id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("ItemId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_items", (string)null);
                });

            modelBuilder.Entity("Almox.Domain.Entities.OrderStatusUpdate", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<short>("Status")
                        .HasColumnType("smallint")
                        .HasColumnName("status");

                    b.Property<string>("Observations")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("observations");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UpdatedById")
                        .HasColumnType("uuid")
                        .HasColumnName("updated_by_id");

                    b.HasKey("OrderId", "Status");

                    b.ToTable("order_status_updates", (string)null);
                });

            modelBuilder.Entity("Almox.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("deleted_at");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid")
                        .HasColumnName("department_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("char(36)")
                        .HasColumnName("refresh_token");

                    b.Property<short>("Role")
                        .HasColumnType("smallint")
                        .HasColumnName("role");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamptz")
                        .HasColumnName("updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("item_categories", b =>
                {
                    b.Property<Guid>("item_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("category_id")
                        .HasColumnType("uuid");

                    b.HasKey("item_id", "category_id");

                    b.HasIndex("category_id");

                    b.ToTable("item_categories", (string)null);
                });

            modelBuilder.Entity("Almox.Domain.Entities.DeliveryItem", b =>
                {
                    b.HasOne("Almox.Domain.Entities.Delivery", null)
                        .WithMany("DeliveryItems")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Almox.Domain.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Almox.Domain.Entities.DeliveryStatusUpdate", b =>
                {
                    b.HasOne("Almox.Domain.Entities.Delivery", null)
                        .WithMany("StatusUpdates")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Almox.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("Almox.Domain.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Almox.Domain.Entities.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Almox.Domain.Entities.OrderStatusUpdate", b =>
                {
                    b.HasOne("Almox.Domain.Entities.Order", null)
                        .WithMany("StatusUpdates")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Almox.Domain.Entities.User", b =>
                {
                    b.HasOne("Almox.Domain.Entities.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("item_categories", b =>
                {
                    b.HasOne("Almox.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Almox.Domain.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("item_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Almox.Domain.Entities.Delivery", b =>
                {
                    b.Navigation("DeliveryItems");

                    b.Navigation("StatusUpdates");
                });

            modelBuilder.Entity("Almox.Domain.Entities.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Almox.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("StatusUpdates");
                });
#pragma warning restore 612, 618
        }
    }
}
