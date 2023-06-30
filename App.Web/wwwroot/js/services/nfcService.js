
async function NfcListar(usuario, status) {
    return new Promise((resolve, reject) => {
        Get('Nfc/Listar?usuario=' + usuario + '&status=' + status).then(function (response) {
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

async function NfcRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('Nfc/Remover?id=' + id).then(function (response) {
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

async function NfcAtivar(id) {
    return new Promise((resolve, reject) => {
        Get('Nfc/Ativar?id=' + id).then(function (response) {
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

