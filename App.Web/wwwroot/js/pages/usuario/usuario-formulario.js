$(document).ready(function () {
    load();
    loadCidades();
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
            for (let key in obj) {
                if (obj.hasOwnProperty(key)) {
                    let input = $("[name='" + key + "']");
                    if (input) {
                        input.val(obj[key]);
                    }
                }
            }
        });
    };
}
function salvar() {
    let obj = {
        nome: ($("[name='nome']").val() || ''),
        cidadeId: ($("[name='cidadeId']").val() || ''),
        dataNascimento: ($("[name='dataNascimento']").val() || ''),
        ativo: parseInt($("[name='status']").val()) == 1 ? true : false,
    };

    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        obj.id = parseInt(id);
    }
    UsuarioSalvar(obj).then(function () {
        window.location.href = '/usuario';
    }, function (err) {
        alert(err);
    });
}

