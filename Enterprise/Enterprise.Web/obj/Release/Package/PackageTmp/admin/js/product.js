$(document).ready(function () {
    //等待页面全部加载完后执行
    getCategory();
    getProduct();
});



function getProduct() {
    var id = getUrlParam("id");
    if (id != "0") {
        var url = "/admin/api/productApi.aspx";
        var d = {
            op: "getproduct",
            id: id
        }

        ajax(url, d, function (data) {
            $("input[name=Name]").val(data.Name);
            if (data.Status == 0) {
                $("#rdoNo").prop("checked", true);
            } else {
                $("#rdoYes").prop("checked", true);
            }

            $("#ProImg").attr("src", data.ImgUrl)
            $("#slCategory").val(data.CategoryId);


        })


    }

}


function getCategory() {
    var url = "/admin/api/categoryApi.ashx";
    ajax(url, null, function (list) {
        var html = "";
        if (list) {
            for (var i = 0; i < list.length; i++) {
                html += '<option value="' + list[i].CategoryId + '">' + list[i].Name + '</option>'
            }
        }
        $("#slCategory").empty().append(html);

    })


}

