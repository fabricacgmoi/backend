using Suframa.DemoSuframa.DataAccess;
using Suframa.DemoSuframa.DataAccess.Database.Entities;
using Suframa.Sciex.CrossCutting.DataTransferObject.ViewModel;
using Suframa.Sciex.CrossCutting.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Suframa.DemoSuframa.BusinessLogic
{
    public class FabricanteBll
    {
        private readonly DataAccess.AppContext _context;

        public FabricanteBll(DataAccess.AppContext context)
        {
            _context = context;
        }

        public IEnumerable<FabricanteVM> Listar(FabricanteVM fabricante)
        {
            var items = _context.Fabricante.Select(x => new FabricanteVM
            {
                IdFabricante = x.IdFabricante,
                CNPJImportador = x.CNPJImportador,
                RazaoSocial = x.RazaoSocial,
                Complemento = x.Complemento,
                Numero = x.Numero,
                Estado = x.Estado,
                Cidade = x.Cidade,
                CodigoPais = x.CodigoPais,
                DescricaoPais = x.DescricaoPais,
                Logradouro = x.Logradouro
            });

            if(fabricante == null)
            {
                return items;
            }else if(fabricante.IdFabricante != null && fabricante.IdFabricante > 0)
            {
                    return items.Where(x => x.IdFabricante == fabricante.IdFabricante);
            }else if(fabricante.RazaoSocial != null)
            {
                return items.Where(x => x.RazaoSocial.ToLower().Contains(fabricante.RazaoSocial));
            }

            return items;
        }

        public FabricanteEntity Selecionar(int id)
        {
            return new FabricanteEntity();
        }

        public FabricanteEntity Apagar(int id)
        {
            var fab = _context.Fabricante.Single(x => x.IdFabricante == id);
            _context.Fabricante.Remove(fab);

            _context.SaveChanges();

            return new FabricanteEntity();
        }

        public FabricanteVM Salvar(FabricanteVM fabricanteVM)
        {
            return RegrasSalvar(fabricanteVM);
        }

        public FabricanteVM RegrasSalvar(FabricanteVM fabricanteVM)
        {
            FabricanteEntity entityFabricante = new FabricanteEntity();

           
            if(fabricanteVM.IdFabricante != null)
            {
                entityFabricante = _context.Fabricante.FirstOrDefault(x => x.IdFabricante == fabricanteVM.IdFabricante);
                entityFabricante.IdFabricante = fabricanteVM.IdFabricante.Value;

                _context.Entry(entityFabricante).State = EntityState.Modified;
            }

            entityFabricante.CNPJImportador = fabricanteVM.CNPJImportador;
            entityFabricante.Complemento = fabricanteVM.Complemento;
            entityFabricante.RazaoSocial = fabricanteVM.RazaoSocial;
            entityFabricante.Numero = fabricanteVM.Numero;
            entityFabricante.Estado = fabricanteVM.Estado;
            entityFabricante.CodigoPais = fabricanteVM.CodigoPais;
            entityFabricante.DescricaoPais = fabricanteVM.DescricaoPais;
            entityFabricante.Cidade = fabricanteVM.Cidade;
            entityFabricante.Logradouro = fabricanteVM.Logradouro;

            if (fabricanteVM.IdFabricante != null)
            {
                _context.Fabricante.Update(entityFabricante);
            }else
            {
                _context.Fabricante.Add(entityFabricante);

            }

            _context.SaveChanges();

            return fabricanteVM;
        }
    }
}
