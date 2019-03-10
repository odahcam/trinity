using Microsoft.Extensions.DependencyInjection;
using Trinity.Application.Interfaces;
using Trinity.Application.Services;
using Trinity.Application.Validators;
using Trinity.Domain.Repositories;
using Trinity.Infra.Data.Context;
using Trinity.Infra.Data.Repositories;

namespace Trinity.Infra.CrossCutting.IoC
{
    public class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // use as Lazy<TService>
            services.AddTransient(typeof(Lazy<>), typeof(Lazier<>));
            
            //Infra.Data
            services.AddScoped<IMusicRepository, MusicRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IBandRepository, BandRepository>();
            services.AddScoped<TrinityContext>();

            //Application
            services.AddScoped<IMusicAppService, MusicAppService>();
            services.AddScoped<IBandAppService, BandAppService>();
            services.AddScoped<IAlbumAppService, AlbumAppService>();
            services.AddScoped<BandValidator>();
            services.AddScoped<MusicValidator>();
            services.AddScoped<AlbumValidator>();
        }
    }
}
