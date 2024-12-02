$(document).ready(function () {
    VerificaToken();
});


function VerificaToken() {
    if (window.location.pathname.toLocaleLowerCase() !== '/') {
        $('#loading').show();
        $('#label-menu-cadastros').hide();
        $('#label-menu-lancamentos').hide();
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
        }, function () {
            $('#loading').hide();
            $('#label-menu-cadastros').show();
            $('#label-menu-lancamentos').show();
            DeleteAllCookies();
            window.location.href = '/';
        });
    }
}
