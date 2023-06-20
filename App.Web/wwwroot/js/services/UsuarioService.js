async function UsuarioListaUsuarios(busca) {
    return new Promise((resolve, reject) => {
        Get('Usuario/ListaUsuarios?nome=' + busca).then(function (response) {
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

async function UsuarioBuscaPorId(id) {
    return new Promise((resolve, reject) => {
        Get('Usuario/BuscaPorId?id=' + id).then(function (response) {
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

async function UsuarioSalvar(obj) {
    return new Promise((resolve, reject) => {
        Post('Usuario/Salvar', obj).then(function (response) {
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

async function UsuarioRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('Usuario/Remover?id=' + id).then(function (response) {
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
