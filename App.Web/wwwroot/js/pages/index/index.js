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
    IndexLogar(obj).then(function () {
        window.location.href = '/home';
    }, function (err) {
        alert(err);
    });
}