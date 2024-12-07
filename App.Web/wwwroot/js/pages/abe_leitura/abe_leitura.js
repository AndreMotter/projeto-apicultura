
$(document).ready(function () {
    $('#descricao').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    $('#data_inicial, #data_final, #col_codigo, #tip_codigo').change(function (e) {
        load();
    });

    load();
    loadColmeia();
    loadTipoLeitura();
});
function loadColmeia() {
    Abe_colmeiaListaAbe_colmeia('', 0).then(function (data) {
        $('#col_codigo').append('<option value="">Todos</option>');
        data.forEach(obj => {
            $('#col_codigo').append('<option value="' + obj.col_codigo + '">' + obj.col_descricao + '</option>');
        });
        $('#col_codigo').select2();
    });
}
function loadTipoLeitura() {
    Abe_leituraListaAbe_tipoleitura().then(function (data) {
        $('#tip_codigo').append('<option value="">Todos</option>');
        data.forEach(obj => {
            $('#tip_codigo').append('<option value="' + obj.tip_codigo + '">' + obj.tip_descricao + '</option>');
        });
        $('#tip_codigo').select2();
    });
}

function load() {
    let data_inicial = $('#data_inicial').val() || '';
    let data_final = $('#data_final').val() || '';
    let col_codigo = $('#col_codigo').val() || '';
    let tip_codigo = $('#tip_codigo').val() || '';
    $('#table').hide();
    $('#table-loading').show();
    Abe_leituraListaAbe_leitura(data_inicial, data_final, col_codigo, tip_codigo).then(function (data) {
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


function Imprimir() {
    $('#loadingModal').modal();
    let data_inicial = $('#data_inicial').val() || '';
    let data_final = $('#data_final').val() || '';
    let col_codigo = $('#col_codigo').val() || '';
    let tip_codigo = $('#tip_codigo').val() || '';
    Abe_leituraImprimir(data_inicial, data_final, col_codigo, tip_codigo).then(function (data) {
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
