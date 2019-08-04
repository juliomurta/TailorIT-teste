using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailorIT.Teste.Models;

namespace TailorIT.Teste.Repository.Mock
{
    public class SexoRepositoryFake : IRepository<Sexo>
    {
        public void Inserir(Sexo entidade)
        {
            throw new NotImplementedException();
        }

        public List<Sexo> Listar(Func<Sexo, bool> lambda = null)
        {
            return new List<Sexo>
            {
                new Sexo
                {
                    Id = 1,
                    Descricao = "Masculino"
                },
                new Sexo
                {
                    Id = 2,
                    Descricao = "Feminino"
                }
            };
        }
    }
}
