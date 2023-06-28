
$(document).ready(function () {
    $('#busca').keypress(function (e) {
        if (e.which === 13) {
            load();
        }
    });
    load();
});

function load() {
    let busca = $('[name="busca"]').val();
    $('#table').hide();
    $('#table-loading').show();
    UsuarioListaUsuarios(busca).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append(
                '<tr>' +
                    '<td style="width: 20%;">' + (obj.nome || '--') + '</td>' +
                    '<td style="width: 20%;">' + (moment(obj.dataNascimento).format('DD/MM/YYYY') || '--') + '</td>' +
                    '<td style="width: 20%;">' + (obj.cidade.nome || '--') + '</td>' +
                    '<td style="width: 20%;"> Ativo</td>' +
                    '<td style="width: 10%;">' +
                '<button class="btn btn-warning btn-editar" onclick="window.location.href=\'/usuario/' + obj.id + '\'"><i class="bi bi-pencil-fill"></i> Editar</button>' +
                '<button style="margin-left: 5px" class="btn btn-danger btn-excluir" onclick="excluir(\'' + obj.id + '\');"><i class="bi bi-trash-fill"></i> Excluir</button>' +
                    '</td>' +
                '</tr>'
            );
        });
        $('#table').show();
        $('#table-loading').hide();
    });
}

function excluir(id) {
    UsuarioExcluir(id).then(function (data) {
        load();
    }, function (err) {
        alert(err);
    });
}



