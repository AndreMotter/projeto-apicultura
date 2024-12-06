
$(document).ready(function () {
    $('#descricao').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    let abe_apicultor = $('#descricao').val() || '';
    let rac_ativo = parseInt($('#rac_ativo').val()) || 0;
    $('#table').hide();
    $('#table-loading').show();
    Abe_apicultorListaAbe_apicultor(abe_apicultor).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append(
                '<tr>' +
                '<td>' + (obj.api_nome || '--') + '</td>' +
                '<td>' + (obj.api_cpfcnpj || '--') + '</td>' +
                '<td class="text-right">' +
                '<div class="btn-group" role="group">' +
                (!obj.api_status ? '<button class="btn btn-danger btn-sm mr-2" onclick="ativar(\'' + obj.api_codigo + '\')"> <i class="bi bi-hand-thumbs-down-fill"></i> Ativar</button>' :
                    '<button class="btn btn-success btn-sm mr-2" onclick="ativar(\'' + obj.api_codigo + '\')"><i class="bi bi-hand-thumbs-up-fill"></i> Desativar</button>') +
                '<button class="btn btn-warning btn-sm mr-2" onclick="window.location.href=\'/abe_apicultor/formulario/' + obj.api_codigo + '\'"><i class="bi bi-pencil-fill"></i> Editar</button>' +
                '<button class="btn btn-danger btn-sm btn-excluir" onclick="excluir(\'' + obj.api_codigo + '\');"><i class="bi bi-trash-fill"></i> Excluir</button>' +
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
    Abe_apicultorRemover(id).then(function () {
        load();
    }, function (err) {
        alert(err);
    });
}

function ativar(id) {
    Abe_apicultorAtivar(id).then(function () {
        load();
    }, function (err) {
        alert(err);
    });
}
