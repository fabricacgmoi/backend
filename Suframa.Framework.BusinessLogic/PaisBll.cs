using Suframa.DemoSuframa.DataAccess;
using Suframa.Sciex.CrossCutting.DataTransferObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Suframa.DemoSuframa.BusinessLogic
{
    public class PaisBll
    {
        private readonly DataAccess.AppContext _context;

        public PaisBll(DataAccess.AppContext context)
        {
            _context = context;
        }

        public IEnumerable<object> ListarPaises(PaisVM paisVM)
        {

            if (paisVM.Descricao == null && paisVM.Id == null)
            {
                return _context.Pais;
            }

            if(paisVM.Id != null)
            {
                return _context.Pais.Where(x=> x.IdPais == paisVM.Id)
                    .Select(
                    s => new
                    {
                        id = s.CodigoPais == null ? "" : s.CodigoPais,
                        text = (s.CodigoPais != null ? ("00" + s.CodigoPais.ToString()) : "") + " | " + s.Descricao
                    });
            }

                var pais = _context.Pais.Where(
                    o =>
                        (paisVM.Descricao == null || (o.Descricao.ToLower().Contains(paisVM.Descricao.ToLower()))))
                .OrderBy(o => o.Descricao)
                .Select(
                    s => new
                    {
                        id = s.CodigoPais == null ? "" : s.CodigoPais,
                        text = (s.CodigoPais != null ? ("00" + s.CodigoPais.ToString()) : "") + " | " + s.Descricao
                    });


            return pais;
        }
    }
}
