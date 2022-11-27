function gerar(ele) {
    //loading(ele);
    CodigoAcessoGerar().then(function (data) {
        //unloading(ele);
        $("#codigo-acesso").val(data);
    }, function (err) {
        //unloading(ele);
        alert(err);
    });
}