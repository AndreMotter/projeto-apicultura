$(document).ready(function () {
    load();
});

function load() {
    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        Abe_racaBuscaPorId(id).then(function (obj) {
            $("[name='rac_descricao']").val(obj.rac_descricao);
            $("[name='rac_origem']").val(obj.rac_origem);
        }, function (err) {
            alert(err);
        });
    };
}

function salvar() {
    let obj = {
        rac_descricao: ($("[name='rac_descricao']").val() || ''),
        rac_origem: ($("[name='rac_origem']").val() || ''),
    };
    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        obj.id = id;
    }
    Abe_racaSalvar(obj).then(function () {
        window.location.href = '/abe_raca';
    }, function (err) {
        alert(err);
    });
}

