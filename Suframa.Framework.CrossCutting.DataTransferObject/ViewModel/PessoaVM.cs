using System;
using System.Collections.Generic;
using System.Text;

namespace Suframa.FrameworkSuframa.CrossCutting.DataTransferObject.ViewModel
{
    public class PessoaVM
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CNPJImportador { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
