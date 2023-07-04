function gerar(ele) {
    CodigoAcessoGerar().then(function (data) {
        $("#codigo-acesso").val(data);
    }, function (err) {
        alert(err);
    });
}