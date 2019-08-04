using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TailorIT.Teste.Models;
using TailorIT.Teste.Repository.EF;

namespace TailorIT.Teste.Repository
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private ApplicationDbContext context;

        public UsuarioRepository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }

        public void Inserir(Usuario entidade)
        {
            this.context.Usuarios.Add(entidade);
            this.context.SaveChanges();
        }

        public List<Usuario> Listar(Func<Usuario, bool> lambda = null)
        {
            if (lambda == null)
            {
                return this.context.Usuarios
                                   .Include(x => x.Sexo)
                                   .ToList();
            }
            else
            {
                return this.context.Usuarios
                                   .Include(x => x.Sexo)
                                   .Where(lambda)
                                   .ToList();
            }
        }
    }
}
