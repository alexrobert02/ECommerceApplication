﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ECommerceApplicationContext))]
    [Migration("20231107164435_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Manufacturer", b =>
                {
                    b.Property<Guid>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("OrderPaid")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("OrderPlaced")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("OrderId");

                    b.HasIndex("ShoppingCartId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ShoppingCartId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Review", b =>
                {
                    b.Property<Guid>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<string>("ReviewText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.ShoppingCart", b =>
                {
                    b.Property<Guid>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("ShoppingCartId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Order", b =>
                {
                    b.HasOne("ECommerceApplication.Domain.Entities.ShoppingCart", "ShoppingCart")
                        .WithMany()
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceApplication.Domain.Entities.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Payment", b =>
                {
                    b.HasOne("ECommerceApplication.Domain.Entities.Order", null)
                        .WithOne("Payment")
                        .HasForeignKey("ECommerceApplication.Domain.Entities.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Product", b =>
                {
                    b.HasOne("ECommerceApplication.Domain.Entities.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceApplication.Domain.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerceApplication.Domain.Entities.ShoppingCart", null)
                        .WithMany("Products")
                        .HasForeignKey("ShoppingCartId");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Review", b =>
                {
                    b.HasOne("ECommerceApplication.Domain.Entities.Product", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Order", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.Product", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.ShoppingCart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerceApplication.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
