async function CodigoAcessoGerar() {
    return new Promise((resolve, reject) => {
        Get('CodigoAcesso/Gerar').then(function (response) {
            console.log(response)
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}