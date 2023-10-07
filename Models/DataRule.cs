using System;
using System.Collections.Generic;

namespace BCDAUMO.Models
{
    public partial class DataRule
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? BarcodeTen { get; set; }
        public string? BarcodeLot { get; set; }
        public string? Ghichu { get; set; }
        public decimal? Khoiluongnhapkho { get; set; }
        public decimal? Khoiluongnhaptu { get; set; }
        public decimal? Khoiluongnhapline { get; set; }
    }
}
