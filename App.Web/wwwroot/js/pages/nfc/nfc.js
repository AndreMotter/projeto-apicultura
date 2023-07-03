
$(document).ready(function () {
    $('#usuario').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    $('#status').change(function (e) {
        load();
    });
    load();
});

function load() {
    let usuario = $('#usuario').val();
    let status = parseInt($('#status').val()) || 0;

    $('#table').hide();
    $('#table-loading').show();
    NfcListar(usuario, status).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append(
                '<tr>' +
                '<td>' + (obj.usuario.nome || '--') + '</td>' +
                '<td>' + (obj.token || '--') + '</td>' +
                '<td>' + ((!obj.ativo ? 'Inativo' : 'Ativo') || '--') + '</td>' +
                '<td class="text-right">' +
                '<div class="btn-group" role="group">' +
                (!obj.ativo ? '<button class="btn btn-danger btn-sm mr-2" onclick="ativar(\'' + obj.id + '\')"> <i class="bi bi-hand-thumbs-down-fill"></i> Ativar</button>' :
                    '<button class="btn btn-success btn-sm mr-2" onclick="ativar(\'' + obj.id + '\')"><i class="bi bi-hand-thumbs-up-fill"></i> Desativar</button>') +
                '<button class="btn btn-warning btn-sm mr-2" onclick="window.location.href=\'/nfc/formulario/' + obj.id + '\'"><i class="bi bi-pencil-fill"></i> Editar</button>' +
                '<button class="btn btn-danger btn-sm btn-excluir" onclick="excluir(\'' + obj.id + '\');"><i class="bi bi-trash-fill"></i> Excluir</button>' +
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
   NfcRemover(id).then(function () {
        load();
    }, function (err) {
        alert(err);
    });
}


function ativar(id) {
    NfcAtivar(id).then(function () {
        load();
    }, function (err) {
        alert(err);
    });
}
