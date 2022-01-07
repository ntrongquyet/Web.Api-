﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Api.Models;

namespace Web.Api.Migrations
{
    [DbContext(typeof(QLBHContext))]
    partial class QLBHContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web.Api.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Samsung"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Xiaomi"
                        });
                });

            modelBuilder.Entity("Web.Api.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int")
                        .HasColumnName("id_product");

                    b.Property<string>("Path")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("path");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.ToTable("Image");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdProduct = 1,
                            Path = "1_1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            IdProduct = 1,
                            Path = "1_2.jpg"
                        },
                        new
                        {
                            Id = 3,
                            IdProduct = 2,
                            Path = "2_1.jpg"
                        },
                        new
                        {
                            Id = 4,
                            IdProduct = 2,
                            Path = "2_1.jpg"
                        });
                });

            modelBuilder.Entity("Web.Api.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CatId")
                        .HasColumnType("int")
                        .HasColumnName("cat_id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,0)")
                        .HasColumnName("price");

                    b.Property<bool?>("SoftDelete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("softDelete")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id");

                    b.HasIndex("CatId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CatId = 1,
                            Description = "iPhone 13 Pro Max 256GB được đánh giá là một trong những dòng iPhone có khả năng chụp ảnh siêu ấn tượng cùng với camera góc siêu rộng mang đến khả năng chụp ảnh thiếu sáng một cách đặc biệt. Không những thế, mà dòng iPhone này còn được đánh giá là có dung lượng bộ nhớ tốt, đáp ứng được đầy đủ các công việc hằng ngày Xem thêm thông tin iPhone 13 Pro Max 512GB thiết kế đẳng cấp, mang lại trải nghiệm vượt trội cho người dùng",
                            Name = "iPhone 13 Pro Max 256GB I Chính hãng VN/A",
                            Price = 33500000m,
                            SoftDelete = false
                        },
                        new
                        {
                            Id = 2,
                            CatId = 3,
                            Description = "Làm chủ mọi khung hình - Bộ 3 camera sau 108 MP, camera selfie 20 MP\nHiệu năng vượt trội, xử lý cực nhanh - Chip Snapdragon 888 cao cấp, 8 GB RAM LPDDR5\nThiết kế thời thượng đi đầu xu hướng - Hoàn thiện thiết kế siêu mỏng từ kim loại và kính cường lực\nHiển thị rõ ràng, sắc nét - Màn hình tràn viền AMOLED 6.81 inch, 120Hz\nSáng tạo chuyên nghiệp mọi lúc, mọi nơi - Cụm 3 camera sau 108 MP, camera selfie 20 MP, chống rung quang học",
                            Name = "Xiaomi Mi 11 5G 128GB",
                            Price = 14200000m,
                            SoftDelete = false
                        });
                });

            modelBuilder.Entity("Web.Api.Models.Image", b =>
                {
                    b.HasOne("Web.Api.Models.Product", "IdProductNavigation")
                        .WithMany("Images")
                        .HasForeignKey("IdProduct")
                        .HasConstraintName("FK_Image_Product");

                    b.Navigation("IdProductNavigation");
                });

            modelBuilder.Entity("Web.Api.Models.Product", b =>
                {
                    b.HasOne("Web.Api.Models.Category", "Cat")
                        .WithMany("Products")
                        .HasForeignKey("CatId")
                        .HasConstraintName("FK_Product_Category")
                        .IsRequired();

                    b.Navigation("Cat");
                });

            modelBuilder.Entity("Web.Api.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Web.Api.Models.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
