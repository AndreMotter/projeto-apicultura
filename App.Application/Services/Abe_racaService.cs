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
                throw new Exception("Informe o código!");
            }
            var obj = _repository.Query(x => x.rac_codigo == id).FirstOrDefault();
            return obj;
        }

        public List<abe_raca> ListaAbe_raca(string rac_descricao, int rac_status)
        {
            rac_descricao = rac_descricao ?? "";
            return _repository.Query(x => x.rac_descricao.ToUpper().Contains(rac_descricao.ToUpper())
            && rac_status == 0 ? (x.rac_status == false || x.rac_status == true) : x.rac_status == (rac_status == 1 ? true : false)).Select(p => new abe_raca
            {
                rac_codigo = p.rac_codigo,
                rac_descricao = p.rac_descricao,
                rac_origem = p.rac_origem,
                rac_status = p.rac_status,
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
                throw new Exception("Informe a descrição!");
            }

            if (obj.rac_codigo == Guid.Empty)
            {
                obj.rac_status = true;
                _repository.Save(obj);
            }
            else
            {
                _repository.Update(obj);
            }

            _repository.SaveChanges();
        }

        public void Ativar(Guid id)
        {
            var obj = BuscaPorId(id);
            if (obj.rac_status)
            {
                obj.rac_status = false;
            }
            else
            {
                obj.rac_status = true;
            }
            _repository.Update(obj);
            _repository.SaveChanges();
        }
    }
}
