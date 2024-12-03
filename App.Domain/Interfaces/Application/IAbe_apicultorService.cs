using App.Domain.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Interfaces.Application
{
    public interface IAbe_apicultorService
    {
        abe_apicultor BuscaPorId(Guid id);
        List<abe_apicultor> ListaAbe_apicultor(string Abe_apicultor);
        void Salvar(abe_apicultor obj);
        void Remover(Guid id);
    }
}
