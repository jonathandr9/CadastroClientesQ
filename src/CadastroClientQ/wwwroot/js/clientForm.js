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

    
    $("#stateSelect").change(function () {
        var id = $(this).find(':selected').val();

        onStateSelected(id);
    });
});

function openModalAddClient() {
    $("#modalAddClient").modal('show');
}

function onStateSelected(idState) {

    var urlMetodo = baseUrl + `/Client/GetCities?stateId=${idState}`;

    $.ajax({
        url: urlMetodo,
        dataType: "json",
        type: "GET",
        success: function (result) {
            var $dropdown = $("#citySelect");
            $dropdown.append($("<option />").val("").text(""));
            $.each(result, function () {
                $dropdown.append($("<option />").val(this.id).text(this.description));
            });
            $("#citySelect").prop('disabled', false)
        }
    });

}

function addClient() {

    var dados = {
        name: $("#inputName").val(),
        age: parseInt($("#inputAge").val()),
        sex: parseInt($("#sexSelect").val()),
        stateId: parseInt($("#stateSelect").val()),
        StateDescription: $("#stateSelect").find(':selected').html(),
        cityId: parseInt($("#citySelect").val()),
        cityDescription: $("#citySelect").find(':selected').html()
    };

    var urlMetodo = baseUrl + '/Client/AddClient';

    $.ajax({
        url: urlMetodo,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        data: JSON.stringify(dados),
        success: function (result) {
            if (result.type == "success") {
                alert("Client Cadastrado com Sucesso!");
                //hideModalAddModel();
                setTimeout(function () { window.location.reload() }, 2000);
            } else {
                alert(result.message);
            }
        }
    });
}

function openModelUpdate(
    id,
    name,
    age,
    sex,
    state,
    city) {


    $("#inputNameUpdate").val(name);
    $("#inputAgeUpdate").val(age);
    $("#sexSelectUpdate").val(sex);
    $("#stateSelectUpdate").val(state);
    $("#idClientUpdateModal").val(id);
    $("#titleModalUpdateModel").html(`Atualizar Cliente ${id}`);
    
    var urlMetodo = baseUrl + `/Client/GetCities?stateId=${state}`;

    $.ajax({
        url: urlMetodo,
        dataType: "json",
        type: "GET",
        success: function (result) {
            var $dropdown = $("#citySelectUpdate");
            $dropdown.append($("<option />").val("").text(""));
            $.each(result, function () {
                $dropdown.append($("<option />").val(this.id).text(this.description));
            });
            $("#citySelectUpdate").prop('disabled', false)
            $("#citySelectUpdate").val(city);
            $("#modalUpdateClient").modal('show');
        }
    });

}

function updateClient() {

    $(".loading").show();


    var dados = {
        id: $("#idClientUpdateModal").val(),
        name: $("#inputNameUpdate").val(),
        age: parseInt($("#inputAgeUpdate").val()),
        sex: parseInt($("#sexSelectUpdate").val()),
        stateId: parseInt($("#stateSelectUpdate").val()),
        stateDescription: $("#stateSelectUpdate").find(':selected').html(),
        cityId: parseInt($("#citySelectUpdate").val()),
        cityDescription: $("#citySelectUpdate").find(':selected').html()
    };

    var urlMetodo = baseUrl + '/Client/UpdateClient';

    $.ajax({
        url: urlMetodo,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        data: JSON.stringify(dados),
        success: function (result) {
            if (result.type == "success") {
                alert(result.message);
                hideModalUpdateModel();
                setTimeout(function () { window.location.reload() }, 2000);
            } else {
                alert(result.message);
            }
        }
    });
}


function openModalDelete(idModel) {
    $("#titleModalConfirmAction").html(`Excluir Cliente ${idModel}`);
    $("#textBodyModalConfirmAction").html('Confirma a exclusão do Client ?');

    $("#confirmButtonModalConfirmAction").attr("onclick", `deleteClient(${idModel})`);
    $("#cancelButtonModalConfirmAction").attr("onclick", `hideModalConfirmAction()`);

    $("#modalConfirmAction").modal('show');
}

function hideModalConfirmAction() {
    $("#modalConfirmAction").modal('hide');
}


function deleteClient(clientId) {

    var urlMetodo = baseUrl + `/Client/DeleteClient?clientId=${clientId}`;

    $.ajax({
        url: urlMetodo,
        contentType: "application/json; charset=utf-8",
        type: "POST",
        success: function (result) {
            if (result.type == "success") {
                alert(result.message);
                $("#modalConfirmAction").modal('hide');
                setTimeout(function () { window.location.reload() }, 2000);
            } else {
                alert(result.message);
            }
        }
    });
}