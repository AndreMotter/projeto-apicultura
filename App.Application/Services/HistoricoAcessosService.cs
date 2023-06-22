using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services
{
    public class HistoricoAcessosService : IHistoricoAcessosService
    {
        private IRepositoryBase<HistoricoAcessos> _repository { get; set; }
        public HistoricoAcessosService(IRepositoryBase<HistoricoAcessos> repository)
        {
            _repository = repository;
        }

        public List<HistoricoAcessos> Listar(string busca)
        {
            busca = busca ?? "";
            var lista = _repository.Query(x => x.Descricao.ToUpper().Contains(busca.ToUpper())
            ).Select(p => new HistoricoAcessos
            {
                Id = p.Id,
                Descricao = p.Descricao,
                Usuario = new Usuario
                {
                    Nome = p.Usuario.Nome
                },
                Hora = p.Hora,
                Operacao = p.Operacao
            }).OrderByDescending(x => x.Descricao).ToList();
            return lista;
        }
    }
}
