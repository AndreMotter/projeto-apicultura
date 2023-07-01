using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;

namespace App.Application.Services
{
    public class Esp32Service : IEsp32Service
    {
        private IRepositoryBase<Usuario> _repository { get; set; }
        public Esp32Service(IRepositoryBase<Usuario> repository)
        {
            _repository = repository;
        }
        public string TesteApi()
        {
            return "RETORNO COM SUCESSO! PAU NO CU DO INTER!";
        }
    }
}
