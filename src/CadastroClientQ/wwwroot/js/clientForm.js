$(document).ready(function () {
    var table = $('#dataTableClients').DataTable({
        responsive: true,
        autoWidth: true,
        lengthMenu: [[10, 25, 50, 100, -1], [10, 25, 50, 100, "Todos"]],
        language: {
            "sUrl": "../../../media/Portuguese-Brasil.json",
        },
        order: [[1, 'asc']]
    });
});

function openModalAddClient() {
    $("#modalAddClient").modal('show');
}