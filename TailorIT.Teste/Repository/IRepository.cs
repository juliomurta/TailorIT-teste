using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TailorIT.Teste.Repository
{
    public interface IRepository<T>
    {
        void Inserir(T entidade);

        List<T> Listar(Func<T, bool> lambda = null);
    }
}
