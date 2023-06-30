
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
    UsuarioListaUsuarios(usuario, status).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append(
                '<tr>' +
                    '<td style="width: 20%;">' + (obj.nome || '--') + '</td>' +
                    '<td style="width: 20%;">' + (moment(obj.dataNascimento).format('DD/MM/YYYY') || '--') + '</td>' +
                    '<td style="width: 20%;">' + (obj.cidade.nome || '--') + '</td>' +
                    '<td style="width: 15%;">' + ((!obj.ativo ? 'Inativo' : 'Ativo') || '--') + '</td>' +
                    '<td style="width: 16%;">' +
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
    UsuarioRemover(id).then(function () {
        load();
    }, function (err) {
        alert(err);
    });
}

function ativar(id) {
    UsuarioAtivar(id).then(function () {
      load();
    }, function (err) {
        alert(err);
    });
}

function Imprimir() {
    $('#loadingModal').modal();
    let usuario = $('#usuario').val();
    let status = parseInt($('#status').val()) || 0;
    UsuarioImprimir(usuario, status).then(function (data) {
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
