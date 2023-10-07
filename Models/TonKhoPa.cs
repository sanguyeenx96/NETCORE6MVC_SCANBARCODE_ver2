using System;
using System.Collections.Generic;

namespace BCDAUMO.Models
{
    public partial class TonKhoPa
    {
        public int Id { get; set; }
        public string? PhanLoai { get; set; }
        public string Ten { get; set; } = null!;
        public string? Model { get; set; }
        public string? Cell { get; set; }
        public decimal? TonDau { get; set; }
        public decimal? TonDauTu { get; set; }
        public string? GhiChu { get; set; }
        public string? NguoiDamNhiem { get; set; }
        public decimal? SoLuongNhapTuPurchasre { get; set; }
        public string? NgaynhapTuPurchasre { get; set; }
        public decimal? SoLuongXuatLenTu { get; set; }
        public string? NgayXuatLenTu { get; set; }
        public decimal? SoLuongNhapTu { get; set; }
        public string? NgayNhapLenTu { get; set; }
        public decimal? SoLuongXuatRaLine { get; set; }
        public string? NgayXuatRaLine { get; set; }
        public decimal? SoLuongTonTu { get; set; }
        public decimal? TonKhoTong { get; set; }
        public byte[]? HinhAnh { get; set; }
        public string? Donvi { get; set; }
        public decimal? TonKho { get; set; }
    }
}
