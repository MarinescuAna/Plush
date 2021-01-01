﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plush.DataAccessLayer.Repository;

namespace Plush.DataAccessLayer.Repository.Migrations
{
    [DbContext(typeof(PlushDbContext))]
    partial class PlushDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Basket", b =>
                {
                    b.Property<Guid>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BasketId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Category", b =>
                {
                    b.Property<Guid>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Delivery", b =>
                {
                    b.Property<Guid>("DeliveryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeliveryID");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Image", b =>
                {
                    b.Property<Guid>("ImageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageID");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Information", b =>
                {
                    b.Property<Guid>("InformationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("InformationID");

                    b.HasIndex("UserID");

                    b.ToTable("Informations");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BasketID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DeliveryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InformationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Payment")
                        .HasColumnType("int");

                    b.Property<int>("StatusOrder")
                        .HasColumnType("int");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("OrderID");

                    b.HasIndex("DeliveryID");

                    b.HasIndex("InformationID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Product", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PostDatetime")
                        .HasColumnType("datetime2");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid>("ProviderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ImageID");

                    b.HasIndex("ProviderID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Provider", b =>
                {
                    b.Property<Guid>("ProviderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContactData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProviderID");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.User", b =>
                {
                    b.Property<string>("UserEmailID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccessToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("AccessTokenExp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserEmailID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Wishlist", b =>
                {
                    b.Property<Guid>("WishlistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Datetime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("WishlistID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Basket", b =>
                {
                    b.HasOne("Plush.DataAccessLayer.Domain.Domain.Order", "Order")
                        .WithMany("Baskets")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plush.DataAccessLayer.Domain.Domain.Product", "Product")
                        .WithMany("Baskets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Information", b =>
                {
                    b.HasOne("Plush.DataAccessLayer.Domain.Domain.User", "User")
                        .WithMany("Informations")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Order", b =>
                {
                    b.HasOne("Plush.DataAccessLayer.Domain.Domain.Delivery", "Delivery")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plush.DataAccessLayer.Domain.Domain.Information", "Information")
                        .WithMany("Orders")
                        .HasForeignKey("InformationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Product", b =>
                {
                    b.HasOne("Plush.DataAccessLayer.Domain.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plush.DataAccessLayer.Domain.Domain.Image", "Image")
                        .WithMany("Products")
                        .HasForeignKey("ImageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plush.DataAccessLayer.Domain.Domain.Provider", "Provider")
                        .WithMany("Products")
                        .HasForeignKey("ProviderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Plush.DataAccessLayer.Domain.Domain.Wishlist", b =>
                {
                    b.HasOne("Plush.DataAccessLayer.Domain.Domain.Product", "Product")
                        .WithMany("Wishlists")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Plush.DataAccessLayer.Domain.Domain.User", "User")
                        .WithMany("Wishlists")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
