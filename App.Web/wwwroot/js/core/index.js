$(document).ready(function () {
    VerificaToken();
});


function VerificaToken() {
    if (window.location.pathname.toLocaleLowerCase() !== '/') {
        IndexAutenticado().then(function (usuario) {
            if (!usuario) {
                DeleteAllCookies();
                window.location.href = '/';
            } else {
                SetCookie('tipo-usuario', usuario.permissao);
                SetCookie('id-usuario', usuario.id);
                if (usuario.permissao == 1) {
                    $('#menus-cliente').hide();
                    $('#menus-adm').show();
                } else {
                    $('#menus-adm').hide();
                    $('#menus-show').show();
                }
            }
        }, function () {
            DeleteAllCookies();
            window.location.href = '/';
        });
    }
}
