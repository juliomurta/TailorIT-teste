using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TailorIT.Teste.Models;

namespace TailorIT.Teste.Repository.EF
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if (!context.Sexos.Any())
            {
                context.Sexos.AddRange(
                    new Sexo
                    {
                        Descricao = "Masculino"
                    },
                    new Sexo
                    {                     
                        Descricao = "Feminino"
                    }
                );
            }
            
            context.SaveChanges();
        }
    }
}
