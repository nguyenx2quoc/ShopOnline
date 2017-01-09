

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
})
//2 '</td> + <td>'+ success[i].CT_ID +
//4,5  success[i].CT_SoLuong + '</td> + <td>' +success[i].CT_Gia + '</td> <td>' + success[i].CT_Size+ '</td> <td>' +

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
            'url : "http://apishoponline.apphb.com/api/Server/getsptheoid?IDCTMH=" + vr,' +
            'type: "GET",' +
            'success: function(response) { console.log(response);' +
            '$("#IDe").val(response[0].CT_ID);' +
            '$("#IDMHe").val(response[0].MH_ID);' +
            '$("#TenMHe").val(response[0].MH_TenMH);' +
            '$("#mausace").val(response[0].CT_MauSac);' +
            '$("#sizee").val(response[0].CT_Size);' +
            '$("#soluonge").val(response[0].CT_SoLuong);' +
            '$("#gioitinhe").val(response[0].CT_Loai);' +
            '$("#giae").val(response[0].CT_Gia);' +
            '$("#loaispe").val(response[0].MH_IDSubLoaiHang);' +
            '$("#urlhae").val(response[0].MH_URLHinhAnh1);' +
            '$("#urlha1e").val(response[0].MH_URLHinhAnh2);' +
            '$("#urlha2e").val(response[0].MH_URLHinhAnh3);' +
            '$("#motae").val(response[0].CT_MoTa);' +
            ' }' +
            '});});' +
            '$(".btn-success").click(function(){vr = $(this).parents("tr").find("td:eq(0)").html();' +
            'console.log(vr); $("#IDMH").val($(this).parents("tr").find("td:eq(0)").html());' +
           '});' +
            '$("#Delete").click(function () {  $.ajax({  type: "DELETE",  url : ' +
            '"http://apishoponline.apphb.com/api/Server/xoaCTMH?IDCTMH=" + t, dataType: "JSON",' +
            ' success: function (data) { if(data == true){   alert("Xóa thành công!");}' +
            ' else {  alert("Xóa không thành công!"); }}});});'+
            '</script>';
        $('#tableds').html(vt);
    }
});


//
// $('#Delete').click(function () {
//     $.ajax({
//         type: 'DELETE',
//         url : 'http://apishoponline.apphb.com/api/Server/xoaCTMH?IDCTMH=' + t,
//         dataType: 'JSON',
//         success: function (data) {
//             if(data == true){
//                 alert("Xóa thành công!");
//             }
//             else {
//                 alert("Xóa không thành công!");
//             }
//         }
//     });
// });



$('#OKEdit').click(function () {
    $.ajax({
        type : 'PUT',
        url : 'http://apishoponline.apphb.com/api/Server/capnhatMH',
        datatype: 'JSON',
        data: {
            MH_ID : $('#IDMHe').val(),
            MH_STATUS : true,
            MH_TenMH: $('#TenMHe').val(),
            MH_IDSubLoaiHang : $('#loaispe').val(),
            MH_URLHinhAnh1: $('#urlhae').val(),
            MH_URLHianhAnh2: $('#urlha1e').val(),
            MH_URLHinhAnh3: $('#urlha2e').val(),
            CT_ID : $('#ID').val(),
            CT_MoTa : $('#motae').val(),
               CT_MauSac: $('#mausace').val(),
               CT_Size: $('#sizee').val(),
               CT_Loai : $('#loaispe').val(),
            CT_STATUS : true,
               CT_SoLuong : $('#soluonge').val(),
            },
        success: function (data) {
            if (data == true){
                alert("Lưu thành công!");
            }
            else {
                alert("Lưu thất bại!");
            }
        }
    });

});






$('#OK').click(function () {
    $.ajax({
        type : 'POST',
        url : 'http://apishoponline.apphb.com/api/Server/themMH',
        datatype: 'JSON',
        data: {
            TenMH: $('#TenMH').val(),
            IDSubLoaiHang : $('#loaisp').val(),
            URLHinhAnh1: $('#urlha').val(),
            URLHianhAnh2: $('#urlha1').val(),
            URLHinhAnh3: $('#urlha2').val(),
//                MoTa : $('#mota').val(),
//                MauSac: $('#mausac').val(),
//                Size: $('#size').val(),
//                Loai : t,
//                SoLuong : $('#soluong').val(),
        },
        success: function (data) {
            if (data == true){
            }
            else {
                alert("Lưu thất bại!");
            }
        }
    });
});
