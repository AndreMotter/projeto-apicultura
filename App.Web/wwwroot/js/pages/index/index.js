$(document).ready(function () {

    $(document).keypress(function (e) {
        if (e.which == 13) {
            Acessar(document.getElementById("acessar"));
        }
    });

});

function Acessar() {
    $("#erro").hide();
    let obj = {
        usuario: $('#login').val(),
        senha: $('#senha').val()
    };
    IndexLogar(obj).then(function () {
        window.location.href = '/home';
    }, function (err) {
        $("#erro").text(err);
        $("#erro").show();
    });
}