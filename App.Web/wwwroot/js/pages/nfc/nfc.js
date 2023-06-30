
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
    debugger
    let usuario = $('#usuario').val();
    let status = parseInt($('#status').val()) || 0;

    $('#table').hide();
    $('#table-loading').show();
    NfcListar(usuario, status).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append(
                '<tr>' +
                '<td style="width: 20%;">' + (obj.usuario.nome || '--') + '</td>' +
                '<td style="width: 20%;">' + (obj.token || '--') + '</td>' +
                '<td style="width: 15%;">' + ((!obj.ativo ? 'Inativo' : 'Ativo') || '--') + '</td>' +
                '<td style="width: 13%;">' +
                (!obj.ativo ? '<button class="btn btn-danger" onclick="ativar(\'' + obj.id + '\')"> <i class="bi bi-hand-thumbs-down-fill"></i> Ativar</button>' :
                    '<button class="btn btn-success" onclick="ativar(\'' + obj.id + '\')"><i class="bi bi-hand-thumbs-up-fill"></i> Desativar</button>') +
                '<button style="margin-left: 5px" class="btn btn-warning" onclick="window.location.href=\'/usuario/' + obj.id + '\'"><i class="bi bi-pencil-fill"></i> Editar</button>' +
                '<button style="margin-left: 5px" class="btn btn-danger btn-excluir" onclick="excluir(\'' + obj.id + '\');"><i class="bi bi-trash-fill"></i> Excluir</button>' +
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
    debugger
   NfcRemover(id).then(function () {
        load();
    }, function (err) {
        alert(err);
    });
}


function ativar(id) {
    debugger
    NfcAtivar(id).then(function () {
        load();
    }, function (err) {
        alert(err);
    });
}
