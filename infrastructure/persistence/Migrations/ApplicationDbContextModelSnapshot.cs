﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetShop.ProductService.Infrastructure.Persistence.Content;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace netShop.ProductService.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("NetShop.ProductService.Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("brandName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("brand_name");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("NetShop.ProductService.Domain.Entities.BrandModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("brandId")
                        .HasColumnType("uuid")
                        .HasColumnName("brand_id");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("modelName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model_name");

                    b.HasKey("Id");

                    b.HasIndex("brandId");

                    b.ToTable("BrandModels");
                });

            modelBuilder.Entity("NetShop.ProductService.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("brandModelId")
                        .HasColumnType("uuid")
                        .HasColumnName("brand_model_id");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<double>("price")
                        .HasColumnType("double precision");

                    b.Property<string>("productCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("product_code");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("product_name");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("supplierId")
                        .HasColumnType("uuid")
                        .HasColumnName("supplier_id");

                    b.HasKey("Id");

                    b.HasIndex("brandModelId");

                    b.HasIndex("supplierId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("NetShop.ProductService.Domain.Entities.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("fax")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fax");

                    b.Property<string>("logo")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("supplierName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("supplier_name");

                    b.Property<string>("website")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("website");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("NetShop.ProductService.Domain.Entities.BrandModel", b =>
                {
                    b.HasOne("NetShop.ProductService.Domain.Entities.Brand", "brand")
                        .WithMany()
                        .HasForeignKey("brandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("brand");
                });

            modelBuilder.Entity("NetShop.ProductService.Domain.Entities.Product", b =>
                {
                    b.HasOne("NetShop.ProductService.Domain.Entities.BrandModel", "brandModel")
                        .WithMany()
                        .HasForeignKey("brandModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetShop.ProductService.Domain.Entities.Supplier", "supplier")
                        .WithMany()
                        .HasForeignKey("supplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("brandModel");

                    b.Navigation("supplier");
                });
#pragma warning restore 612, 618
        }
    }
}
