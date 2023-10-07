window.onload = function () {
    $("#input").focus();
};
$(document).ready(function () {
    var step = 1;

    var ten_model = "";
    var ten_cell = "";
    var ten_station = "";
    var ten_phanloai = "";
    var ma_nguoithaotac = "";
    var ma_vattuthuve = "";
    var solancanbip = 0;
    var solanbipThuve = 0;
    var solanbipXuatra = 0;
    var soluongxuatline = "";
    var ten_donvi = "";
    var so_tontu = "";
    var so_lotno = "";

    var tenvattuthuve = "";
    var khoiluongxuat = "";
    var donvi = "";
    var tonkhoton = "";
    var tontu = "";
    var lotno = "";

    var titleElement = document.getElementById("txtTitle");
    titleElement.innerHTML =
        "<i class='fa fa-wifi fa-fw' aria-hidden='true'></i> QUÉT MÃ NGƯỜI THAO TÁC ";
    $("#input").keydown(function (e) {
        if (e.keyCode === 13) {
            var inputValue = $(this).val();
            if (step == 1) {
                $.ajax({
                    url: "/XuatLine/CheckingOP",
                    type: "GET",
                    data: { id: inputValue },
                    success: function (result) {
                        if (result.success) {
                            titleElement.innerHTML =
                                "<i class='fa fa-wifi fa-fw' aria-hidden='true'></i> QUÉT MÃ VỊ TRÍ ";
                            $("#txtNguoithuchien").val(
                                result.data.toUpperCase()
                            );
                            $("#input").val("");
                            $("#input").focus();
                            step = 2;
                        } else {
                            alert("Không có mã nhân viên " + inputValue);
                            $("#input").val("");
                            $("#input").focus();
                            step = 1;
                        }
                    },
                    error: function () {
                        alert(
                            "Không kết nối được tới máy chủ, kiểm tra lại kết nối và thử lại!"
                        );
                        $("#input").val("");
                        $("#input").focus();
                        step = 1;
                    },
                });
            }
            if (step == 2) {
                $.ajax({
                    url: "/XuatLine/CheckingVitri",
                    type: "GET",
                    data: { vitri: inputValue },
                    success: function (result) {
                        if (result.success) {
                            console.log("Thông tin vị trí :", result.data);
                            ten_model = result.data[0].model;
                            ten_cell = result.data[0].cell;
                            ten_station = result.data[0].station;
                            ten_phanloai = result.data[0].phanLoai;
                            solancanbip = result.data[0].solanbipjig;
                            $("#txtSolanbip").val(solancanbip);
                            $("#txtVitri").val(
                                ten_model + "*" + ten_cell + "*" + ten_station
                            );
                            titleElement.innerHTML =
                                "<i class='fa fa-wifi fa-fw' aria-hidden='true'></i> QUÉT MÃ VẬT TƯ THU VỀ ";
                            $("#input").val("");
                            $("#input").focus();
                            step = 3;
                        } else {
                            alert(
                                "Không tìm thấy thông tin vị trí " + inputValue
                            );
                            $("#input").val("");
                            $("#input").focus();
                            step = 2;
                        }
                    },
                    error: function () {
                        alert(
                            "Không kết nối được tới máy chủ, kiểm tra lại kết nối và thử lại!"
                        );
                        $("#input").val("");
                        $("#input").focus();
                        step = 2;
                    },
                });
            }

            if (step == 3) {
                $.ajax({
                    url: "/XuatLine/CheckingVattuthuve",
                    type: "GET",
                    data: { vattuthuve: inputValue },
                    success: function (result) {
                        if (result.success) {
                            var data = result.data;
                            console.log("Thông tin vật tư thu về: ", data);
                            tenvattuthuve = data.dulieu.ten;
                            khoiluongxuat = data.dulieu.khoiluongnhapline;
                            soluongxuatline = khoiluongxuat;
                            donvi = data.dulieu2.donvi;
                            ten_donvi = donvi;
                            tonkhoton = data.dulieu2.tonKhoTong;
                            tontu = data.dulieu2.soLuongTonTu;
                            so_tontu = tontu;
                            lotno = data.dulieu3.lotno;
                            so_lotno = lotno;

                            $.ajax({
                                //CẬP NHẬT TRẠNG THÁI OK CHO DBO LAYOUT
                                url: "/XuatLine/updateStatus",
                                type: "POST",
                                data: {
                                    status: "OK",
                                    thoigianbaoloi: "",
                                    model: ten_model,
                                    cell: ten_cell,
                                    station: ten_station,
                                    phanloai: tenvattuthuve,
                                },
                                success: function (result) {
                                    if (result.success) {
                                        console.log(
                                            "Đã cập nhật trạng thái bảng Layout tại vị trí thành OK :",
                                            result.data
                                        );
                                        $("#txtVattuthuve").val(tenvattuthuve);
                                        $("#txtSoluongxuat").val(khoiluongxuat);
                                        $("#txtLotno").val(lotno);

                                        solanbipThuve++;
                                        if (solanbipThuve < solancanbip) {
                                            $("#txtVattuthuve").css({
                                                background: "orange",
                                            });
                                        }
                                        if (solanbipThuve == solancanbip) {
                                            $("#txtVattuthuve").css({
                                                background: "green",
                                                color: "white",
                                            });
                                        }
                                        titleElement.innerHTML =
                                            "<i class='fa fa-wifi fa-fw' aria-hidden='true'></i> QUÉT MÃ VẬT TƯ XUẤT RA ";
                                        $("#input").val("");
                                        $("#input").focus();
                                        step = 4;
                                    } else {
                                        $.ajax({
                                            //CẬP NHẬT TRẠNG THÁI NG CHO LAYOUT
                                            url: "/XuatLine/updateStatus",
                                            type: "POST",
                                            data: {
                                                status: "SAI MO",
                                                model: ten_model,
                                                cell: ten_cell,
                                                station: ten_station,
                                                phanloai: ten_phanloai,
                                            },
                                            success: function (result) {
                                                if (result.success) {
                                                    console.log(
                                                        "Updated status SAI MO for dbo.layout",
                                                        result.data
                                                    );
                                                } else {
                                                    alert(
                                                        "Không cập nhật được bảng Layout, kiểm tra lại dữ liệu!"
                                                    );
                                                }
                                                step = 3;
                                            },
                                            error: function () {
                                                alert(
                                                    "Không kết nối được tới máy chủ, kiểm tra lại kết nối và thử lại!"
                                                );
                                                $("#input").val("");
                                                $("#input").focus();
                                                step = 3;
                                            },
                                        });
                                        $.ajax({
                                            url: "/XuatLine/Luulichsu_Xuatline",
                                            type: "POST",
                                            data: {
                                                tenvattuthuve: inputValue,
                                                tenvattuphatra: "",
                                                soluongxuatline: "0",
                                                nguoixuat: ma_nguoithaotac,
                                                donvi: "",
                                                tontu: "0",
                                                vitri:
                                                    ten_model +
                                                    "," +
                                                    ten_cell +
                                                    "," +
                                                    ten_station,
                                                result: "NG",
                                                lotno: "",
                                                ghichu: "",
                                            },
                                            success: function (result) {
                                                if (result.success) {
                                                    console.log(
                                                        "Completed update log-NG for bdo.lichsuxuatline",
                                                        result.data
                                                    );
                                                } else {
                                                    console.log(
                                                        "Completed update log-NG for bdo.lichsuxuatline",
                                                        result.data
                                                    );
                                                }
                                                step = 3;
                                            },
                                            error: function () {
                                                alert(
                                                    "Không kết nối được tới máy chủ, kiểm tra lại kết nối và thử lại!"
                                                );
                                                $("#input").val("");
                                                $("#input").focus();
                                                step = 3;
                                            },
                                        });
                                        alert(
                                            "Sai mã vật tư thu về - Mã vật tư thu về và tại bảng layout không trùng!"
                                        );
                                        $("#input").val("");
                                        $("#input").focus();
                                        step = 3;
                                    }
                                },
                                error: function () {
                                    alert(
                                        "Không kết nối được tới máy chủ, kiểm tra lại kết nối và thử lại!"
                                    );
                                    $("#input").val("");
                                    $("#input").focus();
                                    step = 3;
                                },
                            });
                        } else {
                            $.ajax({
                                //CẬP NHẬT TRẠNG THÁI NG CHO LAYOUT
                                url: "/XuatLine/updateStatus",
                                type: "POST",
                                data: {
                                    status: "SAI MO",
                                    model: ten_model,
                                    cell: ten_cell,
                                    station: ten_station,
                                    phanloai: ten_phanloai,
                                },
                                success: function (result) {
                                    if (result.success) {
                                        console.log(
                                            "Updated status SAI MO for dbo.layout",
                                            result.data
                                        );
                                    } else {
                                        alert(
                                            "Không cập nhật được bảng Layout, kiểm tra lại dữ liệu!"
                                        );
                                    }
                                    step = 3;
                                },
                                error: function () {
                                    alert(
                                        "Không kết nối được tới máy chủ, kiểm tra lại kết nối và thử lại!"
                                    );
                                    $("#input").val("");
                                    $("#input").focus();
                                    step = 3;
                                },
                            });
                            $.ajax({
                                url: "/XuatLine/Luulichsu_Xuatline",
                                type: "POST",
                                data: {
                                    tenvattuthuve: inputValue,
                                    tenvattuphatra: "",
                                    soluongxuatline: "0",
                                    nguoixuat: ma_nguoithaotac,
                                    donvi: "",
                                    tontu: "0",
                                    vitri:
                                        ten_model +
                                        "," +
                                        ten_cell +
                                        "," +
                                        ten_station,
                                    result: "NG",
                                    lotno: "",
                                    ghichu: "",
                                },
                                success: function (result) {
                                    if (result.success) {
                                        console.log(
                                            "Completed update log-NG for bdo.lichsuxuatline",
                                            result.data
                                        );
                                    } else {
                                        console.log(
                                            "Completed update log-NG for bdo.lichsuxuatline",
                                            result.data
                                        );
                                    }
                                    step = 3;
                                },
                                error: function () {
                                    alert(
                                        "Không kết nối được tới máy chủ, kiểm tra lại kết nối và thử lại!"
                                    );
                                    $("#input").val("");
                                    $("#input").focus();
                                    step = 3;
                                },
                            });
                            alert(
                                "Sai mã vật tư thu về - Mã vật tư thu về và tại bảng layout không trùng!"
                            );
                            $("#input").val("");
                            $("#input").focus();
                            step = 3;
                        }
                    },
                    error: function () {
                        alert(
                            "Không kết nối được tới máy chủ, kiểm tra lại kết nối và thử lại!"
                        );
                        $("#input").val("");
                        $("#input").focus();
                        step = 3;
                    },
                });
            }

            if (step == 4) {
                $.ajax({
                    url: "/XuatLine/CheckingVattuphatra",
                    type: "POST",
                    data: {
                        mavattuphatra: inputValue,
                        status: "SAI MO", //SAI MO
                        model: ten_model,
                        cell: ten_cell,
                        station: ten_station,
                        phanloai: ten_phanloai,
                        nguoixuat: ma_nguoithaotac,
                        vitri: ten_model + "," + ten_cell + "," + ten_station,
                        soluongxuatline: soluongxuatline,
                        donvi: ten_donvi,
                        tontu: so_tontu,
                        lotno: so_lotno,
                    },
                    success: function (result) {
                        if (result.success) {
                            console.log(result.data);
                            if (result.data.mode == "NG") {
                                alert(
                                    "Sai mã vật tư phát ra - Mã vật tư thu về và phát ra không trùng!"
                                );
                                $("#input").val("");
                                $("#input").focus();
                                step = 4;
                            }
                            if (result.data.mode == "OK") {
                                var tenvattuphatra = result.data.dulieu.ten;
                                $("#txtVattuxuatra").val(tenvattuphatra);
                                solanbipXuatra++;
                                if (solanbipXuatra < solancanbip) {
                                    $("#txtVattuxuatra").css({
                                        background: "orange",
                                    });
                                    titleElement.innerHTML =
                                        "<i class='fa fa-wifi fa-fw' aria-hidden='true'></i> QUÉT MÃ VẬT TƯ THU VỀ ";
                                    $("#input").val("");
                                    $("#input").focus();
                                    step = 3;
                                }
                                if (solanbipXuatra == solancanbip) {
                                    $("#txtVattuxuatra").css({
                                        background: "green",
                                        color: "white",
                                    });
                                    titleElement.innerHTML =
                                        "<i class='fa fa-wifi fa-fw' aria-hidden='true'></i> QUÉT MÃ HOÀN THÀNH ";
                                    $("#input").val("");
                                    $("#input").focus();
                                    step = 5;
                                }
                            }
                        }
                    },
                    error: function () {
                        alert(
                            "Không kết nối được tới máy chủ, kiểm tra lại kết nối và thử lại!"
                        );
                        $("#input").val("");
                        $("#input").focus();
                        step = 4;
                    },
                });
            }

            if (step == 5) {
                if (inputValue == "9999") {
                    $.ajax({
                        url: "/XuatLine/Final",
                        type: "POST",
                        success: function () {
                            alert("DONE");
                            window.location.reload();
                        },
                        error: function () {
                            alert(
                                "Không kết nối được tới máy chủ, kiểm tra lại kết nối và thử lại!"
                            );
                            $("#input").val("");
                            $("#input").focus();
                            step = 5;
                        },
                    });
                } else {
                    $("#input").val("");
                    $("#input").focus();
                    step = 5;
                }
            }
        }
    });
});
