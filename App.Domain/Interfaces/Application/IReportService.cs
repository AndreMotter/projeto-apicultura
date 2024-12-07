namespace App.Domain.Interfaces.Application
{
    public interface IReportService
    {
        byte[] ImprimirAbe_raca(string rac_descricao, int rac_status);
        byte[] ImprimirAbe_colmeia(string col_descricao, int col_status);
    }
}
