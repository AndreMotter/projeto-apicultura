using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services
{
    public class Abe_colmeiaService : IAbe_colmeiaService
    {
        private IRepositoryBase<abe_colmeia> _repository { get; set; }
        public Abe_colmeiaService(IRepositoryBase<abe_colmeia> repository)
        {
            _repository = repository;
        }
        public abe_colmeia BuscaPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o código!");
            }
            var obj = _repository.Query(x => x.rac_codigo == id).FirstOrDefault();
            return obj;
        }

        public List<abe_colmeia> ListaAbe_colmeia(string col_descricao, int col_status)
        {
            col_descricao = col_descricao ?? "";
            return _repository.Query(x => x.col_descricao.ToUpper().Contains(col_descricao.ToUpper())
            && col_status == 0 ? (x.col_status == false || x.col_status == true) : x.col_status == (col_status == 1 ? true : false)).Select(p => new abe_colmeia
            {
                col_codigo = p.col_codigo,
                col_numero = p.col_numero,
                col_datainstalacao = p.col_datainstalacao,
                col_descricao = p.col_descricao,
                col_status = p.col_status,
                abe_raca = new abe_raca
                {
                    rac_descricao = p.abe_raca.rac_descricao,
                },
            }).OrderByDescending(x => x.col_descricao).ToList();
        }
        public void Remover(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public void Salvar(abe_colmeia obj)
        {
            if (String.IsNullOrEmpty(obj.col_descricao))
            {
                throw new Exception("Informe a descrição!");
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
