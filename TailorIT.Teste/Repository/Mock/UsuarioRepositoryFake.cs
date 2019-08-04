using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailorIT.Teste.Models;

namespace TailorIT.Teste.Repository
{
    public class UsuarioRepositoryFake : IRepository<Usuario>
    {
        private List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario
            {
                Ativo = true,
                DataNascimento = DateTime.Now,
                Email = "teste@teste.com",
                Id = 1,
                Nome = "Teste 1",
                Senha = "2222",
                Sexo = new Sexo
                {
                    Id = 1,
                    Descricao = "Masculino"
                }
            },
            new Usuario
            {
                Ativo = true,
                DataNascimento = DateTime.Now,
                Email = "teste@teste.com",
                Id = 2,
                Nome = "Teste 2",
                Senha = "2222",
                Sexo = new Sexo
                {
                    Id = 2,
                    Descricao = "Masculino"
                }
            },
            new Usuario
            {
                Ativo = true,
                DataNascimento = DateTime.Now,
                Email = "teste@teste.com",
                Id = 3,
                Nome = "Teste 3",
                Senha = "2222",
                Sexo = new Sexo
                {
                    Id = 1,
                    Descricao = "Masculino"
                }
            },
            new Usuario
            {
                Ativo = false,
                DataNascimento =  DateTime.Now,
                Email = "teste@teste.com",
                Id = 4,
                Nome = "Teste 4",
                Senha = "2222",
                Sexo = new Sexo
                {
                    Id = 1,
                    Descricao = "Masculino"
                }
            },
            new Usuario
            {
                Ativo = false,
                DataNascimento = DateTime.Now,
                Email = "teste@teste.com",
                Id = 5,
                Nome = "Teste 5",
                Senha = "2222",
                Sexo = new Sexo
                {
                    Id = 1,
                    Descricao = "Masculino"
                }
            }
        };
        public void Inserir(Usuario entidade)
        {
            this.usuarios.Add(entidade);
        }

        public List<Usuario> Listar(Func<Usuario, bool> lambda = null)
        {
            if (lambda == null)
            {
                return this.usuarios;
            }
            else
            {
                return this.usuarios.Where(lambda).ToList();
            }
        }
    }
}
