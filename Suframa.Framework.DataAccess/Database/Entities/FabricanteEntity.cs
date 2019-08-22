using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Suframa.DemoSuframa.DataAccess.Database.Entities
{
    [Table("FABRICANTE")]
    public class FabricanteEntity
    {

        [Key]
        [Column("FAB_ID")]
        public int IdFabricante { get; set; }

        [Required]
        [StringLength(60)]
        [Column("FAB_DS_RAZAO_SOCIAL")]
        public string RazaoSocial { get; set; }

        [Required]
        [StringLength(40)]
        [Column("FAB_DS_LOGRADOURO")]
        public string Logradouro { get; set; }

        [Required]
        [StringLength(6)]
        [Column("FAB_NU")]
        public string Numero { get; set; }

        [StringLength(21)]
        [Column("FAB_DS_COMPLEMENTO")]
        public string Complemento { get; set; }

        [StringLength(14)]
        [Column("IMP_NU_CNPJ")]
        public string CNPJImportador { get; set; }

        [Required]
        [StringLength(25)]
        [Column("FAB_DS_CIDADE")]
        public string Cidade { get; set; }

        [Required]
        [StringLength(25)]
        [Column("FAB_DS_ESTADO")]
        public string Estado { get; set; }

        [StringLength(3)]
        [Column("PAI_CO")]
        public string CodigoPais { get; set; }

        [StringLength(50)]
        [Column("PAI_DS")]
        public string DescricaoPais { get; set; }
    }
}
