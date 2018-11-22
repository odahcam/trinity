using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Trinity.Infra.CrossCutting.Swagger
{
    public class SwaggerConfig
    {
        public static void UseSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trinity API V1");
                c.RoutePrefix = string.Empty;
            });
        }

        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Trinity API",
                    Description = "ASP.NET Core Web API for Bands, Albums and Musics management",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Tyler Mendes de Brito",
                        Email = "tyler.brito99@gmail.com",
                        Url = "https://github.com/tylerbryto"
                    },
                });

                string xmlFile = "Trinity.Presentation.WebApi.xml";//$"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
