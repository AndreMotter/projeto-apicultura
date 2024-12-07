
$(document).ready(function () {
    $('#rac_descricao').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    $('#rac_status').change(function (e) {
        load();
    });
    load();
});

function load() {
    let rac_descricao = $('#rac_descricao').val() || '';
    let rac_status = parseInt($('#rac_status').val()) || 0;
    $('#table').hide();
    $('#table-loading').show();
    Abe_racaListaAbe_raca(rac_descricao, rac_status).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append(
                '<tr>' +
                '<td>' + (obj.rac_descricao || '--') + '</td>' +
                '<td>' + (obj.rac_origem || '--') + '</td>' +
                '<td class="text-right">' +
                '<div class="btn-group" role="group">' +
                (!obj.rac_status ? '<button class="btn btn-danger btn-sm mr-2" onclick="ativar(\'' + obj.rac_codigo + '\')"> <i class="bi bi-hand-thumbs-down-fill"></i> Ativar</button>' :
                    '<button class="btn btn-success btn-sm mr-2" onclick="ativar(\'' + obj.rac_codigo + '\')"><i class="bi bi-hand-thumbs-up-fill"></i> Desativar</button>') +
                '<button class="btn btn-warning btn-sm mr-2" onclick="window.location.href=\'/abe_raca/formulario/' + obj.rac_codigo + '\'"><i class="bi bi-pencil-fill"></i> Editar</button>' +
                '<button class="btn btn-danger btn-sm btn-excluir" onclick="excluir(\'' + obj.rac_codigo + '\');"><i class="bi bi-trash-fill"></i> Excluir</button>' +
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
    Abe_racaRemover(id).then(function () {
        load();
    }, function (err) {
        alert(err);
    });
}

function ativar(id) {
    Abe_racaAtivar(id).then(function () {
      load();
    }, function (err) {
        alert(err);
    });
}

function Imprimir() {
    $('#loadingModal').modal();
    let rac_descricao = $('#rac_descricao').val() || '';
    let rac_status = parseInt($('#rac_status').val()) || 0;
    Abe_racaImprimir(rac_descricao, rac_status).then(function (data) {
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
