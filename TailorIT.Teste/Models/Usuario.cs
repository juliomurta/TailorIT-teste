using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TailorIT.Teste.Models
{
    public class Usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("UsuarioId", TypeName = "integer")]
        public int Id { get; set; }

        [Column("Nome", TypeName = "nvarchar(200)")]
        public string Nome { get; set; }

        [Column("DataNascimento", TypeName = "datetime")]
        public DateTime DataNascimento { get; set; }

        [Column("Email", TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column("Senha", TypeName = "nvarchar(30)")]
        public string Senha { get; set; }

        [Column("Ativo", TypeName = "bit")]
        public bool Ativo { get; set; }

        [Column("SexoId", TypeName = "int")]
        public int SexoId { get; set; }

        public Sexo Sexo { get; set; }
    }
}
