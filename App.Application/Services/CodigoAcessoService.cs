using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class CodigoAcessoService : ICodigoAcessoService
    {
        private IRepositoryBase<CodigoAcesso> _repository { get; set; }

        public CodigoAcessoService(IRepositoryBase<CodigoAcesso> repository)
        {
            _repository = repository;
        }

        public string Gerar()
        {
            Random random = new Random();
            CodigoAcesso CodigoAcesso = new CodigoAcesso() 
            {
                Codigo = new string(Enumerable.Repeat("123456789", 6).Select(s => s[random.Next(s.Length)]).ToArray())
            };

            var UltimoCodigo = _repository.Query(x => x.Id == x.Id).FirstOrDefault();
            if(UltimoCodigo != null)
            {
                this.Remover(UltimoCodigo.Id);
            }
            this.Salvar(CodigoAcesso);
            return CodigoAcesso.Codigo;
        }

        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public void Salvar(CodigoAcesso obj)
        {
            _repository.Save(obj);
            _repository.SaveChanges();
        }

    }
}
