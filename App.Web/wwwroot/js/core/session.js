$(document).ready(function () {
    VerificaToken();
});


function VerificaToken() {
    if (window.location.pathname.toLocaleLowerCase() !== '/') {
        $('#loading').show();
        IndexAutenticado().then(function (usuario) {
            if (!usuario) {
                DeleteAllCookies();
                window.location.href = '/';
            } else {
                SetCookie('tipo-usuario', usuario.permissao);
                SetCookie('id-usuario', usuario.id);
                $("#usuario-logado").text(usuario.login);
                if (usuario.permissao == 1) {
                    $('#menus-adm').show();
                } else {
                    $('#menus-cliente').show();
                }
            }
            $('#loading').hide();
        }, function () {
            $('#loading').hide();
            DeleteAllCookies();
            window.location.href = '/';
        });
    }
}
