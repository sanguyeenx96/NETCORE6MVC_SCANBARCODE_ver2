using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BCDAUMO.Models
{
    public partial class QuanLyVatTuContext : DbContext
    {
        public QuanLyVatTuContext()
        {
        }

        public QuanLyVatTuContext(DbContextOptions<QuanLyVatTuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataRule> DataRules { get; set; } = null!;
        public virtual DbSet<DataRuleTen> DataRuleTens { get; set; } = null!;
        public virtual DbSet<Datamoquevo> Datamoquevos { get; set; } = null!;
        public virtual DbSet<DatamoquevoNew> DatamoquevoNews { get; set; } = null!;
        public virtual DbSet<Input> Inputs { get; set; } = null!;
        public virtual DbSet<Layout> Layouts { get; set; } = null!;
        public virtual DbSet<LichSuTonKho> LichSuTonKhos { get; set; } = null!;
        public virtual DbSet<Lichsu> Lichsus { get; set; } = null!;
        public virtual DbSet<Lichsunhapkhoput> Lichsunhapkhoputs { get; set; } = null!;
        public virtual DbSet<LichsunhapkhoputNew> LichsunhapkhoputNews { get; set; } = null!;
        public virtual DbSet<Lichsunhaptu> Lichsunhaptus { get; set; } = null!;
        public virtual DbSet<LichsunhaptuNew> LichsunhaptuNews { get; set; } = null!;
        public virtual DbSet<Lichsusanchiet> Lichsusanchiets { get; set; } = null!;
        public virtual DbSet<LichsusanchietNew> LichsusanchietNews { get; set; } = null!;
        public virtual DbSet<Lichsusuachualoi> Lichsusuachualois { get; set; } = null!;
        public virtual DbSet<Lichsuxuatline> Lichsuxuatlines { get; set; } = null!;
        public virtual DbSet<Rulemoquevo> Rulemoquevos { get; set; } = null!;
        public virtual DbSet<TonKho> TonKhos { get; set; } = null!;
        public virtual DbSet<TonKhoPa> TonKhoPas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.1.254;User Id=sa;Password=123;Initial Catalog=QuanLyVatTu;Trusted_connection=false;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataRule>(entity =>
            {
                entity.ToTable("dataRule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BarcodeLot)
                    .HasMaxLength(100)
                    .HasColumnName("barcodeLot");

                entity.Property(e => e.BarcodeTen)
                    .HasMaxLength(100)
                    .HasColumnName("barcodeTen");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("ghichu");

                entity.Property(e => e.Khoiluongnhapkho)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("khoiluongnhapkho");

                entity.Property(e => e.Khoiluongnhapline)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("khoiluongnhapline");

                entity.Property(e => e.Khoiluongnhaptu)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("khoiluongnhaptu");

                entity.Property(e => e.Ten)
                    .HasMaxLength(100)
                    .HasColumnName("ten");
            });

            modelBuilder.Entity<DataRuleTen>(entity =>
            {
                entity.ToTable("dataRuleTen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ghichu");

                entity.Property(e => e.Idname)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("idname");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Datamoquevo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("datamoquevo");

                entity.Property(e => e.Cell)
                    .HasMaxLength(50)
                    .HasColumnName("cell");

                entity.Property(e => e.Dinhmucmax)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("dinhmucmax");

                entity.Property(e => e.Dinhmucmin)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("dinhmucmin");

                entity.Property(e => e.Dinhmucsudungthucte)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("dinhmucsudungthucte");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("ghichu");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Khoiluongcapra)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("khoiluongcapra");

                entity.Property(e => e.Khoiluongcaprathucte)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("khoiluongcaprathucte");

                entity.Property(e => e.Khoiluongcoc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("khoiluongcoc");

                entity.Property(e => e.Khoiluongong)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("khoiluongong");

                entity.Property(e => e.Khoiluongthuve)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("khoiluongthuve");

                entity.Property(e => e.Khoiluongtungong)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("khoiluongtungong");

                entity.Property(e => e.Luongsudungkehoach)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("luongsudungkehoach");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .HasColumnName("model");

                entity.Property(e => e.Ngayphatra)
                    .HasMaxLength(100)
                    .HasColumnName("ngayphatra");

                entity.Property(e => e.Ngaythuve)
                    .HasMaxLength(100)
                    .HasColumnName("ngaythuve");

                entity.Property(e => e.Sanluongkehoach).HasColumnName("sanluongkehoach");

                entity.Property(e => e.Sanluongthucte).HasColumnName("sanluongthucte");

                entity.Property(e => e.Soluongcoc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("soluongcoc");

                entity.Property(e => e.Soluongong)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("soluongong");

                entity.Property(e => e.Station)
                    .HasMaxLength(100)
                    .HasColumnName("station");

                entity.Property(e => e.Tenmo)
                    .HasMaxLength(100)
                    .HasColumnName("tenmo");

                entity.Property(e => e.Timephatra)
                    .HasMaxLength(100)
                    .HasColumnName("timephatra");

                entity.Property(e => e.Timethuve)
                    .HasMaxLength(100)
                    .HasColumnName("timethuve");
            });

            modelBuilder.Entity<DatamoquevoNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("datamoquevoNew");

                entity.Property(e => e.Cell)
                    .HasMaxLength(50)
                    .HasColumnName("cell");

                entity.Property(e => e.Dinhmucmax)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("dinhmucmax");

                entity.Property(e => e.Dinhmucmin)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("dinhmucmin");

                entity.Property(e => e.Dinhmucsudungthucte)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("dinhmucsudungthucte");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("ghichu");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Khoiluongcapra)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("khoiluongcapra");

                entity.Property(e => e.Khoiluongcaprathucte)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("khoiluongcaprathucte");

                entity.Property(e => e.Khoiluongcoc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("khoiluongcoc");

                entity.Property(e => e.Khoiluongong)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("khoiluongong");

                entity.Property(e => e.Khoiluongthuve)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("khoiluongthuve");

                entity.Property(e => e.Khoiluongtungong)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("khoiluongtungong");

                entity.Property(e => e.Luongsudungkehoach)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("luongsudungkehoach");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .HasColumnName("model");

                entity.Property(e => e.Ngayphatra)
                    .HasMaxLength(100)
                    .HasColumnName("ngayphatra");

                entity.Property(e => e.Ngaythuve)
                    .HasMaxLength(100)
                    .HasColumnName("ngaythuve");

                entity.Property(e => e.Sanluongkehoach).HasColumnName("sanluongkehoach");

                entity.Property(e => e.Sanluongthucte).HasColumnName("sanluongthucte");

                entity.Property(e => e.Soluongcoc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("soluongcoc");

                entity.Property(e => e.Soluongong)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("soluongong");

                entity.Property(e => e.Station)
                    .HasMaxLength(100)
                    .HasColumnName("station");

                entity.Property(e => e.Tenmo)
                    .HasMaxLength(100)
                    .HasColumnName("tenmo");

                entity.Property(e => e.Timephatra)
                    .HasMaxLength(100)
                    .HasColumnName("timephatra");

                entity.Property(e => e.Timethuve)
                    .HasMaxLength(100)
                    .HasColumnName("timethuve");
            });

            modelBuilder.Entity<Input>(entity =>
            {
                entity.ToTable("input");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cell)
                    .HasMaxLength(100)
                    .HasColumnName("cell");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .HasColumnName("model");

                entity.Property(e => e.Phanloai)
                    .HasMaxLength(100)
                    .HasColumnName("phanloai");

                entity.Property(e => e.Station)
                    .HasMaxLength(100)
                    .HasColumnName("station");
            });

            modelBuilder.Entity<Layout>(entity =>
            {
                entity.ToTable("layout");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cell).HasMaxLength(100);

                entity.Property(e => e.HienTuongLoi).HasMaxLength(500);

                entity.Property(e => e.LucBanVit).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.PhanLoai).HasMaxLength(100);

                entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Solanbipjig).HasColumnName("solanbipjig");

                entity.Property(e => e.Station).HasMaxLength(100);

                entity.Property(e => e.Ten).HasMaxLength(500);

                entity.Property(e => e.ThoiGianBao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ThoiGianXacNhan).HasMaxLength(100);

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'OK')");
            });

            modelBuilder.Entity<LichSuTonKho>(entity =>
            {
                entity.ToTable("LichSuTonKho");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cell).HasMaxLength(500);

                entity.Property(e => e.GhiChu).HasMaxLength(500);

                entity.Property(e => e.HinhAnh).HasColumnType("image");

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.NgayXuat).HasMaxLength(400);

                entity.Property(e => e.Ngaynhap).HasMaxLength(400);

                entity.Property(e => e.NguoiDamNhiem).HasMaxLength(100);

                entity.Property(e => e.PhanLoai).HasMaxLength(100);

                entity.Property(e => e.Station).HasMaxLength(500);

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.Property(e => e.ThoiGianSua).HasMaxLength(500);

                entity.Property(e => e.TrangThai).HasMaxLength(100);
            });

            modelBuilder.Entity<Lichsu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lichsu");

                entity.Property(e => e.Cell).HasMaxLength(100);

                entity.Property(e => e.HienTuongLoi).HasMaxLength(500);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.PhanLoai).HasMaxLength(100);

                entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Station).HasMaxLength(100);

                entity.Property(e => e.Ten).HasMaxLength(500);

                entity.Property(e => e.ThoiGianBao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ThoiGianXacNhan).HasMaxLength(100);

                entity.Property(e => e.TrangThai)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'OK')");
            });

            modelBuilder.Entity<Lichsunhapkhoput>(entity =>
            {
                entity.ToTable("lichsunhapkhoput");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Donvi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("donvi");

                entity.Property(e => e.Lotno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lotno");

                entity.Property(e => e.Ngaynhap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ngaynhap");

                entity.Property(e => e.Nguoinhap)
                    .HasMaxLength(100)
                    .HasColumnName("nguoinhap");

                entity.Property(e => e.Soluongnhap)
                    .HasMaxLength(500)
                    .HasColumnName("soluongnhap");

                entity.Property(e => e.Tenvattu)
                    .HasMaxLength(100)
                    .HasColumnName("tenvattu");

                entity.Property(e => e.Tondau)
                    .HasMaxLength(500)
                    .HasColumnName("tondau");
            });

            modelBuilder.Entity<LichsunhapkhoputNew>(entity =>
            {
                entity.ToTable("lichsunhapkhoputNew");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Donvi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("donvi");

                entity.Property(e => e.Lotno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lotno");

                entity.Property(e => e.Ngaynhap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ngaynhap");

                entity.Property(e => e.Nguoinhap)
                    .HasMaxLength(100)
                    .HasColumnName("nguoinhap");

                entity.Property(e => e.Soluongnhap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("soluongnhap");

                entity.Property(e => e.Tenvattu)
                    .HasMaxLength(100)
                    .HasColumnName("tenvattu");

                entity.Property(e => e.Tondau)
                    .HasMaxLength(500)
                    .HasColumnName("tondau");

                entity.Property(e => e.Vitri)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("vitri");
            });

            modelBuilder.Entity<Lichsunhaptu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lichsunhaptu");

                entity.Property(e => e.Donvi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("donvi");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Lotno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lotno");

                entity.Property(e => e.Ngaynhap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ngaynhap");

                entity.Property(e => e.Nguoinhap)
                    .HasMaxLength(100)
                    .HasColumnName("nguoinhap");

                entity.Property(e => e.Soluongnhaptu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("soluongnhaptu");

                entity.Property(e => e.Tenvattu)
                    .HasMaxLength(100)
                    .HasColumnName("tenvattu");

                entity.Property(e => e.Tondautu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tondautu");
            });

            modelBuilder.Entity<LichsunhaptuNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lichsunhaptuNew");

                entity.Property(e => e.Donvi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("donvi");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Lotno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lotno");

                entity.Property(e => e.Ngaynhap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ngaynhap");

                entity.Property(e => e.Nguoinhap)
                    .HasMaxLength(100)
                    .HasColumnName("nguoinhap");

                entity.Property(e => e.Soluongnhaptu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("soluongnhaptu");

                entity.Property(e => e.Tenvattu)
                    .HasMaxLength(100)
                    .HasColumnName("tenvattu");

                entity.Property(e => e.Tondautu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tondautu");

                entity.Property(e => e.Vitri)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("vitri");
            });

            modelBuilder.Entity<Lichsusanchiet>(entity =>
            {
                entity.ToTable("lichsusanchiet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Giothuchien)
                    .HasMaxLength(100)
                    .HasColumnName("giothuchien");

                entity.Property(e => e.Ngaythuchien)
                    .HasMaxLength(10)
                    .HasColumnName("ngaythuchien");

                entity.Property(e => e.Nguoithuchien)
                    .HasMaxLength(100)
                    .HasColumnName("nguoithuchien");

                entity.Property(e => e.Result)
                    .HasMaxLength(100)
                    .HasColumnName("result");

                entity.Property(e => e.Vitri)
                    .HasMaxLength(10)
                    .HasColumnName("vitri");
            });

            modelBuilder.Entity<LichsusanchietNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lichsusanchietNew");

                entity.Property(e => e.Donvi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("donvi");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Lotno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lotno");

                entity.Property(e => e.Ngaynhap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ngaynhap");

                entity.Property(e => e.Nguoinhap)
                    .HasMaxLength(100)
                    .HasColumnName("nguoinhap");

                entity.Property(e => e.Soluongnhaptu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("soluongnhaptu");

                entity.Property(e => e.Tenvattu)
                    .HasMaxLength(100)
                    .HasColumnName("tenvattu");

                entity.Property(e => e.Tondautu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tondautu");

                entity.Property(e => e.Vitri)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("vitri");
            });

            modelBuilder.Entity<Lichsusuachualoi>(entity =>
            {
                entity.ToTable("lichsusuachualoi");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Caitien)
                    .HasMaxLength(500)
                    .HasColumnName("caitien");

                entity.Property(e => e.Cell)
                    .HasMaxLength(100)
                    .HasColumnName("cell");

                entity.Property(e => e.Damnhiem)
                    .HasMaxLength(500)
                    .HasColumnName("damnhiem");

                entity.Property(e => e.DonVi).HasMaxLength(100);

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(500)
                    .HasColumnName("ghichu");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .HasColumnName("model");

                entity.Property(e => e.Nguyennhanloi)
                    .HasMaxLength(500)
                    .HasColumnName("nguyennhanloi");

                entity.Property(e => e.SoLuong).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Station)
                    .HasMaxLength(100)
                    .HasColumnName("station");

                entity.Property(e => e.TenThietBiThuVe)
                    .HasMaxLength(100)
                    .HasColumnName("tenThietBiThuVe");

                entity.Property(e => e.Tenthietbiphatra)
                    .HasMaxLength(100)
                    .HasColumnName("tenthietbiphatra");

                entity.Property(e => e.Thoigiancaitien)
                    .HasMaxLength(100)
                    .HasColumnName("thoigiancaitien");

                entity.Property(e => e.Thoigianphatsinhloi)
                    .HasMaxLength(100)
                    .HasColumnName("thoigianphatsinhloi");

                entity.Property(e => e.Tinhtrangloi)
                    .HasMaxLength(500)
                    .HasColumnName("tinhtrangloi");
            });

            modelBuilder.Entity<Lichsuxuatline>(entity =>
            {
                entity.ToTable("lichsuxuatline");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Donvi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("donvi");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(500)
                    .HasColumnName("ghichu");

                entity.Property(e => e.Lotno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lotno");

                entity.Property(e => e.Ngayxuat)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ngayxuat");

                entity.Property(e => e.Nguoixuat)
                    .HasMaxLength(100)
                    .HasColumnName("nguoixuat");

                entity.Property(e => e.Result)
                    .HasMaxLength(10)
                    .HasColumnName("result")
                    .IsFixedLength();

                entity.Property(e => e.Soluongxuatline)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("soluongxuatline");

                entity.Property(e => e.Tenvattuphatra)
                    .HasMaxLength(100)
                    .HasColumnName("tenvattuphatra");

                entity.Property(e => e.Tenvattuthuve)
                    .HasMaxLength(100)
                    .HasColumnName("tenvattuthuve");

                entity.Property(e => e.Tontu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tontu");

                entity.Property(e => e.Vitri)
                    .HasMaxLength(100)
                    .HasColumnName("vitri");
            });

            modelBuilder.Entity<Rulemoquevo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("rulemoquevo");

                entity.Property(e => e.Cell)
                    .HasMaxLength(50)
                    .HasColumnName("cell");

                entity.Property(e => e.Dinhmucmax)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("dinhmucmax");

                entity.Property(e => e.Dinhmucmin)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("dinhmucmin");

                entity.Property(e => e.Dinhmucsudungthucte)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("dinhmucsudungthucte");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(100)
                    .HasColumnName("ghichu");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Khoiluongcapra)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("khoiluongcapra");

                entity.Property(e => e.Khoiluongcoc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("khoiluongcoc");

                entity.Property(e => e.Khoiluongong)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("khoiluongong");

                entity.Property(e => e.Khoiluongthuve)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("khoiluongthuve");

                entity.Property(e => e.Khoiluongtrongong)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("khoiluongtrongong");

                entity.Property(e => e.Luongkhautru)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("luongkhautru");

                entity.Property(e => e.Luongsudungkehoach)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("luongsudungkehoach");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .HasColumnName("model");

                entity.Property(e => e.Sanluongkehoach).HasColumnName("sanluongkehoach");

                entity.Property(e => e.Sanluongthucte).HasColumnName("sanluongthucte");

                entity.Property(e => e.Soluongcoc)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("soluongcoc");

                entity.Property(e => e.Soluongong)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("soluongong");

                entity.Property(e => e.Station)
                    .HasMaxLength(100)
                    .HasColumnName("station");

                entity.Property(e => e.Tenmo)
                    .HasMaxLength(100)
                    .HasColumnName("tenmo");
            });

            modelBuilder.Entity<TonKho>(entity =>
            {
                entity.ToTable("TonKho");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cell).HasMaxLength(500);

                entity.Property(e => e.GhiChu).HasMaxLength(500);

                entity.Property(e => e.HinhAnh).HasColumnType("image");

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.NgayXuat).HasMaxLength(400);

                entity.Property(e => e.Ngaynhap).HasMaxLength(400);

                entity.Property(e => e.NguoiDamNhiem).HasMaxLength(100);

                entity.Property(e => e.PhanLoai).HasMaxLength(100);

                entity.Property(e => e.Station).HasMaxLength(500);

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.Property(e => e.TonKho1).HasColumnName("TonKho");

                entity.Property(e => e.TrangThai).HasMaxLength(100);
            });

            modelBuilder.Entity<TonKhoPa>(entity =>
            {
                entity.ToTable("TonKhoPA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cell).HasMaxLength(500);

                entity.Property(e => e.Donvi).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(500);

                entity.Property(e => e.HinhAnh).HasColumnType("image");

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.NgayNhapLenTu).HasMaxLength(400);

                entity.Property(e => e.NgayXuatLenTu).HasMaxLength(400);

                entity.Property(e => e.NgayXuatRaLine).HasMaxLength(400);

                entity.Property(e => e.NgaynhapTuPurchasre).HasMaxLength(400);

                entity.Property(e => e.NguoiDamNhiem).HasMaxLength(100);

                entity.Property(e => e.PhanLoai).HasMaxLength(100);

                entity.Property(e => e.SoLuongNhapTu).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SoLuongNhapTuPurchasre).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SoLuongTonTu).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SoLuongXuatLenTu).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SoLuongXuatRaLine).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.Property(e => e.TonDau).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TonDauTu).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TonKho).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.TonKhoTong).HasColumnType("decimal(18, 4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
