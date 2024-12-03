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
            services.AddTransient<ICodigoAcessoService, CodigoAcessoService>();
            services.AddTransient<IHistoricoAcessosService, HistoricoAcessosService>();
            services.AddTransient<IIndexService, IndexService>();
            services.AddTransient<INfcService, NfcService>();
            services.AddTransient<IEsp32Service, Esp32Service>();

            //HoneyTrack
            services.AddTransient<IAbe_racaService, Abe_racaService>();
            services.AddTransient<IAbe_colmeiaService, Abe_colmeiaService>();
        }
    }
}
