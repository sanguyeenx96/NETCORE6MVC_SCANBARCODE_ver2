$("#btnUpload").click(function () {
    const steps = ["1", "2"];
    const Queue = Swal.mixin({
        progressSteps: steps,
        confirmButtonText: "Tiếp tục",
        showClass: { backdrop: "swal2-noanimation" },
        hideClass: { backdrop: "swal2-noanimation" },
    });
    // Gọi hàm fetchData và sử dụng Promise chaining
    fetchData()
        .then(function (idModel) {
            $.ajax({
                url: "/Soft/GetListNameSoft",
                data: { modelId: idModel },
                method: "GET",
                success: function (data) {
                    const tenphanmem = data;
                    const inputOptions = {};
                    tenphanmem.forEach((tenphanmem) => {
                        inputOptions[tenphanmem.id] = tenphanmem.name;
                    });
                    return Queue.fire({
                        title: "Chọn phần mềm",
                        input: "select",
                        inputOptions: inputOptions,
                        currentProgressStep: 1,
                        confirmButtonText: "OK",
                        showClass: { backdrop: "swal2-noanimation" },
                    }).then(function (result) {
                        if (result.isConfirmed) {
                            var ModelId = idModel;
                            var SoftId = result.value;
                            $("#modalThemphanmemmoi").data("idmodel", ModelId);
                            $("#modalThemphanmemmoi").data("idphanmem", SoftId);
                            $("#modalThemphanmemmoi").modal("show");
                            // Gọi hàm để tải script UploadSoft.js
                            loadUploadSoftScript();
                        } else {
                            reject("Hủy bỏ");
                        }
                    });
                },
                error: function () {
                    reject("Lỗi máy chủ");
                },
            });
        })
        .catch(function (error) {
            Swal.fire("", "Thao tác đã được huỷ bỏ!", "error");
        });

    // Hàm fetchData trả về một Promise
    function fetchData() {
        return new Promise(function (resolve, reject) {
            $.ajax({
                url: "/Model/GetSelectListChildrenModels",
                method: "GET",
                success: function (data) {
                    const models = data;
                    const inputOptions = {};
                    models.forEach((model) => {
                        inputOptions[model.id] = model.name;
                    });
                    Queue.fire({
                        title: "Chọn Model của phần mềm",
                        input: "select",
                        inputOptions: inputOptions,
                        currentProgressStep: 0,
                        showClass: { backdrop: "swal2-noanimation" },
                    }).then(function (result) {
                        if (result.isConfirmed) {
                            var idModel = result.value;
                            resolve(idModel);
                        } else {
                            reject("Hủy bỏ");
                        }
                    });
                },
                error: function () {
                    reject("Lỗi máy chủ");
                },
            });
        });
    }
});

function loadUploadSoftScript() {
    var script = document.createElement("script");
    script.src = "/Scripts/UploadSoft.js";
    script.type = "text/javascript";
    document.body.appendChild(script);
}
$("#modalThemphanmemmoi").on("hidden.bs.modal", function (e) {
    window.location.reload();
});