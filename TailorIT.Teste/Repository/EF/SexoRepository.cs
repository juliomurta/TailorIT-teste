using System;
using System.Collections.Generic;
using System.Linq;
using TailorIT.Teste.Models;

namespace TailorIT.Teste.Repository.EF
{
    public class SexoRepository : IRepository<Sexo>
    {
        private ApplicationDbContext context;

        public SexoRepository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }

        public void Inserir(Sexo entidade)
        {
            this.context.Sexos.Add(entidade);
            this.context.SaveChanges();
        }

        public List<Sexo> Listar(Func<Sexo, bool> lambda = null)
        {
            if (lambda == null)
            {
                return this.context.Sexos.ToList();
            }
            else
            {
                return this.context.Sexos.Where(lambda).ToList();
            }
        }
    }
}
