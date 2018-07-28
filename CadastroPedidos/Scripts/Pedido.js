$(document).ready(function () {

    var url = window.location.pathname;

    if (url.indexOf("Edit") > 0) {

        var id = $("#Id").val();
        ListarItens(id);
    }

})

function SalvarPedido() {

    var data = $("#Data").val();

    var valor = $("#Valor").val();

    var cliente = $("#NomeCliente").val();

    var valorTotal = valor

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Pedido/Create"] input[name="__RequestVerificationToken"]').val();

    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr

    //Gravar
    var url = "/Pedido/Create";

    $.post(url, $("#formPedidos").serialize())
        .done(function (data) {
            if (data.Resultado > 0) {
                ListarItens(data.Resultado);
            }
        })

    //$.ajax({
    //    url: url,
    //    type: "POST",
    //    datatype: "json",
    //    headers: headersadr,
    //    data: { Id: 0, Data: data, NomeCliente: cliente, Valor: valor, __RequestVerificationToken: token },
    //    success: function (data) {
    //        if (data.Resultado > 0) {
    //            ListarItens(data.Resultado);
    //        }
    //    }
    //});
}

function ListarItens(idPedido) {

    var url = "/Itens/ListarItens";

    $.ajax({
        url: url,
        type: "GET",
        data: { id: idPedido },
        datatype: "html",
        success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    });
}

function SalvarItens() {

    var url = "/Itens/SalvarItens";

    $.ajax({

        url: url,
        type: "GET",
        data: $("#formItemPedido").serialize(), // nome do form
        datatype: "json", //json
        success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(idPedido);
            }
        }
    });
}

function ExcluirItem(id) {
    var url = "/Itens/Excluir"

    $.post(url, { id: id })
        .done(function (data) {
            if (data.Resultado) {
                var linha = "#tr" + id;
                $(linha).fadeOut(500);
            }
        });

    //$.ajax({
    //    url: url,
    //    data: { id: id },
    //    datatype: "json",
    //    type: "POST",
    //    success: function (data) {
    //        if (data.Resultado) {
    //            var linha = "#tr" + id;
    //            $(linha).fadeOut(500);
    //        }
    //    }
    //});
}