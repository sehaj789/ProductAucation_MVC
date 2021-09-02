﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductAucation_MVC.Data;

namespace ProductAucation_MVC.Migrations
{
    [DbContext(typeof(ProductAucationDbContext))]
    partial class ProductAucationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("ProductAucation_MVC.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("ProductAucation_MVC.Models.Place_Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Place_a_Bid")
                        .HasColumnType("TEXT");

                    b.Property<int>("Productid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Your_Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Productid");

                    b.ToTable("Place_Bid");
                });

            modelBuilder.Entity("ProductAucation_MVC.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Field")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("ProductAucation_MVC.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Brandid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Playerid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Brandid");

                    b.HasIndex("Playerid");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ProductAucation_MVC.Models.Place_Bid", b =>
                {
                    b.HasOne("ProductAucation_MVC.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductAucation_MVC.Models.Product", b =>
                {
                    b.HasOne("ProductAucation_MVC.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("Brandid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductAucation_MVC.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("Playerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Player");
                });
#pragma warning restore 612, 618
        }
    }
}
