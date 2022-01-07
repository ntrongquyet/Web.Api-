using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Web.Api.Models
{
    public partial class QLBHContext : DbContext
    {
        public QLBHContext()
        {
        }

        public QLBHContext(DbContextOptions<QLBHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=QLBH;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Apple",
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Samsung"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Xiaomi"
                    });
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("path");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Image_Product");

                entity.HasData(
                    new Image
                    {
                        Id = 1,
                        IdProduct = 1,
                        Path = "1_1.jpg"
                    },
                    new Image
                    {
                        Id = 2,
                        IdProduct = 1,
                        Path = "1_2.jpg"
                    },
                    new Image
                    {
                        Id = 3,
                        IdProduct = 2,
                        Path = "2_1.jpg"
                    },
                    new Image
                    {
                        Id = 4,
                        IdProduct = 2,
                        Path = "2_1.jpg"
                    });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("price");

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("softDelete")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");

                entity.HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "iPhone 13 Pro Max 256GB I Chính hãng VN/A",
                        CatId = 1,
                        Description = "iPhone 13 Pro Max 256GB được đánh giá là một trong những dòng iPhone có khả năng chụp ảnh siêu ấn tượng cùng với camera góc siêu rộng mang đến khả năng chụp ảnh thiếu sáng một cách đặc biệt. Không những thế, mà dòng iPhone này còn được đánh giá là có dung lượng bộ nhớ tốt, đáp ứng được đầy đủ các công việc hằng ngày Xem thêm thông tin iPhone 13 Pro Max 512GB thiết kế đẳng cấp, mang lại trải nghiệm vượt trội cho người dùng",
                        Price = 33500000M,
                        SoftDelete = false
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Xiaomi Mi 11 5G 128GB",
                        CatId = 3,
                        Description = "Làm chủ mọi khung hình - Bộ 3 camera sau 108 MP, camera selfie 20 MP\nHiệu năng vượt trội, xử lý cực nhanh - Chip Snapdragon 888 cao cấp, 8 GB RAM LPDDR5\nThiết kế thời thượng đi đầu xu hướng - Hoàn thiện thiết kế siêu mỏng từ kim loại và kính cường lực\nHiển thị rõ ràng, sắc nét - Màn hình tràn viền AMOLED 6.81 inch, 120Hz\nSáng tạo chuyên nghiệp mọi lúc, mọi nơi - Cụm 3 camera sau 108 MP, camera selfie 20 MP, chống rung quang học",
                        Price = 14200000M,
                        SoftDelete = false
                    });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
