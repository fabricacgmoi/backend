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
    public class PessoaBll: IPessoaBll
    {
        private readonly Suframa.DemoSuframa.DataAccess.AppContext _context;

        public PessoaBll(Suframa.DemoSuframa.DataAccess.AppContext context)
        {
            _context = context;
        }

        public IEnumerable<PessoaVM> Listar(PessoaVM pessoa)
        {
            var items = _context.Pessoa.Select(x => new PessoaVM
            {
                Id = x.Id,
                Nome = x.Nome,
                Email = x.Email
            });

            if (pessoa == null)
            {
                return items;
            }
            else if (pessoa != null && pessoa.Id > 0)
            {
                return items.Where(x => x.Id == pessoa.Id);
            }
            else if (pessoa.Nome != null)
            {
                return items.Where(x => x.Nome.ToLower().Contains(pessoa.Nome));
            }

            return items;
        }

        public PessoaEntity Selecionar(int id)
        {
            return new PessoaEntity();
        }

        public PessoaEntity Apagar(int id)
        {
            var entidade = _context.Pessoa.Single(x => x.Id == id);
            _context.Pessoa.Remove(entidade);

            _context.SaveChanges();

            return new PessoaEntity();
        }

        public PessoaVM Salvar(PessoaVM entidade)
        {
            return RegrasSalvar(entidade);
        }

        public PessoaVM RegrasSalvar(PessoaVM pessoaVM)
        {
            PessoaEntity entityPessoa = new PessoaEntity();


            if (pessoaVM.Id != null)
            {
                entityPessoa = _context.Pessoa.FirstOrDefault(x => x.Id == pessoaVM.Id);
                entityPessoa.Id = pessoaVM.Id.Value;

                _context.Entry(entityPessoa).State = EntityState.Modified;
            }

            entityPessoa.Nome = pessoaVM.Nome;
            entityPessoa.Email = pessoaVM.Email;
            

            if (pessoaVM.Id != null)
            {
                _context.Pessoa.Update(entityPessoa);
            }
            else
            {
                _context.Pessoa.Add(entityPessoa);

            }

            _context.SaveChanges();

            return pessoaVM;
        }
    }
}
