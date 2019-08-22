using Suframa.DemoSuframa.DataAccess;
using Suframa.DemoSuframa.DataAccess.Database.Entities;
using Suframa.Sciex.CrossCutting.DataTransferObject.ViewModel;
using Suframa.Sciex.CrossCutting.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Suframa.FrameworkSuframa.CrossCutting.DataTransferObject.ViewModel;
using Suframa.FrameworkSuframa.DataAccess.Database.Entities;

namespace Suframa.FrameworkSuframa.BusinessLogic
{
    public interface IPessoaBll
    {
        IEnumerable<PessoaVM> Listar(PessoaVM pessoa);
        PessoaEntity Selecionar(int id);
        PessoaVM Salvar(PessoaVM entidade);
        PessoaVM RegrasSalvar(PessoaVM pessoaVM);

    }
}
