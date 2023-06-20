
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
    UsuarioListaUsuarios(busca).then(function (data) {
        $('#table tbody').html('');
        data.forEach(obj => {
            $('#table tbody').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (moment(obj.dataNascimento).format('DD/MM/YYYY') || '--') + '</td>' +
                '<td>' + (obj.ativo || '--') + '</td>' +
                '<td>' +
                '<button class="btn-editar" onclick="window.location.href=\'/usuario/' + value.id + '\'"><i class="fas fa-edit"></i> Editar</button>' +
                '<button class="btn-excluir" onclick="excluir(\'' + value.id + '\');"><i class="fas fa-trash"></i> Excluir</button>' +
                '</td>' +
                '</tr>');
        });

    });
}

function excluir(id) {
    UsuarioExcluir(id).then(function (data) {
        load();
    }, function (err) {
        alert(err);
    });
}



