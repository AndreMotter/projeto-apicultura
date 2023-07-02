$(document).ready(function () {
    loadCidades();
    load();
});

function loadCidades() {
    CidadeListaCidades('').then(function (data) {
        data.forEach(obj => {
            $('#cidadeId').append('<option value="'+obj.id+'">'+obj.nome+'</option>');
        });
        $('#cidadeId').select2();
    });
}
function load() {
    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        UsuarioBuscaPorId(id).then(function (obj) {
            $("[name='nome']").val(obj.nome);
            $("[name='dataNascimento']").val(moment(obj.dataNascimento).format('YYYY-MM-DD'));
            $("[name='cidadeId']").val(obj.cidadeId.toString());
            $("[name='cidadeId']").select2();
            $("[name='senha']").val(obj.senha);
            $("[name='status']").val(obj.ativo ? "1" : "2");
            $("[name='permissao']").val(obj.permissao.toString());
        }, function (err) {
            alert(err);
        });
    };
}

function salvar() {
    let obj = {
        nome: ($("[name='nome']").val() || ''),
        cidadeId: ($("[name='cidadeId']").val() || ''),
        dataNascimento: ($("[name='dataNascimento']").val() || null),
        ativo: parseInt($("[name='status']").val()) == 1 ? true : false,
        permissao: parseInt($("[name='permissao']").val()),
        senha: $("[name='senha']").val(),
    };
    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        obj.id = id;
    }
    UsuarioSalvar(obj).then(function () {
        window.location.href = '/usuario';
    }, function (err) {
        alert(err);
    });
}

