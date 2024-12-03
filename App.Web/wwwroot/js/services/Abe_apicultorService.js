async function Abe_apicultorListaAbe_apicultor(abe_apicultor) {
    return new Promise((resolve, reject) => {
        Get('Abe_apicultor/ListaAbe_apicultor?abe_apicultor=' + abe_apicultor).then(function (response) {
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

async function Abe_apicultorBuscaPorId(id) {
    return new Promise((resolve, reject) => {
        Get('Abe_apicultor/BuscaPorId?id=' + id).then(function (response) {
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

async function Abe_apicultorSalvar(obj) {
    return new Promise((resolve, reject) => {
        Post('Abe_apicultor/Salvar', obj).then(function (response) {
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

async function Abe_apicultorRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('Abe_apicultor/Remover?id=' + id).then(function (response) {
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