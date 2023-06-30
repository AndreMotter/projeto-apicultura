using App.Domain.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Interfaces.Application
{
    public interface IUsuarioService
    {
        Usuario BuscaPorId(Guid id);
        List<Usuario> listaUsuarios(string usuario, int status);
        void Salvar(Usuario obj);
        void Remover(Guid id);
        void Ativar(Guid id);
        byte[] Imprimir(string usuario, int status);
    }
}
