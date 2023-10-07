using System;
using System.Collections.Generic;

namespace BCDAUMO.Models
{
    public partial class Rulemoquevo
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Cell { get; set; }
        public string? Station { get; set; }
        public string? Tenmo { get; set; }
        public int? Sanluongkehoach { get; set; }
        public int? Sanluongthucte { get; set; }
        public decimal? Dinhmucmax { get; set; }
        public decimal? Dinhmucmin { get; set; }
        public decimal? Khoiluongcapra { get; set; }
        public decimal? Khoiluongthuve { get; set; }
        public decimal? Luongsudungkehoach { get; set; }
        public decimal? Dinhmucsudungthucte { get; set; }
        public decimal? Khoiluongcoc { get; set; }
        public decimal? Khoiluongong { get; set; }
        public decimal? Soluongcoc { get; set; }
        public decimal? Soluongong { get; set; }
        public string? Ghichu { get; set; }
        public decimal? Luongkhautru { get; set; }
        public decimal? Khoiluongtrongong { get; set; }
    }
}
