(function () {
    var load;
window.app = {
        conn: function () {
            var networkState = navigator.connection.type;

        var states = {};
        states[Connection.UNKNOWN] = 'Unknown connection';
        states[Connection.ETHERNET] = 'Ethernet connection';
        states[Connection.WIFI] = 'WiFi connection';
        states[Connection.CELL_2G] = 'Cell 2G connection';
        states[Connection.CELL_3G] = 'Cell 3G connection';
        states[Connection.CELL_4G] = 'Cell 4G connection';
        states[Connection.CELL] = 'Cell generic connection';
        states[Connection.NONE] = 'No network connection';

            //alert('Connection type: ' + states[networkState]);
            return networkState;
        },
        loadhide: function (loading) {
            //$ionicLoading
            loading.hide();
        },
        loadshow: function (loading) {
            load =loading;
        loading.show({
            // templateUrl: "templates/person/templet.html",
           //template: "请稍后...",
           //animation: 'fade-in',
            width: 100,
            height: 100,
            delay: 1,
            showBackdrop: false,
            
        })


    },
    alert: function (ionicPopup, text) {
        //$ionicPopup
        ionicPopup.alert({
            title: '提示',
            template: text
        });
    },
    confirm: function (ionicPopup, text, y, n, callback) {
        //$ionicPopup
        ionicPopup.confirm({
            title: '提示',
            template: text,
            okText: y, // String (默认: 'OK')。OK按钮的文字。
            okType: '', // String (默认: 'button-positive')。OK按钮的类型。
            templateUrl: '', // String (可选)。放在弹窗body内的一个html模板的URL。
            cancelText: n, // String (默认: 'Cancel')。一个取消按钮的文字。
            cancelType: 'button-default', // String (默认: 'button-default')。取消按钮的类型。

        }).then(function (res) {
            callback && callback(res);

        });

    }
}
    window.util = {
        constant: {
            CLICK_TO_SET_USER_NAME: "点击设置用户昵称",
            CLICK_TO_SET_USER_CONTACT: "点击设置联系方式",
            CLICK_TO_SET_USER_ADDRESS: "点击设置地址"
        },
        alert: function (message, callback, title, buttonName) {
            if (navigator && navigator.notification && navigator.notification.alert) {
                //if(false){
                navigator.notification.alert(message, callback, title, buttonName);
            } else {
                alert(message);
                callback && callback();
            }
        },
        confirm: function (message, callback, title, buttonNames) {
            if (navigator && navigator.notification && navigator.notification.confirm) {
                //if(false){
                navigator.notification.confirm(message, callback, title, buttonNames);
            } else {
                var b = confirm(message);
                b && (callback && callback(2));
                b || (callback && callback(1));
            }
        },
        POST_ERROR: "POST_ERROR",
        post: function (url, data, callback) {
            
            if (window.Connection) {
           
                if (navigator.connection.type != undefined) {
                    if (app.conn() == Connection.NONE || app.conn() == Connection.UNKNOWN) {
                       
                        util.alert("没有网络", null, "提示", "返回")
                        if (load != undefined) {
                            load.hide()
                        }
                        return;
                    }
                }
            }

            $.ajax({
                url: url,
                type: "post",
                data: data || {},
                dataType: "json",
                async: true,
                cache: false,
                success: function (rtn) {
                    callback && callback(rtn);
                },
                error: function (o, r, m) {
                    console.log("ajax post error:" + r + "," + m);
                    callback && callback(util.POST_ERROR);
                }
            });
        },
        GET_ERROR: "GET_ERROR",
        get: function (url, params, callback) {
             
            if (window.Connection) {

              
                if (navigator.connection.type != undefined) {
                 
                    if (app.conn() == Connection.NONE || app.conn() == Connection.UNKNOWN)
                    {
                        if (load != undefined)
                        {
                            load.hide()
                    }
                      
                        util.alert("没有网络",null,"提示","返回")
                        return;
                    }
                }
            }
            $.ajax({
                url: url,
                type: "get",
                data: params || {},
                dataType: "json",
                async: true,
                cache: false,
                success: function (rtn) {
                    callback && callback(rtn);
                },
                error: function (o, r, m) {
                    console.log("ajax get error:" + r + "," + m);
                    callback && callback(util.GET_ERROR);
                }
            });
        },
        setLocalData: function (key, value) {
            localStorage.setItem(key, value);
        },
        getLocalData: function (key) {
            return localStorage.getItem(key);
        },
        delLocalData: function (key) {
            localStorage.removeItem(key);
        },
        showImg: function (src) {
            var $imgBg = $("#div_show_img_bg");
            $imgBg.html('<img src="' + src + '" style="width:100%;"/>').show().off("click").on("click", function () {
                $imgBg.hide();
            }).find("img").on("load", function () {
                var $img = $(this);
                $img.css({ "margin-top": ($(window).height() - $img.height()) / 2 + "px" });
            });
        },
        download: function (url, name) {
            window.open(encodeURI(url), "_blank");
            //navigator.app.loadUrl(encodeURI(url), { openExternal:true});
            /*
             window.requestFileSystem(LocalFileSystem.PERSISTENT, 0, function(fileSystem){

             var date = new Date();
             var time = date.getHours() + "_" + date.getMinutes() + "_" + date.getSeconds();

             var targetPath = "file_mobile/download/" + time;
             var targetFile = targetPath + "/" + name;

             //创建目录
             fileSystem.root.getDirectory(targetPath, {create:true}, function(fileEntry){
             //创建文件
             fileSystem.root.getFile(targetFile, {create:true}, function(fileEntry){

             var fileTransfer = new FileTransfer();
             var uri = encodeURI(url);

             //下载文件
             fileTransfer.download(uri, targetUrl, function(entry){
             util.alert("下载成功", null, '提示', '返回');
             },function(error){
             util.alert("下载失败", null, '提示', '返回');
             });

             },function(){
             util.alert("创建文件失败", null, '提示', '返回');
             });
             },
             function(){
             util.alert("创建目录失败", null, '提示', '返回');
             });
             });
             */
        },
        getPosition: function (callback) {
            console.log('getPosition11:');
            if (navigator && navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    var str = '' +
                        'Latitude: ' + position.coords.latitude + '<br />' +
                        'Longitude: ' + position.coords.longitude + '<br />' +
                        'Altitude: ' + position.coords.altitude + '<br />' +
                        'Accuracy: ' + position.coords.accuracy + '<br />' +
                        'Altitude Accuracy: ' + position.coords.altitudeAccuracy + '<br />' +
                        'Heading: ' + position.coords.heading + '<br />' +
                        'Speed: ' + position.coords.speed + '<br />' +
                        'Timestamp: ' + new Date(position.timestamp) + '<br />';

                    console.log('getPosition2222:');
                    console.log(str);

                    callback && callback({
                        "longitude": position.coords.longitude,
                        "latitude": position.coords.latitude
                    });

                }, function (error) {
                    callback && callback(null);
                    throw new Error("获取经纬度失败，code:" + error.code + ",message:" + error.message);
                }, { maximumAge: 3000, timeout: 5000, enableHighAccuracy: true });
            } else {
                callback && callback(null);
                throw new Error("获取经纬度失败，navigator不存在！");
            }
        },
        quit: function () {
            util.delLocalData(KEY_AUTO_LOGIN_STATUS);
            util.delLocalData(KEY_AUTO_LOGIN_INFO);
            setTimeout(function () {
                window.location.href = "index.html";
            }, 10);
        },
        open: function (biz_type, id) {
            if (biz_type == null || id == null) {
                return;
            }
            console.log('fuying 555555:' + id);
            if (biz_type === '1') { //业务类型 1 ，代表信息详情
                var str = "#/tab/message-view/" + id;
                //alert(str);
                window.location.href = str;
            }
        },
        onGetBootOption: function (data) {
            console.log('fuying 777777777777:' + data);
            try {
                if (data != null) {
                    console.log("tonglian:getBootOption biz_type is " + data[0]);
                    console.log("tonglian:getBootOption2 id " + data[1]);
                    util.open(data[0], data[1]);
                }
            } catch (exception) {
                console.log('ferror:' + exception);
            }

        },/*,
        historyBack: function () {
            window.history.back();
        }*/
    
        
    };

})();