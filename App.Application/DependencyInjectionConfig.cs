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
            services.AddTransient<IHistoricoAcessosService, Abe_logService>();

            //HoneyTrack
            services.AddTransient<IIndexService, IndexService>();
            services.AddTransient<IAbe_racaService, Abe_racaService>();
            services.AddTransient<IAbe_colmeiaService, Abe_colmeiaService>();
            services.AddTransient<IAbe_apicultorService, Abe_apicultorService>();
            services.AddTransient<IAbe_leituraService, Abe_leituraService>();
        }
    }
}
