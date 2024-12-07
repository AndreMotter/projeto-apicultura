using System;

namespace App.Domain.Interfaces.Application
{
    public interface IReportService
    {
        byte[] ImprimirAbe_raca(string rac_descricao, int rac_status);
        byte[] ImprimirAbe_colmeia(string col_descricao, int col_status);
        byte[] ImprimirAbe_leitura(Guid? col_codigo, Guid? tip_codigo, DateTime? data_inicial, DateTime? data_final);
    }
}
