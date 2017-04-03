//--------↓↓↓------导入导出---------------------
function ImportInfo(downFileUrl) {
    $("#importform").ajaxSubmit({
        // async:false,
        success: function (result) { // data 保存提交后返回的数据，一般为 json 数据
            var obj = document.getElementById("importform");
            obj.outerHTML = obj.outerHTML;
            if (result.Type == "Fail") {
                post(downFileUrl, result);
            }
            Alert(result.Content);
            $("#loading").modal("hide");
        }
    });

}
//数据导出方法
function ExcelOut(url) {
    Confirm("确定导出当前数据吗？<br/>备注:导出的文件默认保存在浏览器的下载目录中,注意查收！", function (res) {
        if(res)
        {
            posturl(url, $("#searchForm").serialize());
        }
    })
    //if (confirm("确定导出当前数据吗？<br/>备注:导出的文件默认保存在浏览器的下载目录中,注意查收！"))
    //{
    //    posturl(url, $("#searchForm").serialize());
    //} 
}
//--------↑↑↑↑↑------导入导出---------------------

function post(url, data) {
    var temp = document.createElement("form");
    temp.action = url;
    temp.method = "post";
    temp.style.display = "none";
    for (var x in data) {
        var opt = document.createElement("input");
        opt.name = x;
        opt.value = data[x] == null ? "" : data[x];
        temp.appendChild(opt);
    }
    document.body.appendChild(temp);
    temp.submit();
    return temp;
}
//post提交当前数据
function posturl(url, params) {
    params = decodeURIComponent(params, true);
    var reg = new RegExp("%2C", "g");
    params = params.replace(reg, ',');
    var string = params.split('&');
    var data = {};
    for (var i = 0; i < string.length; i++) {
        var str = string[i].split('=');
        data[str[0]] = str[1];
    }
    var temp = document.createElement("form");
    temp.action = url;
    temp.method = "post";
    temp.style.display = "none";
    for (var x in data) {
        var opt = document.createElement("input");
        opt.name = x;
        opt.value = data[x] == null ? "" : data[x];
        temp.appendChild(opt);
    }
    document.body.appendChild(temp);
    temp.submit();
    return temp;
}


//--------↓↓↓↓-------机构树加载方法-----------------
var setting_check = {
    check: {
        enable: true
    },
    data: {
        simpleData: {
            enable: true
        }
    },
    callback: {

    }
};
var setting_radio = {
    check: {
        enable: true,
        chkStyle: "radio",
        radioType: "all"
    },
    data: {
        simpleData: {
            enable: true
        }
    },
    view: {
        dblClickExpand: false
    },
    callback: {
        //onCheck: oncheck,
        //beforeClick: beforeClick,

    }
};

 
//首页加载tree
var orgtree = [];

function loadtree(Id, setting, data) {
    $.fn.zTree.init($("#" + Id), setting, data);
}
function showtree(Id) {
    RangeClear("BasicTree");
    $('#' + Id).modal('show');

}
//清空树选项
function RangeClear(Id) {
    var treeObj = $.fn.zTree.getZTreeObj(Id);
    treeObj.checkAllNodes(false);

}
function GetCheckRadioVal(Id)
{
    var zTree = $.fn.zTree.getZTreeObj("BasicTree"),
      nodes = zTree.getCheckedNodes(true);
    return nodes;
}
function SaveContent(Id) {

    var zTree = $.fn.zTree.getZTreeObj(Id),
       nodes = zTree.getCheckedNodes(true),
       v = "",
       SendObject = "";

    var str = "";
    var data = [];
    var nochildren = [];
    var data1 = [];
    var data2 = []; //全选只有最上级的
    for (var i = 0, l = nodes.length; i < l; i++) {
        if (nodes[i].check_Child_State == 2) {
            data1 = data1.concat(nodes[i])
            data = data.concat(nodes[i].children);
        }
        if (!nodes[i].open) {
            nochildren.push(nodes[i]);
            v += nodes[i].name + ",";
            var type = typeof (nodes[i].id);
            var Id;
            if (type == typeof (""))
            {
                Id = "'" + nodes[i].id + "'";
            } else {
                Id = nodes[i].id;
            }
            SendObject += Id + ",";
        }
    }
    if (SendObject.length > 0) SendObject = SendObject.substring(0, SendObject.length - 1);

    var bydata1 = [];
    for (var i = 0; i < data1.length; i++) {
        var index = data.indexOf(data1[i]);
        if (index < 0) {
            bydata1.push(data1[i]);
        }
    }
    $.each(nochildren, function (index, value) {
        var index = data.indexOf(value);
        if (index < 0) {
            bydata1.push(value);
        }
    });
    $.each(bydata1, function (index, value) {
        if (str.indexOf(value.name) < 0) {
            str += value.name + ",";
        }

    });
    //console.log(nodes[0].check_Child_State)
    if (nodes[0] == null) {
        SendObject = "";
        str = "";
    }
    str = str.substr(0, str.length - 1);
    console.log(SendObject);
    console.log(str);
    return { IdStr: SendObject,Content:str }
   // $('#SearchTree').modal('hide');
}
//--------↑↑↑↑-------机构树加载方法-----------------

/*数据处理*/
function JsonToJson(data) {
    var reg = new RegExp('&quot;', 'g');
    data = data.replace(reg, '"');
    return JSON.parse('' + data + '');
}

//function Alert(msg) {
//    alert(msg);
//}
function Alert(msg, isreload) {
    var message = '<div style="display:flex;"><i class="glyphicon glyphicon-ok" style="font-size:40px;color:green;"></i><p style="line-height:40px;margin:0 10px;">' + msg + '</p></div>';

    if (msg.indexOf("失败") > -1) {
        message = '<div style="display:flex;"><i class="glyphicon glyphicon-remove" style="font-size:40px;color:red"></i><p style="line-height:40px;margin:0;">' + msg + '</p></div>';
    }
    if (msg.indexOf("有误") > -1) {
        message = '<div style="display:flex;"><i class="glyphicon glyphicon-remove" style="font-size:40px;color:red"></i><p style="line-height:40px;margin:0;">' + msg + '</p></div>';
    }
    bootbox.alert({
        buttons: { ok: { label: '确定', className: 'btn' } },
        message: message,
        callback: function (rtn) {
            $(".modal-backdrop").hide();
            switch (isreload) {
                case undefined:
                    LayoutAjaxRefresh();
                    break;
                case -1:
                    location.reload();
                    break;
                default:
                    break;
            }
            //if (isreload == null)
            //    LayoutAjaxRefresh();
        },
        title: '系统提示'
    });
}
function Alert_State(msg, state, isreload) {
    var icon = "";
    var color = "";
    switch (state) {
        case 1:
            icon = "glyphicon glyphicon-ok",
                color = "green";
            break;
        case 0:
            icon = "glyphicon glyphicon-remove",
            color = "red";
            break;
    }
    console.log(icon + "___" + color + "__" + state);
    var message = '<div style="display:flex;"><i class="' + icon + '" style="font-size:40px;color:' + color + ';"></i><p style="line-height:40px;margin:0 10px;">' + msg + '</p></div>';

    bootbox.alert({
        buttons: { ok: { label: '确定', className: 'btn' } },
        message: message,
        callback: function (rtn) {
            switch (isreload) {
                case 1:
                    LayoutAjaxRefresh();
                    break;
                case 2:
                    location.reload();
                    break;
                default:
                    break;
            }
        },
        title: '系统提示'
    });
}

//可选框
function Confirm(msg, callback) {
    bootbox.confirm({
        buttons: {
            confirm: {
                label: '确定',
                className: 'btn'
            },
            cancel: {
                label: '取消',
                className: 'btn'
            }
        },
        message: '<div style="display:flex;"><span class="glyphicon glyphicon-question-sign" style="font-size:40px;color:yellow"></span><p style="line-height:40px;margin:0 10px;">' + msg + '</p></div>',
        callback: function (result) {
            callback.call(this, result);
        },
        title: '系统提示'
    });

}
function ConfirmSureAlert(msg, callback) {
    bootbox.alert({
        buttons: {
            ok: {
                label: '确定',
                className: 'btn'
            }
        },
        message: '<div style="display:flex;"><span class="glyphicon glyphicon-question-sign" style="font-size:40px;color:yellow"></span><p style="line-height:40px;margin:0 10px;">' + msg + '</p></div>',
        callback: function (result) {
            callback.call(this, result);
        },
        title: '系统提示'
    });

}
/*数据处理*/
