using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TailorIT.Teste.Models
{
    public class Sexo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("SexoId", TypeName = "integer")]
        public int Id { get; set; }

        [Column("Descricao", TypeName = "nvarchar(15)")]
        public string Descricao { get; set; }
    }
}
