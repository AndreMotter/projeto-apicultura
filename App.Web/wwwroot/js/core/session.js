$(document).ready(function () {
    VerificaToken();
});


function VerificaToken() {
    if (window.location.pathname.toLocaleLowerCase() !== '/') {
        $('#loading').show();
        $('#label-menu-cadastros').hide();
        $('#label-menu-lancamentos').hide();
        $('#label-menu-estatisticas').hide();
        IndexAutenticado().then(function (usuario) {
            if (!usuario) {
                DeleteAllCookies();
                window.location.href = '/';
            } else {
                SetCookie('tipo-usuario', usuario.permissao);
                SetCookie('id-usuario', usuario.id);
                $("#usuario-logado").text(usuario.login);
                if (usuario.permissao == 1) {
                    $('#menus-adm-cadastros').show();
                    $('#menus-adm-lancamentos').show();
                } 
                loadGraficos();
            }
            $('#loading').hide();
            $('#label-menu-cadastros').show();
            $('#label-menu-lancamentos').show();
            $('#label-menu-estatisticas').show();
        }, function () {
            $('#loading').hide();
            $('#label-menu-cadastros').show();
            $('#label-menu-lancamentos').show();
            $('#label-menu-estatisticas').show();
            DeleteAllCookies();
            window.location.href = '/';
        });
    }
}


function loadGraficos() {
    Abe_leituraBuscarInformacoesGrafico().then(function (obj) {
        var labels1 = obj.lista_grafico_01.map(function (item) {
            return item.tip_descricao; // Extrai a descrição do tipo
        });

        var data1 = obj.lista_grafico_01.map(function (item) {
            return item.total; // Extrai o total
        });

        var ctx1 = document.getElementById('chart1').getContext('2d');
        var chart1 = new Chart(ctx1, {
            type: 'bar',
            data: {
                labels: labels1,
                datasets: [{
                    label: 'Quantidade Leituras (Últimos 30 dias)',
                    data: data1,
                    backgroundColor: 'rgba(54, 162, 235, 0.2)',
                    borderColor: 'rgba(54, 162, 235, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });

        var labels2 = obj.lista_grafico_02.map(function (item) {
            return item.col_descricao; // Extrai a descrição da colmeia
        });

        var data2 = obj.lista_grafico_02.map(function (item) {
            return item.total; // Extrai o total
        });

        var ctx2 = document.getElementById('chart2').getContext('2d');
        var chart2 = new Chart(ctx2, {
            type: 'bar',
            data: {
                labels: labels2,
                datasets: [{
                    label: 'Quantidade Leituras (Últimos 30 dias)',
                    data: data2,
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',  // Verde claro (transparente)
                    borderColor: 'rgba(75, 192, 192, 1)',  // Verde escuro (opaco)
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    }, function (err) {
        alert(err);
    });
}




