using App.Application.Helpers;
using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Enum;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using Autenticador.Domain.DTOs.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace App.Application.Services
{
    public class IndexService : IIndexService
    {
        private IRepositoryBase<Usuario> _repository { get; set; }
        public IndexService(IRepositoryBase<Usuario> repository)
        {
            _repository = repository;
        }

        public AuthData Logar(LoginDTO login)
        {
            if (String.IsNullOrEmpty(login.Usuario))
            {
                throw new Exception("Informe o login");
            }
            if (String.IsNullOrEmpty(login.Senha))
            {
                throw new Exception("Informe a senha");
            }

            var obj = _repository.Query(x => x.Senha.Trim() == login.Senha.Trim() && x.Login.Trim() == login.Usuario.Trim()).FirstOrDefault();
            if (obj == null)
            {
                throw new Exception("Usuário ou senha incorretos");
            }
            else
            {
                if (obj.Permissao == 1)
                {
                    return new AuthData(obj.Id, PermissaoEnum.Administrador);
                }
                else
                {
                    return new AuthData(obj.Id, PermissaoEnum.Cliente);
                }

            }
        }

        public Usuario Autenticado(AuthData auth)
        {
            var obj = _repository.Query(x => x.Id == auth.IdUsuario).Select(x => new Usuario
            {
                Id = x.Id,
                Nome = x.Nome,
                Login = x.Login,
                Permissao = x.Permissao,
            }).FirstOrDefault();
            return obj;
        }
    }
}
