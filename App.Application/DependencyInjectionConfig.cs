using App.Application.Services;
using App.Domain.Interfaces.Application;
using Microsoft.Extensions.DependencyInjection;

namespace App.Application
{
    public class DependencyInjectionConfig
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ICidadeService, CidadeService>();
            services.AddTransient<ICodigoAcessoService, CodigoAcessoService>();
            services.AddTransient<IHistoricoAcessosService, HistoricoAcessosService>();
            services.AddTransient<IIndexService, IndexService>();
        }
    }
}
