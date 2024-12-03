
async function HistoricoAcessosListar(usuario, dataInicial, dataFinal) {
    return new Promise((resolve, reject) => {
        Get('HistoricoAcessos/Listar?usuario=' + usuario + '&dataInicial=' + dataInicial + '&dataFinal=' + dataFinal).then(function (response) {
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


async function HistoricoAcessosImprimir(usuario, dataInicial, dataFinal) {
    return new Promise((resolve, reject) => {
        Get('HistoricoAcessos/Imprimir?usuario=' + usuario + '&dataInicial=' + dataInicial + '&dataFinal=' + dataFinal).then(function (response) {
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


async function HistoricoAcessosRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('HistoricoAcessos/Remover?id=' + id).then(function (response) {
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
