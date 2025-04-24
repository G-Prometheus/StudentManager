$(document).ready(function () {
 
    // Thêm sự kiện click cho các nút xóa
    $('table').on('click', '.btn-danger', function (e) {
        e.preventDefault();

        var url = $(this).attr('href');
        Delete(url);
    });
});

function Delete(url) {
    Swal.fire({
        title: "Bạn có chắc muốn xóa?",
        text: "Bạn sẽ không thể khôi phục lại dữ liệu này!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Vâng, xoá nó!",
        cancelButtonText: "Hủy"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        // Reload trang sau khi xóa thành công
                        location.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}