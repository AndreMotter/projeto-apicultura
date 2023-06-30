$(document).ready(function () {

    $(document).keypress(function (e) {
        if (e.which == 13) {
            Acessar(document.getElementById("acessar"));
        }
    });

});

function Acessar(ele) {
    //$('#display-erro').hide();
    //$('#btn-acessar').attr('disabled', true);
    let obj = {
        usuario: $('#login').val(),
        senha: $('#senha').val()
    };
    IndexLogar(obj).then(function () {
/*        unloading(ele);*/
        window.location.href = '/home';
    }, function (err) {
        //unloading(ele);
        //$('#alert-erro').html(err);
        //$('#display-erro').show();
        //$('#btn-acessar').attr('disabled', false);
    });
}