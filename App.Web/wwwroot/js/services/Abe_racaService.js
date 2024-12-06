async function Abe_racaListaAbe_raca(abe_raca) {
    return new Promise((resolve, reject) => {
        Get('Abe_raca/ListaAbe_raca?abe_raca=' + abe_raca).then(function (response) {
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

async function Abe_racaBuscaPorId(id) {
    return new Promise((resolve, reject) => {
        Get('Abe_raca/BuscaPorId?id=' + id).then(function (response) {
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

async function Abe_racaSalvar(obj) {
    return new Promise((resolve, reject) => {
        Post('Abe_raca/Salvar', obj).then(function (response) {
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

async function Abe_racaRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('Abe_raca/Remover?id=' + id).then(function (response) {
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

async function Abe_racaAtivar(id) {
    return new Promise((resolve, reject) => {
        Get('Abe_raca/Ativar?id=' + id).then(function (response) {
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
