$(document).ready(function () {
    $('#col_descricao').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    $('#col_status').change(function (e) {
        load();
    });
    load();
});

function load() {
    let col_descricao = $('#col_descricao').val() || '';
    let col_status = parseInt($('#col_status').val()) || 0;
    $('#table').hide();
    $('#table-loading').show();
    Abe_colmeiaListaAbe_colmeia(col_descricao, col_status).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            let data = moment(obj.col_datainstalacao || ''); 
            let data_formatada = data.format('DD/MM/YYYY');

            $('#table tbody').append(
                '<tr>' +
                '<td>' + (obj.col_numero || '--') + '</td>' +
                '<td>' + (obj.col_descricao || '--') + '</td>' +
                '<td>' + (obj.abe_raca.rac_descricao || '--') + '</td>' +
                '<td>' + (data_formatada || '--') + '</td>' +
                '<td class="text-right">' +
                '<div class="btn-group" role="group">' +
                (!obj.col_status ? '<button class="btn btn-danger btn-sm mr-2" onclick="ativar(\'' + obj.col_codigo + '\')"> <i class="bi bi-hand-thumbs-down-fill"></i> Ativar</button>' :
                    '<button class="btn btn-success btn-sm mr-2" onclick="ativar(\'' + obj.col_codigo + '\')"><i class="bi bi-hand-thumbs-up-fill"></i> Desativar</button>') +
                '<button class="btn btn-warning btn-sm mr-2" onclick="window.location.href=\'/abe_colmeia/formulario/' + obj.col_codigo + '\'"><i class="bi bi-pencil-fill"></i> Editar</button>' +
                '<button class="btn btn-danger btn-sm btn-excluir" onclick="excluir(\'' + obj.col_codigo + '\');"><i class="bi bi-trash-fill"></i> Excluir</button>' +
                '</div>' +
                '</td>' +
                '</tr>'
            );
        });
        $('#table').show();
        $('#table-loading').hide();
    }, function (err) {
        $('#table').show();
        $('#table-loading').hide();
        alert(err);
    });
}

function excluir(id) {
    Abe_colmeiaRemover(id).then(function () {
        load();
    }, function (err) {
        alert(err);
    });
}

function ativar(id) {
    Abe_colmeiaAtivar(id).then(function () {
      load();
    }, function (err) {
        alert(err);
    });
}


function Imprimir() {
    $('#loadingModal').modal();
    let col_descricao = $('#col_descricao').val() || '';
    let col_status = parseInt($('#col_status').val()) || 0;
    Abe_colmeiaImprimir(col_descricao, col_status).then(function (data) {
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
