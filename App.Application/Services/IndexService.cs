using App.Application.Helpers;
using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
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

        public RetornoLoginDTO Logar(LoginDTO login)
        {
            if (String.IsNullOrEmpty(login.Usuario))
            {
                throw new Exception("Informe o login");
            }
            if (String.IsNullOrEmpty(login.Senha))
            {
                throw new Exception("Informe a senha");
            }

            var obj = _repository.Query(x => x.Senha == login.Senha.Sha512() && x.Nome.Trim().ToUpper() == login.Usuario.Trim().ToUpper()).FirstOrDefault();
            if(obj == null)
            {
                throw new Exception("Usuário ou senha incorretos");
            }
            else
            {
                return new RetornoLoginDTO
                {
                    IdUsuario = obj.Id,
                    NomeUsuario = obj.Nome,
                };
            }
        }
    }
}
