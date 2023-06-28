using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Application
{
    public interface IHistoricoAcessosService
    {
        List<HistoricoAcessos> Listar(string usuario, DateTime? dataInicial, DateTime? DataFinal);
        byte[] Imprimir(string usuario, DateTime? dataInicial, DateTime? DataFinal);
    }
}
