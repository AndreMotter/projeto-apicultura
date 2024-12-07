using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Application.Services
{
    public class Abe_leituraService : IAbe_leituraService
    {
        private IRepositoryBase<abe_leitura> _repository { get; set; }
        private IRepositoryBase<abe_tipodeitura> _repositoryAbe_tipodeitura { get; set; }
        public Abe_leituraService(IRepositoryBase<abe_leitura> repository, IRepositoryBase<abe_tipodeitura> repositoryAbe_tipodeitura)
        {
            _repository = repository;
            _repositoryAbe_tipodeitura = repositoryAbe_tipodeitura;
        }
        public abe_leitura BuscaPorId(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("Informe o código!");
            }
            var obj = _repository.Query(x => x.lei_codigo == id).FirstOrDefault();
            return obj;
        }

        public List<abe_leitura> ListaAbe_leitura(Guid? col_codigo, Guid? tip_codigo, DateTime? data_inicial, DateTime? data_final)
        {
            var query = _repository.Query(x => 1 == 1);

            if (data_inicial.HasValue && data_final.HasValue)
            {
                query = query.Where(x => x.lei_data >= Convert.ToDateTime(data_inicial).ToUniversalTime() && x.lei_data <= Convert.ToDateTime(data_final).ToUniversalTime());
            }

            if(col_codigo != Guid.Empty && col_codigo != null)
            {
                query = query.Where(x => x.col_codigo == col_codigo);
            }

            if (tip_codigo != Guid.Empty && tip_codigo != null)
            {
                query = query.Where(x => x.tip_codigo == tip_codigo);
            }

            var lista = query.Select(p => new abe_leitura
            {
                lei_data = p.lei_data,
                lei_valor = p.lei_valor,
                abe_colmeia = new abe_colmeia
                {
                    col_descricao = p.abe_colmeia.col_descricao,
                },
                abe_tipodeitura = new abe_tipodeitura
                {
                    tip_descricao = p.abe_tipodeitura.tip_descricao,
                    abe_unidademedida = new abe_unidademedida
                    {
                        uni_descricao = p.abe_tipodeitura.abe_unidademedida.uni_descricao,
                        uni_representante = p.abe_tipodeitura.abe_unidademedida.uni_representante
                    }
                },
            }).OrderByDescending(x => x.lei_data).ToList();

            return lista;
        }

        public List<abe_tipodeitura> ListaAbe_tipoleitura()
        {
            return _repositoryAbe_tipodeitura.Query(x => 1 == 1).Select(p => new abe_tipodeitura
            {
                tip_codigo = p.tip_codigo,
                tip_descricao = p.tip_descricao,
            }).ToList();
        }
    }
}
