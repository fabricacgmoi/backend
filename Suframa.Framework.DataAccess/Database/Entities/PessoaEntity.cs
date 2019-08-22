using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suframa.FrameworkSuframa.DataAccess.Database.Entities
{
    [Table("Pessoa")]
    public partial class PessoaEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [StringLength(100)]
        [Column("nome")]
        public string Nome { get; set; }

        [StringLength(100)]
        [Column("nome")]
        public string Email { get; set; }
    }
}
