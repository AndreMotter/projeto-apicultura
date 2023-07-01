using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace App.Application.Services
{
    public class Esp32Service : IEsp32Service
    {
        private IRepositoryBase<Nfc> _repository { get; set; }
        public Esp32Service(IRepositoryBase<Nfc> repository)
        {
            _repository = repository;
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
    }
}
