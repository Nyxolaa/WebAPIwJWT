using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Token.Models
{
    public partial class KitapDbContext : DbContext
    {
        public KitapDbContext()
        {
        }

        public KitapDbContext(DbContextOptions<KitapDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategoriler> Kategorilers { get; set; } = null!;
        public virtual DbSet<Kitaplar> Kitaplars { get; set; } = null!;
        public virtual DbSet<Kullanici> Kullanicilar { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TUMHS1A\\NA;Initial Catalog=KitapDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>().HasData(
                new Kullanici { kullaniciID=1, kullaniciAdi="cevdo", Sifre="cev123"},
                new Kullanici { kullaniciID=2, kullaniciAdi="selo", Sifre="sel123"}
                );

            modelBuilder.Entity<Kategoriler>(entity =>
            {
                entity.HasKey(e => e.KategoriId);

                entity.ToTable("Kategoriler");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.KategoriAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kitaplar>(entity =>
            {
                entity.HasKey(e => e.KitapId);

                entity.ToTable("Kitaplar");

                entity.HasIndex(e => e.KategoriId, "IX_Kitaplar_KategoriID");

                entity.Property(e => e.KitapId).HasColumnName("KitapID");

                entity.Property(e => e.Fiyat).HasColumnType("money");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.KitapAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Kitaplars)
                    .HasForeignKey(d => d.KategoriId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
