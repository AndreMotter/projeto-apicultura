namespace App.Domain.Interfaces.Application
{
    public interface IReportService
    {
        byte[] ImprimirAbe_raca(string rac_descricao, int rac_status);
    }
}
