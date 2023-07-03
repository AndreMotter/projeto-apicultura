using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services
{
    public class CidadeService : ICidadeService
    {
        private IRepositoryBase<Cidade> _repository { get; set; }
        private IRepositoryBase<Usuario> _usuario_repository { get; set; }
        public CidadeService(IRepositoryBase<Cidade> repository, IRepositoryBase<Usuario> usuario_repository)
        {
            _repository = repository;
            _usuario_repository = usuario_repository;
        }
        public Cidade BuscaPorCep(string cep)
        {
            if (!String.IsNullOrEmpty(cep))
            {
                throw new Exception("Informe o CEP!");
            }
            var obj = _repository.Query(x => x.Cep == cep).FirstOrDefault();
            return obj;
        }

        public Cidade BuscaPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o id!");
            }
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Cidade> listaCidades(string busca)
        {
            busca = (busca ?? "").ToUpper();
            return _repository.Query(x => (x.Nome.ToUpper().Contains(busca) || x.Cep.ToUpper().Contains(busca) || x.Uf.ToUpper().Contains(busca) )

            ).ToList();
        }

        public void Remover(Guid id)
        {
            var usuarios = _usuario_repository.Query(x => x.CidadeId == id).ToList();
            if (usuarios.Count > 0)
            {
                throw new Exception("Existem usuário com essa cidade, ela não pode ser excluída");
            }
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public void Salvar(Cidade obj)
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
