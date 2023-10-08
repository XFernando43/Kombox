var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        LoadDataTable("inprocess");
    } else {
        if (url.includes("pending")) {

            LoadDataTable("pending");
        } else {
            if (url.includes("completed")) {
                LoadDataTable("completed");
            } else {
                if (url.includes("approved")) {
                    LoadDataTable("approved");
                } else {
                    LoadDataTable("all"); 
                }
            }
        }
    }
});

function destroyDT() {
    if ($.fn.DataTable.isDataTable('#TblOrders')) {
        $('#TblOrders').DataTable().destroy();
    }
}

function LoadDataTable(status) {
    dataTable = $('#TblOrders').DataTable({
        "ajax": { url: '/Admin/Order/GetAll?status='+status },
        "columns": [
            { data: 'orderHeaderId', "width": "5%" },
            { data: 'applicationUser.name', "width": "25%" },
            { data: 'phoneNumber', "width": "20%" },
            { data: 'applicationUser.email', "width": "20%" },
            { data: 'orderStatus', "width": "10%" },
            { data: 'orderTotal', "width": "10%" },
            {
                data: null,
                "render": function (data, type, row) {
                    return `<a href="/Admin/Order/Details?OrderId=${data}" class="btn btn-success mx-2">VIEW</a>`;
                }
            }


        ]
    });

}

//onclick="confirmDelete()"