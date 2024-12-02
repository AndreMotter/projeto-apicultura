using App.Domain.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Interfaces.Application
{
    public interface IAbe_colmeiaService
    {
        abe_colmeia BuscaPorId(Guid id);
        List<abe_colmeia> ListaAbe_colmeia(string Abe_colmeia);
        void Salvar(abe_colmeia obj);
        void Remover(Guid id);
    }
}
