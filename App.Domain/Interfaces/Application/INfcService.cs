using App.Domain.Entities;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace App.Domain.Interfaces.Application
{
    public interface INfcService
    {
        Nfc BuscaPorId(Guid id);
        List<Nfc> Listar(string usuario, int status);
        void Ativar(Guid id);
        void Remover(Guid id);
        void Salvar(Nfc obj);
    }
}