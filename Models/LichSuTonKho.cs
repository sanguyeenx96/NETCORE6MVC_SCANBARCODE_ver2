using System;
using System.Collections.Generic;

namespace BCDAUMO.Models
{
    public partial class LichSuTonKho
    {
        public int Id { get; set; }
        public string Ten { get; set; } = null!;
        public string? Model { get; set; }
        public string? Cell { get; set; }
        public string? Station { get; set; }
        public int? TonDau { get; set; }
        public string? TrangThai { get; set; }
        public string? GhiChu { get; set; }
        public string? NguoiDamNhiem { get; set; }
        public int? SoLuongnhap { get; set; }
        public string? Ngaynhap { get; set; }
        public int? SoLuongXuat { get; set; }
        public string? NgayXuat { get; set; }
        public int? TonKho { get; set; }
        public byte[]? HinhAnh { get; set; }
        public string? ThoiGianSua { get; set; }
        public string? PhanLoai { get; set; }
    }
}
