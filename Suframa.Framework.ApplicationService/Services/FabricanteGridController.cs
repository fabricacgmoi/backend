using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suframa.DemoSuframa.BusinessLogic;
using Suframa.DemoSuframa.DataAccess.Database.Entities;
using Suframa.Sciex.CrossCutting.DataTransferObject;
using Suframa.Sciex.CrossCutting.DataTransferObject.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Suframa.DemoSuframa.ApplicationService.Services
{
    [Route("api/[controller]")]
    public class FabricanteGridController : Controller
    {
        private readonly FabricanteBll _fabricanteBll;

        public FabricanteGridController(FabricanteBll fabricanteBll)
        {
            _fabricanteBll = fabricanteBll;
        }
        // GET: api/<controller>
        [HttpGet]
        public PagedItems<FabricanteVM> Get([FromQuery] FabricanteVM value)
        {
            var items = _fabricanteBll.Listar(value);
            var resultadPaginado = new PagedItems<FabricanteVM>
            {
                Items = items.ToList(),
                Total = items.Count()
            };

            return resultadPaginado;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public FabricanteVM Get(int id)
        {
            return _fabricanteBll.Listar(new FabricanteVM { IdFabricante = id }).SingleOrDefault();

        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
