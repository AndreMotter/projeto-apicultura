
$(document).ready(function () {
    $('#descricao').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    let abe_leitura = $('#descricao').val() || '';
    let rac_ativo = parseInt($('#rac_ativo').val()) || 0;
    $('#table').hide();
    $('#table-loading').show();
    Abe_leituraListaAbe_leitura(abe_leitura).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append(
                '<tr>' +
                '<td>' + (obj.lei_data || '--') + '</td>' +
                '<td>' + (obj.lei_valor || '--') + '</td>' +
                '<td>' + (obj.col_descricao || '--') + '</td>' +
                '<td>' + (obj.tip_descricao || '--') + '</td>' +
                '<td class="text-right">' +
                '<div class="btn-group" role="group">' +
                (!obj.rac_status ? '<button class="btn btn-danger btn-sm mr-2" onclick="ativar(\'' + obj.rac_codigo + '\')"> <i class="bi bi-hand-thumbs-down-fill"></i> Ativar</button>' :
                    '<button class="btn btn-success btn-sm mr-2" onclick="ativar(\'' + obj.rac_codigo + '\')"><i class="bi bi-hand-thumbs-up-fill"></i> Desativar</button>') +
                '<button class="btn btn-warning btn-sm mr-2" onclick="window.location.href=\'/Abe_leitura/formulario/' + obj.rac_codigo + '\'"><i class="bi bi-pencil-fill"></i> Editar</button>' +
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