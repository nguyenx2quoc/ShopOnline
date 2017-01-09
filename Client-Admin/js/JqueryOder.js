/**
 * Created by asus on 1/9/2017.
 */

$.ajax({
    type: 'GET',
    url:'http://apishoponline.apphb.com/api/Server/hoadon',
    datatype: 'JSON',
    success: function (success) {
        console.log(success);
        var vt = '';
        for (var i = 0; i < success.length; i++)
        {
            vt = vt + ' <tr> <td>'+ success[i].ID + '</td> + <td>'+ success[i].Email + '</td> + <td>' + success[i].SDT +
                '</td> <td>' +
                success[i].TongTien + '</td> + <td>' + success[i].Ngay + '</td> <td>' +
                success[i].TinhTrang+ '</td> + <td>' +
                '<a class="btn btn-info btn-xs" data-toggle="modal" data-target="#popupedit"> <i class="ace-icon fa fa-pencil bigger-120" aria-hidden="true">'
                + '</i> </a> <a class="btn btn-xs btn-danger" data-toggle="modal" data-target="#popupdelete">' +
                '<i class="ace-icon fa fa-trash-o bigger-120" aria-hidden="true"></i>'+
                '</a> </td> </tr>';
        }
        vt = vt + '<script> var t = "";var vr = ""; $(".btn-danger").click(function () {  t = $(this).parents("tr").find("td:eq(0)").html();' +
            'console.log(t);});' +
            '$(".btn-info").click(function(){vr = $(this).parents("tr").find("td:eq(0)").html();' +
            'console.log(vr);' +
            '$("#ID").val($(this).parents("tr").find("td:eq(0)").html());' +
            '$("#diachi").val($(this).parents("tr").find("td:eq(1)").html());' +
            '$("#sdt").val($(this).parents("tr").find("td:eq(2)").html());' +
            '$("#gia").val($(this).parents("tr").find("td:eq(3)").html());' +
            '$("#ngay").val($(this).parents("tr").find("td:eq(4)").html());' +
            '$("#tinhtrang").val($(this).parents("tr").find("td:eq(5)").html());});' +
            '</script>';
        $('#tables').html(vt);
    }
});


$('#Delete').click(function () {
    $.ajax({
        type: 'DELETE',
        url : 'http://apishoponline.apphb.com/api/Server/xoaHD?ID=' + t,
        dataType: 'JSON',
        success: function (data) {
            if(data == true){
                alert("Xóa thành công !");
            }
            else {
            }
            alert("Xóa không thành công !");
        }
    });
});
$('#OK').click(function () {
    $.ajax({
        type : 'PUT',
        url: 'http://apishoponline.apphb.com/api/Server/hoadon?ID=' + $("#ID").val() + '&TrangThai=' +$("#tinhtrang").val(),
        dataType: 'JSON',
        success: function (data) {
            if (data = true){
                alert("Lưu thành công!");
            }
            else {
                alert("Lưu không thành công!");
            }
        }
    });
});