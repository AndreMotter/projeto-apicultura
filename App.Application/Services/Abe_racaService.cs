using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services
{
    public class Abe_racaService : IAbe_racaService
    {
        private IRepositoryBase<abe_raca> _repository { get; set; }
        public Abe_racaService(IRepositoryBase<abe_raca> repository)
        {
            _repository = repository;
        }
        public abe_raca BuscaPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o id");
            }
            var obj = _repository.Query(x => x.rac_codigo == id).FirstOrDefault();
            return obj;
        }

        public List<abe_raca> ListaAbe_raca(string abe_raca)
        {
            abe_raca = abe_raca ?? "";
            return _repository.Query(x => x.rac_descricao.ToUpper().Contains(abe_raca.ToUpper())).Select(p => new abe_raca
            {
                rac_codigo = p.rac_codigo,
                rac_descricao = p.rac_descricao,
                rac_origem = p.rac_origem,
            }).OrderByDescending(x => x.rac_descricao).ToList();
        }
        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public void Salvar(abe_raca obj)
        {
            if (String.IsNullOrEmpty(obj.rac_descricao))
            {
                throw new Exception("Informe a descrição");
            }

            if (obj.rac_codigo == Guid.Empty)
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
