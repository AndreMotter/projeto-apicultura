using App.Domain.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Interfaces.Application
{
    public interface IAbe_leituraService
    {
        abe_leitura BuscaPorId(Guid id);
        List<abe_leitura> ListaAbe_leitura(Guid? col_codigo, Guid? tip_codigo, DateTime? data_inicial, DateTime? data_final);
    }
}
