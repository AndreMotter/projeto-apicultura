$(document).ready(function () {
    loadUsuarios();
    load();
});


function loadUsuarios() {
    UsuarioListaUsuarios('', 0).then(function (data) {
        data.forEach(obj => {
            $('#usuarioId').append('<option value="' + obj.id + '">' + obj.nome + '</option>');
        });
        $('#usuarioId').select2();
    });
}

function load() {
    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        NfcBuscaPorId(id).then(function (obj) {
            $("[name='token']").val(obj.token);
            $("[name='usuarioId']").val(obj.usuarioId.toString());
            $('#usuarioId').select2();
            $("[name='status']").val(obj.ativo ? "1" : "2");
        }, function (err) {
            alert(err);
        });
    };
}


function salvar() {
    let obj = {
        token: ($("[name='token']").val() || ''),
        usuarioId: ($("[name='usuarioId']").val() || ''),    
        ativo: parseInt($("[name='status']").val()) == 1 ? true : false,
    };
    let id = getUltimoAlias();
    if (id && id.toLowerCase() !== 'formulario') {
        obj.id = id;
    }
    NfcSalvar(obj).then(function () {
        window.location.href = '/nfc';
    }, function (err) {
        alert(err);
    });
}

