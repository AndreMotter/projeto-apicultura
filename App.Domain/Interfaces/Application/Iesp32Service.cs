
using Autenticador.Domain.DTOs.Auth;

namespace App.Domain.Interfaces.Application
{
    public interface IEsp32Service
    {
        bool Entrar(string token);
        bool EntrarCodigo(string codigo);
    }
}
