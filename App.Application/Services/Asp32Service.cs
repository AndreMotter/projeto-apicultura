using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;

namespace App.Application.Services
{
    public class Asp32Service : IAsp32Service
    {
        private IRepositoryBase<Usuario> _repository { get; set; }
        public Asp32Service(IRepositoryBase<Usuario> repository)
        {
            _repository = repository;
        }
        public string TesteApi()
        {
            return "RETORNO COM SUCESSO! PAU NO CU DO INTER!";
        }
    }
}
