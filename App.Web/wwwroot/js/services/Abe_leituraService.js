async function Abe_leituraListaAbe_leitura(data_inicial, data_final, col_codigo, tip_codigo) {
    return new Promise((resolve, reject) => {
        Get('Abe_leitura/ListaAbe_leitura?data_inicial=' + data_inicial + '&data_final=' + data_final + '&col_codigo=' + col_codigo + '&tip_codigo=' + tip_codigo).then(function (response) {
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

async function Abe_leituraListaAbe_tipoleitura() {
    return new Promise((resolve, reject) => {
        Get('Abe_leitura/ListaAbe_tipoleitura').then(function (response) {
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

async function Abe_leituraBuscarInformacoesGrafico() {
    return new Promise((resolve, reject) => {
        Get('Abe_leitura/BuscarInformacoesGrafico').then(function (response) {
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

async function Abe_leituraBuscaPorId(id) {
    return new Promise((resolve, reject) => {
        Get('Abe_leitura/BuscaPorId?id=' + id).then(function (response) {
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

async function Abe_leituraSalvar(obj) {
    return new Promise((resolve, reject) => {
        Post('Abe_leitura/Salvar', obj).then(function (response) {
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

async function Abe_leituraRemover(id) {
    return new Promise((resolve, reject) => {
        Delete('Abe_leitura/Remover?id=' + id).then(function (response) {
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

async function Abe_leituraAtivar(id) {
    return new Promise((resolve, reject) => {
        Get('Abe_leitura/Ativar?id=' + id).then(function (response) {
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
