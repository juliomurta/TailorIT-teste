using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TailorIT.Teste.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {

        }
        public UsuarioViewModel(Usuario usuario)
        {
            this.Nome = usuario.Nome;
            this.Ativo = usuario.Ativo;
            this.DataNascimento = usuario.DataNascimento.ToString("dd/MM/yyyy");
            this.Email = usuario.Email;
            this.SexoId = usuario.Sexo.Id.ToString();
        }


        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Nome precisa ter no mínimo 3 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório")]
        [Display(Name = "Sexo")]
        public string SexoId { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public Usuario GetUsuario()
        {
            return new Usuario
            {
                Nome = this.Nome,
                Email = this.Email,
                DataNascimento = Convert.ToDateTime(this.DataNascimento),
                Senha = this.Senha,
                SexoId = Convert.ToInt32(this.SexoId)
            };
        }
    }
}
