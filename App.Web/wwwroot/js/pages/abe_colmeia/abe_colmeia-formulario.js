$(document).ready(function () {
    debugger
    loadRaca();
    load();
});

function load() {
    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        Abe_colmeiaBuscaPorId(id).then(function (obj) {
            $("[name='col_descricao']").val(obj.col_descricao);
            $("[name='col_datainstalacao']").val(obj.col_datainstalacao);
            $("[name='col_numero']").val(obj.col_numero);
            $("[name='col_latitude']").val(obj.col_latitude);
            $("[name='col_longitude']").val(obj.col_longitude);
            $("[name='abe_codigo']").val(obj.abe_codigo);
        }, function (err) {
            alert(err);
        });
    };
}

function loadRaca() {
    Abe_racaListaAbe_raca('',0).then(function (data) {
        data.forEach(obj => {
            $('#abe_codigo').append('<option value="' + obj.rac_codigo + '">' + obj.rac_descricao + '</option>');
        });
        $('#abe_codigo').select2();
    });
}

function salvar() {
    let obj = {
        col_descricao: ($("[name='col_descricao']").val() || ''),
        col_datainstalacao: ($("[name='col_datainstalacao']").val() || null),
        col_numero: ($("[name='col_numero']").val() || null),
        col_latitude: ($("[name='col_latitude']").val() || 0),
        col_longitude: ($("[name='col_longitude']").val() || 0),
        abe_codigo: ($("[name='abe_codigo']").val() || 0),
    };
    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        obj.id = id;
    }
    Abe_colmeiaSalvar(obj).then(function () {
        window.location.href = '/Abe_colmeia';
    }, function (err) {
        alert(err);
    });
}

