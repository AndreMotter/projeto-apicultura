using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services
{
    public class NfcService : INfcService
    {
        private IRepositoryBase<Nfc> _repository { get; set; }
        public NfcService(IRepositoryBase<Nfc> repository)
        {
            _repository = repository;
        }

        public Nfc BuscaPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o id");
            }
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Nfc> Listar(string usuario, int status)
        {

            usuario = usuario ?? "";
            var listaQuery = _repository.Query(x => EF.Functions.Like(x.Usuario.Nome.ToUpper(), $"%{usuario.ToUpper()}%")
             && status == 0 ? (x.Ativo == false || x.Ativo == true) : x.Ativo == (status == 1 ? true : false));
            var lista = listaQuery.Select(p => new Nfc
            {
                Id = p.Id,
                Token = p.Token,
                Usuario = new Usuario
                {
                    Nome = p.Usuario.Nome
                },
                Ativo = p.Ativo,
            }).OrderByDescending(x => x.Token)
            .ToList();
            return lista;
        }

        public void Ativar(Guid id)
        {
            var obj = BuscaPorId(id);
            if (obj.Ativo)
            {
                obj.Ativo = false;
            }
            else
            {
                obj.Ativo = true;
            }
            _repository.Update(obj);
            _repository.SaveChanges();
        }

        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
    }
}
