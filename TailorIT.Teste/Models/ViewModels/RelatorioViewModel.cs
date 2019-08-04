using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TailorIT.Teste.Models.ViewModels
{
    public class RelatorioViewModel
    {
        public List<UsuarioViewModel> Usuarios { get; set; }

        public FiltrosViewModel Filtros { get; set; }
    }
}
