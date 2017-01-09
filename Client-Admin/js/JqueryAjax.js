

$.ajax({
    type: 'GET',
    url: 'http://apishoponline.apphb.com/api/Server/getsub',
    success: function (response) {
        var subLH = '<select id="loaispe">'
        for (var i =0; i < response.length; i++){
            subLH = subLH + '<option value="' + response[i].ID +'">' + response[i].TenLoai + '</option>'
        }
        subLH = subLH + '</select>'
        $('#loaispe').html(subLH);
    }
});

$.ajax({
    type: 'GET',
    url:'http://apishoponline.apphb.com/api/Server/getmhvasub',
    datatype: 'JSON',
    success: function (success) {
        console.log(success);
        var vt = '';
        for (var i = 0; i < success.length; i++)
        {
            vt = vt + ' <tr> <td>'+ success[i].MH_ID +  '</td> + <td>' + success[i].MH_TenMH +
                '</td> <td>' +
                success[i].S_TenLoai+ '</td> + <td>'+
            '<a class="btn btn-info btn-xs" data-toggle="modal" data-target="#popupedit"> <i class="ace-icon fa fa-pencil bigger-120" aria-hidden="true">'
            + '</i> </a> <a class="btn btn-xs btn-danger" data-toggle="modal" data-target="#popupdelete">' +
                '<i class="ace-icon fa fa-trash-o bigger-120" aria-hidden="true"></i>'+
            '</a>  ' +
            '<a class="btn btn-xs btn-success" data-toggle="modal" data-target="#popupadd">' +
            '<i class="fa fa-fw fa-plus" aria-hidden="true"></i>'+
            '</a> </td> </tr>';
        }
        vt = vt + '<script> var t = "";var vr = ""; $(".btn-danger").click(function () {  t = $(this).parents("tr").find("td:eq(0)").html();' +
            'console.log(t);});' +
            '$(".btn-info").click(function(){vr = $(this).parents("tr").find("td:eq(0)").html();' +
            'console.log(vr);' +
            '$.ajax({' +
            'url : "http://apishoponline.apphb.com/api/Server/getmathangtheoid?IDMH=" + vr,' +
            'type: "GET",' +
            'success: function(response) { console.log(response);' +
            '$("#idmhe").val(response[0].MH_ID);' +
            '$("#tenmhe").val(response[0].MH_TenMH);' +
            '$("#loaispe").val(response[0].MH_IDSubLoaiHang);' +
            '$("#urlhae").val(response[0].MH_URLHinhAnh1);' +
            '$("#urlha1e").val(response[0].MH_URLHinhAnh2);' +
            '$("#urlha2e").val(response[0].MH_URLHinhAnh3);' +
            ' }' +
            '});});' +
            '$(".btn-success").click(function(){vr = $(this).parents("tr").find("td:eq(0)").html();' +
            'console.log(vr); $("#IDMH").val($(this).parents("tr").find("td:eq(0)").html());' +
           '});' +
            '$("#Delete").click(function () {  $.ajax({  type: "DELETE",  url : ' +
            '"http://apishoponline.apphb.com/api/Server/xoaMH?IDMH=" + t, dataType: "JSON",' +
            ' success: function (data) { if(data == true){   alert("Xóa thành công!");}' +
            ' else {  alert("Xóa không thành công!"); }}});});'+

            '$("#OK").click(function () { '+
            '$.ajax({' +
            'type : "POST",' +
            'url : "http://apishoponline.apphb.com/api/Server/themCTMH",'+
            'datatype: "JSON",'+
            'data: {'+
            'IDMatHang:$("#IDMH").val(),'+
            'STATUS: true,'+
            'Size: $("#size").val(),'+
            'Gia: $("#gia").val(),'+
            'Loai: $("#gioitinh").val(),'+
            'SoLuong: $("#soluong").val(),'+
            'MauSac: $("#mausac").val(),'+
            'MoTa: $("#mota").val() },'+
            'success: function (data) {'+
            'if (data == true){ alert("Lưu thành công!");}'+
            'else {alert("Lưu thất bại!");}}});});'+

            '$("#OKEditMH").click(function () { '+
                '$.ajax({' +
                    'type : "PUT",' +
                    'url : "http://apishoponline.apphb.com/api/Server/putMH",'+
                    'datatype: "JSON",'+
                    'data: {'+
                       'ID : $("#idmhe").val(),'+
                        'STATUS : true,'+
                        'TenMH: $("#tenmhe").val(),'+
                        'IDSubLoaiHang : $("#loaispe").val(),'+
                        'URLHinhAnh1: $("#urlhae").val(),'+
                        'URLHinhAnh2: $("#urlha1e").val(),'+
                        'URLHinhAnh3: $("#urlha2e").val()},'+
                    'success: function (data) {'+
                        'if (data == true){ alert("Lưu thành công!");}'+
                        'else {alert("Lưu thất bại!");}}});});'+

            '</script>';
        $('#tableds').html(vt);
    }
});










