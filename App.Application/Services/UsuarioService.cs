using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IRepositoryBase<Usuario> _repository { get; set; }
        public UsuarioService(IRepositoryBase<Usuario> repository)
        {
            _repository = repository;
        }
        public Usuario BuscaPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o id");
            }
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Usuario> listaUsuarios(string busca)
        {

            busca = busca ?? "";
            return _repository.Query(x => x.Nome.ToUpper().Contains(busca.ToUpper())/* && (pesoMaiorQue == 0 || x.Peso >= pesoMaiorQue) &&  (pesoMenorQue == 0 || x.Peso <= pesoMenorQue*/
            ).Select(p => new Usuario
            {
                Id = p.Id,
                Nome = p.Nome,
                Cidade = new Cidade
                {
                    Nome = p.Cidade.Nome
                },
                Ativo = p.Ativo,
                DataNascimento = p.DataNascimento
            }).OrderByDescending(x => x.Nome).ToList();
        }
        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public void Salvar(Usuario obj)
        {
            if (String.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informe o nome");
            }
            _repository.Save(obj);
            _repository.SaveChanges();
        }
    }
}
