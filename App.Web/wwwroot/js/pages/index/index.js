$(document).ready(function () {

    $(document).keypress(function (e) {
        if (e.which == 13) {
            Acessar(document.getElementById("acessar"));
        }
    });

});

function Acessar() {
    let obj = {
        usuario: $('#login').val(),
        senha: $('#senha').val()
    };
    IndexLogar(obj).then(function (usuario) {
        window.location.href = '/home';
        if (usuario.permissao == 1) {
            $('#menus-adm').show();
        } else {
            $('#menus-cliente').show();
        }
    }, function (err) {
        alert(err);
    });
}