var loadiPopup;
//  ajaxURL:AJAX传输连接
//  ParametersData：传输的参数 
//如：   PostParameter1: Parameter1,
//   PostParameter2: Parameter2,
//    PostParameter3: Parameter3,
//functionName  执行成功后 执行的方法
//有加载效果
function ajax(ajaxURL, ParametersData, functionName, dataTypedata,ajaxType) {


    if (typeof (dataTypedata) == "undefined") {
        dataTypedata = "json";
    }

    if (typeof (ajaxType) == "undefined") {
        ajaxType = "POST";
    }


    var loadiPopup = layer.load();

    $.ajax({ type: ajaxType, url: ajaxURL, //+ 'r=' + Math.random()
        data: ParametersData,
        cache: false,
        async: true, //是否异步 
        dataType: dataTypedata,
        success: function(msg) {

            layer.close(loadiPopup);
            functionName(msg);

        },
        error: function(XMLHttpRequest, textStatus, errorThrown) {

            layer.close(loadiPopup);
            if (XMLHttpRequest.readyState == "0") { return; }
            alert("数据异常.请联系管理员." );

        }
    });



}

//  ajaxURL:AJAX传输连接
//  ParametersData：传输的参数 
//如：   PostParameter1: Parameter1,
//   PostParameter2: Parameter2,
//    PostParameter3: Parameter3,
//functionName  执行成功后 执行的方法
//无加载效果
function ajaxNoEffect(ajaxURL, ParametersData, functionName, dataTypedata) {

    if (typeof (dataTypedata) == "undefined") {
        dataTypedata = "json";
    }

    $.ajax({ type: "post", url: ajaxURL,
        cache: false,
        async: true,
        data: ParametersData
        , dataType: dataTypedata, success: function(msg) {


            functionName(msg);
        },
        error: function(msg) { alert('获取数据异常!'); }
    });
}


//获取数据
function getData(data) {
    return data;
}

///Ajax获取数据
///data:参数数组
///url:链接地址
function AJAXToGetData(ParametersData, ajaxURL, dataTypedata) {

    if (typeof (dataTypedata) == "undefined") {
        dataTypedata = "json";
    }
    var loadi = layer.load('加载中…');
    var result = "";
    $.ajax({
        type: "POST",
        url: ajaxURL,
        cache: false,
        async: false, //是否异步 
        data: ParametersData,
        dataType: dataTypedata,
        success: function(data) {
            layer.close(loadi);
            result = data;
        },
        error: function(ex) {
            layer.close(loadi);
            alert(ex)
        }
    })
    return result;
}