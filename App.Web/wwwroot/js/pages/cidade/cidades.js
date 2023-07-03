$(document).ready(function () {
    $('#busca').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    let cidade = $('[name="busca"]').val();
    $('#table').hide();
    $('#table-loading').show();

    CidadeListaCidades(cidade).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.cep || '--') + '</td>' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (obj.uf || '--') + '</td>' +
                '<td class="text-right">' +
                '<div class="btn-group" role="group">' +
                '<button class="btn btn-danger btn-sm btn-excluir" onclick="excluir(\'' + obj.id + '\');"><i class="bi bi-trash-fill"></i> Excluir</button>' +
                '</div>' +
                '</td>' +
                '</tr>');
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
    CidadeRemover(id).then(function () {
        load();
    }, function (err) {
        alert(err);
    });
}
