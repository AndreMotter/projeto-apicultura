$(document).ready(function () {
    $('#usuario').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    $('#dataInicial').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    $('#dataFinal').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    $('#table').hide();
    $('#table-loading').show();
    let usuario = $('#usuario').val();
    let dataInicial = $('#dataInicial').val();
    let dataFinal = $('#dataFinal').val();
    HistoricoAcessosListar(usuario, dataInicial, dataFinal).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            let data = new Date(obj.data);
            $('#table tbody').append('<tr>' +
                '<td>' + (obj.usuario.nome || '--') + '</td>' +
                '<td>' + (`${data.getDate().toString().padStart(2, "0")}/${(data.getMonth() + 1).toString().padStart(2, "0")}/${data.getFullYear()}` || '--') + '</td>' +
                '<td>' + (obj.descricao || '--') + '</td>' +
                '</tr>');
        });
        $('#table').show();
        $('#table-loading').hide();
    });
}

function Imprimir() {
    $('#loadingModal').modal();
    let usuario = $('#usuario').val();
    let dataInicial = $('#dataInicial').val();
    let dataFinal = $('#dataFinal').val();
    HistoricoAcessosImprimir(usuario, dataInicial, dataFinal).then(function (data) {
        let arrrayBuffer = base64ToArrayBuffer(data);
        let blob = new Blob([arrrayBuffer], { type: "application/pdf" });
        let link = window.URL.createObjectURL(blob);
        window.open(link, '_blank');
        $('#loadingModal').modal('hide');
    }, function (err) {
        $('#loadingModal').modal('hide');
        alert(err);
    });
}