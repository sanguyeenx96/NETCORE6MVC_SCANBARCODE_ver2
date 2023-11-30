using BCDAUMO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BCDAUMO.Controllers
{
    public class XuatLineController : Controller
    {
        private readonly ILogger<XuatLineController> _logger;
        private readonly QuanLyVatTuContext _context;

        public XuatLineController(ILogger<XuatLineController> logger, QuanLyVatTuContext quanLyVatTuContext)
        {
            _logger = logger;
            _context = quanLyVatTuContext;
        }
        public static class MyStringStorage
        {
            public static string? ten_vattuthuve { get; set; }
            public static string? ma_vattuthuve { get; set; }
            public static string? ten_vattuphatra { get; set; }
            public static string? ma_vattuphatra { get; set; }
            public static string? st_model { get; set; }
            public static string? st_cell { get; set; }
            public static string? st_station { get; set; }
            public static string? ten { get; set; }
            public static string? st_thoigianphatsinhloi { get; set; }
            public static string? st_thoigiancaitien { get; set; }
            public static string? st_tinhtrangloi { get; set; }
            public static string? st_nguyennhanloi { get; set; }
            public static string? st_caitien { get; set; }
            public static string? st_damnhiem { get; set; }
            public static string? st_ghichu { get; set; }
            public static decimal st_soluong { get; set; }
            public static string? st_donvi { get; set; }
        }
        public IActionResult PD1()
        {
            ViewBag.tenpage = "Xuất Line PD1";
            return View();
        }

        public IActionResult PD2()
        {
            ViewBag.tenpage = "Xuất Line PD2";
            return View();
        }

        public async Task<IActionResult> CheckingOP(string id)
        {
            MyStringStorage.ten_vattuthuve = "";
            MyStringStorage.ma_vattuthuve = "";
            MyStringStorage.ten_vattuphatra = "";
            MyStringStorage.ma_vattuphatra = "";

            MyStringStorage.st_model = "";
            MyStringStorage.st_cell = "";
            MyStringStorage.st_station = "";

            MyStringStorage.ten = "";

            MyStringStorage.st_thoigianphatsinhloi = "";
            MyStringStorage.st_thoigiancaitien = "";
            MyStringStorage.st_tinhtrangloi = "";
            MyStringStorage.st_nguyennhanloi = "";
            MyStringStorage.st_caitien = "";
            MyStringStorage.st_damnhiem = "";
            MyStringStorage.st_ghichu = "";
            MyStringStorage.st_soluong = 0;
            MyStringStorage.st_donvi = "";
            var nguoithaotac = await _context.DataRuleTens.Where(x => x.Idname == id).FirstOrDefaultAsync();
            if (nguoithaotac == null)
            {
                return Json(new { success = false });
            }
            string tenOP = nguoithaotac.Name;
            MyStringStorage.st_damnhiem = tenOP;
            return Json(new { success = true, data = tenOP });
        }

        public async Task<IActionResult> CheckingVitri(string vitri)
        {
            string[] text = vitri.Split(';');
            string model = text[0].Trim();
            string cell = text[1].Trim();
            string station = text[2].Trim();
            string ten = text[3].Trim();

            if (cell == null) { cell = ""; }
            if (station == null) { station = ""; }
            if (ten == null) { ten = ""; }

            var dulieuvitri = await _context.Layouts.Where(x => (x.Model == model && x.Cell == cell && x.Station == station && x.PhanLoai == ten)).ToListAsync();
            if (dulieuvitri.Count == 0)
            {
                return Json(new { success = false });
            }
            else
            {
                MyStringStorage.st_model = model;
                MyStringStorage.st_cell = cell;
                MyStringStorage.st_station = station;
                MyStringStorage.ten = ten;

                return Json(new { success = true, data = dulieuvitri });
            }
        }

        public async Task<IActionResult> CheckingVattuthuve(string vattuthuve, string pd)
        {
            try
            {
                string ten = MyStringStorage.ten;

                string[] text = vattuthuve.Split(';');

                //add new:
                if (text.Length <= 2)
                {
                    string tenvattuthuve = text[0].Trim();

                    var dulieu = await _context.DataRules.Where(x => x.BarcodeTen == tenvattuthuve).FirstOrDefaultAsync();
                    if (ten == dulieu.Ten.ToString())
                    {
                        MyStringStorage.ten_vattuthuve = dulieu.Ten.ToString();
                        MyStringStorage.ma_vattuthuve = tenvattuthuve;
                        var dulieu2 = await _context.TonKhoPas.Where(x => (x.Ten == dulieu.Ten && x.GhiChu == pd)).FirstOrDefaultAsync();
                        var laylotno = await _context.Lichsunhaptus
                                                    .Where(l => l.Tenvattu == dulieu.Ten)
                                                    .OrderByDescending(l => l.Id)
                                                    .Take(1)
                                                    .FirstOrDefaultAsync();
                        if (dulieu != null && dulieu2 != null && laylotno != null)
                        {
                            var data = new { dulieu = dulieu, dulieu2 = dulieu2, dulieu3 = laylotno };
                            return Json(new { success = true, data = data });
                        }
                        else
                        {
                            return Json(new { success = false });
                        }
                    }
                    else
                    {
                        return Json(new { success = false });
                    }
                }
                else
                {
                    string ten1 = ten;
                    if (ten == "EM D110")
                    {
                        ten1 = "EM-D110";
                    }
                    else if (ten == "Mo G-573")
                    {
                        ten1 = "G573";
                    }
                    else if (ten == "Mo 8080")
                    {
                        ten1 = "G8080";
                    }
                    else if (ten == "HP300")
                    {
                        ten1 = "HP 300";
                    }
                    if (ten1.Contains(text[3]))
                    {
                        MyStringStorage.ten_vattuthuve = ten1;
                        var dulieu = await _context.DataRules.Where(x => x.Ten == ten).FirstOrDefaultAsync();
                        MyStringStorage.ma_vattuthuve = "";
                        var dulieu2 = await _context.TonKhoPas.Where(x => (x.Ten == ten && x.GhiChu == pd)).FirstOrDefaultAsync();
                        var laylotno = await _context.Lichsunhaptus
                                                    .Where(l => l.Tenvattu == ten)
                                                    .OrderByDescending(l => l.Id)
                                                    .Take(1)
                                                    .FirstOrDefaultAsync();
                        if (dulieu != null && dulieu2 != null && laylotno != null)
                        {
                            var data = new { dulieu = dulieu, dulieu2 = dulieu2, dulieu3 = laylotno };
                            return Json(new { success = true, data = data });
                        }
                        else
                        {
                            return Json(new { success = false });
                        }
                    }
                    else
                    {
                        return Json(new { success = false });
                    }
                }
            }
            catch
            {
                return Json(new { success = false });
            }

        }

        [HttpPost]
        public IActionResult updateStatus(string status, string model, string cell, string station, string phanloai)
        {

            if (string.IsNullOrEmpty(cell)) { cell = ""; }
            if (string.IsNullOrEmpty(station)) { station = ""; }

            var rowToUpdate = _context.Layouts.FirstOrDefault(s => (s.Model == model && (s.Cell == cell || string.IsNullOrEmpty(s.Cell)) && (s.Station == station || string.IsNullOrEmpty(s.Station)) && s.PhanLoai == phanloai));

            if (rowToUpdate != null)
            {
                rowToUpdate.TrangThai = status;
                rowToUpdate.ThoiGianBao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                _context.Entry(rowToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true, data = rowToUpdate });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Luulichsu_Xuatline(string tenvattuthuve, string tenvattuphatra, string soluongxuatline,
         string nguoixuat, string donvi, string tontu, string vitri, string result, string lotno,
           string ghichu)
        {
            try
            {
                Lichsuxuatline lichsu = new Lichsuxuatline();
                lichsu.Tenvattuthuve = tenvattuthuve;
                lichsu.Tenvattuphatra = tenvattuphatra;
                lichsu.Soluongxuatline = Convert.ToDecimal(soluongxuatline);
                lichsu.Ngayxuat = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                lichsu.Nguoixuat = MyStringStorage.st_damnhiem;
                lichsu.Donvi = donvi;
                lichsu.Tontu = Convert.ToDecimal(tontu);
                lichsu.Vitri = vitri;
                lichsu.Result = result;
                lichsu.Lotno = lotno;
                lichsu.Ghichu = ghichu;
                await _context.AddAsync(lichsu);
                await _context.SaveChangesAsync();
                return Json(new { success = true, data = lichsu });

            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckingVattuphatra(string mavattuphatra, string status, string model, string cell, string station,
           string phanloai, string thoigianbaoloi, string nguoixuat, string vitri, decimal soluongxuatline,
           string donvi, decimal tontu, string lotno)
        {
            try
            {
                string ten = MyStringStorage.ten;

                if (string.IsNullOrEmpty(cell)) { cell = ""; }
                if (string.IsNullOrEmpty(station)) { station = ""; }

                string[] text = mavattuphatra.Split(';');
                string ma_vattuphatra = text[0].Trim();

                string ten_vattuthuve = MyStringStorage.ten_vattuthuve;
                string ma_vattuthuve = MyStringStorage.ma_vattuthuve;

                if (text.Length <= 2)
                {
                    if (ma_vattuthuve != ma_vattuphatra) //TRƯỜNG HỢP NG
                    {
                        //Cập nhật bảng layout
                        var rowToUpdate = _context.Layouts.FirstOrDefault(s => (s.Model == model && (s.Cell == cell || string.IsNullOrEmpty(s.Cell)) && (s.Station == station || string.IsNullOrEmpty(s.Station)) && s.PhanLoai == phanloai));
                        rowToUpdate.TrangThai = status;
                        rowToUpdate.ThoiGianBao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        _context.Entry(rowToUpdate).State = EntityState.Modified;
                        //Thêm dữ liệu NG vào bàng Líchuxuatline
                        Lichsuxuatline lichsuNG = new Lichsuxuatline();
                        lichsuNG.Tenvattuthuve = ten_vattuthuve;
                        lichsuNG.Tenvattuphatra = ma_vattuphatra;
                        lichsuNG.Soluongxuatline = Convert.ToDecimal(0);
                        lichsuNG.Ngayxuat = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        lichsuNG.Nguoixuat = MyStringStorage.st_damnhiem;
                        lichsuNG.Donvi = "";
                        lichsuNG.Tontu = Convert.ToDecimal(0);
                        lichsuNG.Vitri = vitri;
                        lichsuNG.Result = "NG";
                        lichsuNG.Lotno = "";
                        lichsuNG.Ghichu = "";
                        await _context.AddAsync(lichsuNG);
                        await _context.SaveChangesAsync();
                        var ketqua = new { mode = "NG", updatelayout = rowToUpdate, addLichsuxuatline = lichsuNG };
                        return Json(new { success = true, data = ketqua });

                    }
                    else //TRƯỜNG HỢP OK
                    {

                        MyStringStorage.st_soluong = soluongxuatline;
                        MyStringStorage.st_donvi = donvi;
                        var dulieu = await _context.DataRules.Where(x => x.BarcodeTen == ma_vattuphatra).FirstOrDefaultAsync();
                        MyStringStorage.ten_vattuphatra = dulieu.Ten.ToString();
                        MyStringStorage.ma_vattuphatra = ma_vattuphatra;
                        if (dulieu != null)
                        {
                            Lichsuxuatline lichsuOK = new Lichsuxuatline();
                            lichsuOK.Tenvattuthuve = ten_vattuthuve;
                            lichsuOK.Tenvattuphatra = MyStringStorage.ten_vattuphatra;
                            lichsuOK.Soluongxuatline = soluongxuatline;
                            lichsuOK.Ngayxuat = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            lichsuOK.Nguoixuat = MyStringStorage.st_damnhiem;
                            lichsuOK.Donvi = donvi;
                            lichsuOK.Tontu = tontu;
                            lichsuOK.Vitri = vitri;
                            lichsuOK.Result = "OK";
                            lichsuOK.Lotno = lotno;
                            lichsuOK.Ghichu = "";
                            await _context.AddAsync(lichsuOK);
                            await _context.SaveChangesAsync();
                            var ketqua = new { mode = "OK", dulieu = dulieu, dulieuluuOK = lichsuOK };
                            return Json(new { success = true, data = ketqua });
                        }
                        else
                        {
                            return Json(new { success = false });
                        }
                    }
                }
                else
                {
                    string ten1 = ten;
                    if (ten == "EM D110")
                    {
                        ten1 = "EM-D110";
                    }
                    else if (ten == "Mo G-573")
                    {
                        ten1 = "G573";
                    }
                    else if (ten == "Mo 8080")
                    {
                        ten1 = "G8080";
                    }
                    else if (ten == "HP300")
                    {
                        ten1 = "HP 300";
                    }

                    if (ten1.Contains(text[3]) && text[3] == ten_vattuthuve)
                    {
                        MyStringStorage.st_soluong = soluongxuatline;
                        MyStringStorage.st_donvi = donvi;
                        var dulieu = await _context.DataRules.Where(x => x.Ten == ten).FirstOrDefaultAsync();
                        MyStringStorage.ten_vattuphatra = dulieu.Ten.ToString();
                        MyStringStorage.ma_vattuphatra = "";
                        if (dulieu != null)
                        {
                            Lichsuxuatline lichsuOK = new Lichsuxuatline();
                            lichsuOK.Tenvattuthuve = ten_vattuthuve;
                            lichsuOK.Tenvattuphatra = MyStringStorage.ten_vattuphatra;
                            lichsuOK.Soluongxuatline = soluongxuatline;
                            lichsuOK.Ngayxuat = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            lichsuOK.Nguoixuat = MyStringStorage.st_damnhiem;
                            lichsuOK.Donvi = donvi;
                            lichsuOK.Tontu = tontu;
                            lichsuOK.Vitri = vitri;
                            lichsuOK.Result = "OK";
                            lichsuOK.Lotno = lotno;
                            lichsuOK.Ghichu = "";
                            await _context.AddAsync(lichsuOK);
                            await _context.SaveChangesAsync();
                            var ketqua = new { mode = "OK", dulieu = dulieu, dulieuluuOK = lichsuOK };
                            return Json(new { success = true, data = ketqua });
                        }
                        else
                        {
                            return Json(new { success = false });
                        }
                    }
                    else
                    {
                        //Cập nhật bảng layout
                        var rowToUpdate = _context.Layouts.FirstOrDefault(s => (s.Model == model && (s.Cell == cell || string.IsNullOrEmpty(s.Cell)) && (s.Station == station || string.IsNullOrEmpty(s.Station)) && s.PhanLoai == phanloai));
                        rowToUpdate.TrangThai = status;
                        rowToUpdate.ThoiGianBao = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        _context.Entry(rowToUpdate).State = EntityState.Modified;
                        //Thêm dữ liệu NG vào bàng Líchuxuatline
                        Lichsuxuatline lichsuNG = new Lichsuxuatline();
                        lichsuNG.Tenvattuthuve = ten_vattuthuve;
                        lichsuNG.Tenvattuphatra = "";
                        lichsuNG.Soluongxuatline = Convert.ToDecimal(0);
                        lichsuNG.Ngayxuat = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        lichsuNG.Nguoixuat = MyStringStorage.st_damnhiem;
                        lichsuNG.Donvi = "";
                        lichsuNG.Tontu = Convert.ToDecimal(0);
                        lichsuNG.Vitri = vitri;
                        lichsuNG.Result = "NG";
                        lichsuNG.Lotno = "";
                        lichsuNG.Ghichu = "";
                        await _context.AddAsync(lichsuNG);
                        await _context.SaveChangesAsync();
                        var ketqua = new { mode = "NG", updatelayout = rowToUpdate, addLichsuxuatline = lichsuNG };
                        return Json(new { success = true, data = ketqua });
                    }
                }
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Final()
        {
            try
            {
                string tenThietBiThuVe = MyStringStorage.ten_vattuthuve;
                string model = MyStringStorage.st_model;
                string cell = MyStringStorage.st_cell;
                string station = MyStringStorage.st_station;
                string thoigianphatsinhloi = MyStringStorage.st_thoigianphatsinhloi;
                string tenthietbiphatra = MyStringStorage.ten_vattuphatra;
                string tinhtrangloi = MyStringStorage.st_tinhtrangloi;
                string nguyennhanloi = MyStringStorage.st_nguyennhanloi;
                string caitien = MyStringStorage.st_caitien;
                string damnhiem = MyStringStorage.st_damnhiem;
                string ghichu = MyStringStorage.st_ghichu;
                decimal soluong = MyStringStorage.st_soluong;
                string donvi = MyStringStorage.st_donvi;

                Lichsusuachualoi lichsu = new Lichsusuachualoi();
                lichsu.TenThietBiThuVe = tenThietBiThuVe;
                lichsu.Model = model;
                lichsu.Cell = cell;
                lichsu.Station = station;
                lichsu.Thoigianphatsinhloi = thoigianphatsinhloi;
                lichsu.Thoigiancaitien = DateTime.Now.ToString("dd/MM/yyyy");
                lichsu.Tenthietbiphatra = tenthietbiphatra;
                lichsu.Tinhtrangloi = tinhtrangloi;
                lichsu.Nguyennhanloi = nguyennhanloi;
                lichsu.Caitien = caitien;
                lichsu.Damnhiem = damnhiem;
                lichsu.Ghichu = ghichu;
                lichsu.SoLuong = soluong;
                lichsu.DonVi = donvi;

                await _context.AddAsync(lichsu);
                await _context.SaveChangesAsync();

                var tonKhoPA = _context.TonKhoPas.FirstOrDefault(x => x.Ten == tenthietbiphatra);
                if (tonKhoPA != null)
                {
                    tonKhoPA.SoLuongXuatRaLine += soluong;
                    tonKhoPA.TonKhoTong -= soluong;
                    tonKhoPA.SoLuongTonTu -= soluong;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    _context.Entry(tonKhoPA).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                TempData["success"] = 1;
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }


    }
}
