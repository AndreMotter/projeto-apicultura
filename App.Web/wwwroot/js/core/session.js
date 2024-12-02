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

// Gráfico de Barras
var ctx1 = document.getElementById('chart1').getContext('2d');
var chart1 = new Chart(ctx1, {
    type: 'bar',
    data: {
        labels: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio'],
        datasets: [{
            label: 'Mel por Comeia',
            data: [12, 19, 3, 5, 2],
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

var ctx2 = document.getElementById('chart2').getContext('2d');
var chart2 = new Chart(ctx2, {
    type: 'bar',
    data: {
        labels: ['Adalberto', 'Márcio', 'Adalcir', 'José', 'Mario'],
        datasets: [{
            label: 'Mel por Apicultor',
            data: [12, 19, 3, 5, 2],
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