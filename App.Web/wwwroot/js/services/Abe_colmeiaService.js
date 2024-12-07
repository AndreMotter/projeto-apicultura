async function Abe_colmeiaListaAbe_colmeia(abe_colmeia) {
    return new Promise((resolve, reject) => {
        Get('Abe_colmeia/ListaAbe_colmeia?abe_colmeia=' + abe_colmeia).then(function (response) {
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

async function Abe_colmeiaBuscaPorId(id) {
    return new Promise((resolve, reject) => {
        Get('Abe_colmeia/BuscaPorId?id=' + id).then(function (response) {
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

async function Abe_colmeiaSalvar(obj) {
    return new Promise((resolve, reject) => {
        Post('Abe_colmeia/Salvar', obj).then(function (response) {
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

async function Abe_colmeiaRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('Abe_colmeia/Remover?id=' + id).then(function (response) {
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

async function Abe_colmeiaAtivar(id) {
    return new Promise((resolve, reject) => {
        Get('Abe_colmeia/Ativar?id=' + id).then(function (response) {
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
