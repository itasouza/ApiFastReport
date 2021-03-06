using DevIO.Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using FastReport.Data;


namespace DevIO.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FastReport Community em NETCore 5",
                    Version = "v1",
                    TermsOfService = new Uri("http://tasdigital.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Itamar Souza",
                        Email = "itasouza@yahoo.com.br",
                        Url = new Uri("http://tasdigital.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termos de Licenciamento de Uso da API",
                        Url = new Uri("http://tasdigital.com.br/termosdelicenciamento")
                    }
                });
            });


            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));


            //configura??o de Resili?ncia da conex?o
            services.AddDbContext<MeuDbContext>(options => {

                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                 p => p.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null));
                options.EnableSensitiveDataLogging(true).EnableDetailedErrors();

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FastReport Community");
                    //c.RoutePrefix = string.Empty;

                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseFastReport();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
