
$(document).ready(function () {
    $('#descricao').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
    loadColmeia();
    loadTipoLeitura();
});
function loadColmeia() {
    Abe_colmeiaListaAbe_colmeia('', 0).then(function (data) {
        data.forEach(obj => {
            $('#col_codigo').append('<option value="' + obj.col_codigo + '">' + obj.col_descricao + '</option>');
        });
        $('#col_codigo').select2();
    });
}
function loadTipoLeitura() {
    Abe_leituraListaAbe_tipoleitura().then(function (data) {
        data.forEach(obj => {
            $('#tip_codigo').append('<option value="' + obj.tip_codigo + '">' + obj.tip_descricao + '</option>');
        });
        $('#tip_codigo').select2();
    });
}

function load() {
    let abe_leitura = $('#descricao').val() || '';
    let rac_ativo = parseInt($('#rac_ativo').val()) || 0;
    $('#table').hide();
    $('#table-loading').show();
    Abe_leituraListaAbe_leitura(abe_leitura).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            let data = moment(obj.lei_data || '');
            let data_formatada = data.format('DD/MM/YYYY HH:mm:ss')

            $('#table tbody').append(
                '<tr>' +
                '<td>' + (data_formatada || '--') + '</td>' +
                '<td>' + (obj.lei_valor + ' ' + obj.abe_tipodeitura.abe_unidademedida.uni_representante || '--') + '</td>' +
                '<td>' + (obj.abe_colmeia.col_descricao || '--') + '</td>' +
                '<td>' + (obj.abe_tipodeitura.tip_descricao || '--') + '</td>' +
                '<td>' + (obj.abe_tipodeitura.abe_unidademedida.uni_descricao || '--') + '</td>' +
                '<td class="text-right">' +
                '<div class="btn-group" role="group">' +
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