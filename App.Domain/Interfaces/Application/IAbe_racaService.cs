using App.Domain.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Interfaces.Application
{
    public interface IAbe_racaService
    {
        abe_raca BuscaPorId(Guid id);
        List<abe_raca> ListaAbe_raca(string abe_raca);
        void Salvar(abe_raca obj);
        void Remover(Guid id);
    }
}
