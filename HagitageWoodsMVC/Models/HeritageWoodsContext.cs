using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HagitageWoodsMVC.Models
{
    public partial class HeritageWoodsContext : DbContext
    {
        public HeritageWoodsContext()
        {
        }

        public HeritageWoodsContext(DbContextOptions<HeritageWoodsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:heritagewoods.database.windows.net,1433;Initial Catalog=HeritageWoods;Persist Security Info=False;User ID=admin789;Password=admin@789;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Cartid).HasColumnName("cartid");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK__Cart__Pid__71D1E811");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__Cart__userid__70DDC3D8");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderDet__0809335DF232D74E");

                entity.HasIndex(e => e.OrderEmail)
                    .HasName("UQ__OrderDet__A4ED1D721B2D6B37")
                    .IsUnique();

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.OrderAdress)
                    .HasColumnName("orderAdress")
                    .HasMaxLength(200);

                entity.Property(e => e.OrderAmount).HasColumnName("orderAmount");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("orderDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderEmail)
                    .IsRequired()
                    .HasColumnName("orderEmail")
                    .HasMaxLength(100);

                entity.Property(e => e.OrderMobile)
                    .IsRequired()
                    .HasColumnName("orderMobile")
                    .HasMaxLength(10);

                entity.Property(e => e.OrderQuantity).HasColumnName("orderQuantity");

                entity.Property(e => e.ShippingCharge).HasColumnName("shippingCharge");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK__OrderDetail__Pid__6C190EBB");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__OrderDeta__useri__6B24EA82");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Product___C1FFD8614CAAF52C");

                entity.ToTable("Product_category");

                entity.Property(e => e.Catname)
                    .HasColumnName("catname")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__Products__C5705938DBE1EC8C");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasColumnName("product_image");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__Products__Cid__66603565");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Test__AB6E6164CAB7D762")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.InsertDateTime)
                    .HasColumnName("insertDateTime")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.ProjectName)
                    .HasColumnName("projectName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Users__CBA1B2574C73304B");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Users__AB6E6164A9BF51D3")
                    .IsUnique();

                entity.HasIndex(e => e.Mobile)
                    .HasName("UQ__Users__A32E2E1CF82E45AC")
                    .IsUnique();

                entity.HasIndex(e => e.Password)
                    .HasName("UQ__Users__6E2DBEDEEF2F7104")
                    .IsUnique();

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middleName")
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasColumnName("mobile")
                    .HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.RegDate)
                    .HasColumnName("regDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.Property(e => e.UCity)
                    .HasColumnName("uCity")
                    .HasMaxLength(30);

                entity.Property(e => e.UCountry)
                    .HasColumnName("uCountry")
                    .HasMaxLength(30);

                entity.Property(e => e.UZip)
                    .HasColumnName("uZip")
                    .HasMaxLength(10);

                entity.Property(e => e.Ustate)
                    .HasColumnName("ustate")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
