using App.Domain.DTO;
using App.Domain.Entities;
using Autenticador.Domain.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Application
{
    public interface IIndexService
    {
        AuthData Logar(LoginDTO login);
        Usuario Autenticado(AuthData auth);
    }
}
