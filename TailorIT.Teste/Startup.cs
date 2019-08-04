using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TailorIT.Teste.Models;
using TailorIT.Teste.Repository;
using TailorIT.Teste.Repository.EF;
using TailorIT.Teste.Repository.Mock;
using Microsoft.EntityFrameworkCore;

namespace TailorIT.Teste
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            this.Configuration = new ConfigurationBuilder()
                                    .SetBasePath(env.ContentRootPath)
                                    .AddJsonFile("appsettings.json")
                                    .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:TailorITData:ConnectionString"]));
            //services.AddTransient<IRepository<Usuario>, UsuarioRepositoryFake>();
            //services.AddTransient<IRepository<Sexo>, SexoRepositoryFake>();
            services.AddTransient<IRepository<Usuario>, UsuarioRepository>();
            services.AddTransient<IRepository<Sexo>, SexoRepository>();
            services.AddMvc();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {         
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { Controller = "Usuario", action = "Listar" }
                );

                routes.MapRoute(name: null, template: "{controller}/{action}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
