using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services
{
    public class Abe_apicultorService : IAbe_apicultorService
    {
        private IRepositoryBase<abe_apicultor> _repository { get; set; }
        public Abe_apicultorService(IRepositoryBase<abe_apicultor> repository)
        {
            _repository = repository;
        }
        public abe_apicultor BuscaPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o código!");
            }
            var obj = _repository.Query(x => x.api_codigo == id).FirstOrDefault();
            return obj;
        }

        public List<abe_apicultor> ListaAbe_apicultor(string Abe_apicultor)
        {
            Abe_apicultor = Abe_apicultor ?? "";
            return _repository.Query(x => x.api_nome.ToUpper().Contains(Abe_apicultor.ToUpper())).Select(p => new abe_apicultor
            {
                api_codigo = p.api_codigo,
                api_nome = p.api_nome,
                api_cpfcnpj = p.api_cpfcnpj,
                api_status = p.api_status,
            }).OrderByDescending(x => x.api_nome).ToList();
        }
        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public void Salvar(abe_apicultor obj)
        {
            if (String.IsNullOrEmpty(obj.api_nome))
            {
                throw new Exception("Informe a descrição!");
            }

            if (obj.api_codigo == Guid.Empty)
            {
                _repository.Save(obj);
            }
            else
            {
                _repository.Update(obj);
            }

            _repository.SaveChanges();
        }
    }
}
