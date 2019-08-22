using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Suframa.Sciex.DataAccess.Database.Entities
{
    [Table("CADSUF_PAIS")]
    public partial class PaisEntity 
    {
        [Required]
        [StringLength(50)]
        [Column("PAI_DS")]
        public string Descricao { get; set; }

        [Key]
        [Column("PAI_ID")]
        public int IdPais { get; set; }

		[Column("PAI_CO")]
		public string CodigoPais { get; set; }
    }
}