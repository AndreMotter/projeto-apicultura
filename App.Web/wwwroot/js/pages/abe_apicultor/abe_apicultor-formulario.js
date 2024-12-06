$(document).ready(function () {
    load();
});

function load() {
    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        Abe_apicultorBuscaPorId(id).then(function (obj) {
            $("[name='api_nome']").val(obj.api_nome);
            $("[name='api_cpfcnpj']").val(obj.api_cpfcnpj);
            $("[name='api_telefone']").val(obj.api_telefone);
        }, function (err) {
            alert(err);
        });
    };
}

function salvar() {
    let obj = {
        api_nome: ($("[name='api_nome']").val() || ''),
        api_cpfcnpj: ($("[name='api_cpfcnpj']").val() || ''),
        api_telefone: ($("[name='api_telefone']").val() || ''),
    };
    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        obj.id = id;
    }
    Abe_apicultorSalvar(obj).then(function () {
        window.location.href = '/abe_apicultor';
    }, function (err) {
        alert(err);
    });
}

