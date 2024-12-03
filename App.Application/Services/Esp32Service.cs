﻿using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using Autenticador.Domain.DTOs.Auth;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Linq;

namespace App.Application.Services
{
    public class Esp32Service : IEsp32Service
    {
        private IRepositoryBase<Nfc> _repository { get; set; }
        private IRepositoryBase<HistoricoAcessos> _usuario_repository { get; set; }
        public Esp32Service(IRepositoryBase<Nfc> repository, 
            IRepositoryBase<HistoricoAcessos> usuario_repository)
        {
            _repository = repository;
            _usuario_repository = usuario_repository;
        }
        public bool Entrar(string token)
        {
            var query = _repository.Query(x => x.Token.Trim().ToUpper() == token.Trim().ToUpper());
            var nfc = query.FirstOrDefault();

            if (nfc != null)
            {
                nfc = query.Where(x => x.Ativo == true).FirstOrDefault();
                if (nfc != null)
                {
                    CultureInfo cultura = new CultureInfo("pt-BR");
                    DateTime data = DateTime.Now;
                    var historico = new HistoricoAcessos()
                    {
                        Descricao = $@"Entrou na porta as {data.ToString("HH:mm")} na data de {data.ToString("dd", cultura)} de {cultura.DateTimeFormat.GetMonthName(data.Month)} de {data.ToString("yyyy")}",
                        Operacao = 1,
                        Data = DateTime.Now.ToUniversalTime(),
                        UsuarioId = (Guid)nfc.UsuarioId,
                    };
                    _usuario_repository.Save(historico);
                    _usuario_repository.SaveChanges();

                    return true;
                }
                else
                {
                    throw new Exception("NFC encontrado mas entra-se desativado!");
                }
            }
            else
            {
                throw new Exception("NFC não encontrado!");
            }
        }

        public bool EntrarCodigo(string codigo)
        {
            return true;
        }
    }
}
