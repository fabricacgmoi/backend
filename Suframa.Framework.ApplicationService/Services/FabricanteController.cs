using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suframa.DemoSuframa.BusinessLogic;
using Suframa.DemoSuframa.DataAccess.Database.Entities;
using Suframa.Sciex.CrossCutting.DataTransferObject.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Suframa.DemoSuframa.ApplicationService.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        // GET api/values
        private readonly FabricanteBll _fabricanteBll;

        public FabricanteController(FabricanteBll fabricanteBll)
        {
            _fabricanteBll = fabricanteBll;
        }

        [HttpGet]
        public IEnumerable<FabricanteVM> Get()
        {
            return _fabricanteBll.Listar(null);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public FabricanteVM Get(int id)
        {
            return _fabricanteBll.Listar(new FabricanteVM { IdFabricante = id }).SingleOrDefault();
        }

        // POST api/values
        [HttpPost]
        public FabricanteVM Post([FromBody] FabricanteVM value)
        {
            return _fabricanteBll.Salvar(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _fabricanteBll.Apagar(id);
        }
    }
}
