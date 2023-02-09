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

function updateModel(modelId) {

    $(".loading").show();


    var dados = {
        idModelo: modelId,
        idMarca: $("#brandSelectUpdate").val(),
        codigo: $("#inputCodigoUpdate").val(),
        categoria: $("#inputCategoriaUpdate").val(),
        descricao: $("#inputDescricaoModeloUpdate").val(),
        urlCatalogo: $("#inputUrlCatalogoUpdate").val()
    };

    var urlMetodo = baseUrl + '/Records/UpdateModel';

    $.ajax({
        url: urlMetodo,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        data: JSON.stringify(dados),
        success: function (result) {
            if (result.type == "success") {
                displayMessage(result.message, result.type);
                hideModalUpdateModel();
                setTimeout(function () { window.location.reload() }, 2000);
            } else {
                $(".loading").hide();
                displayMessage(result.message, result.type);
            }
        }
    });
}


function openModalDelete(idModel) {
    $("#titleModalConfirmAction").html(`Excluir Modelo ${idModel}`);
    $("#textBodyModalConfirmAction").html('Confirma a exclusão do Modelo ?');

    $("#confirmButtonModalConfirmAction").attr("onclick", `deleteModel(${idModel})`);
    $("#cancelButtonModalConfirmAction").attr("onclick", `hideModalConfirmAction()`);

    $("#modalConfirmAction").modal('show');
}