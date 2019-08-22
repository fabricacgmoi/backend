using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suframa.FrameworkSuframa.BusinessLogic;
using Suframa.FrameworkSuframa.CrossCutting.DataTransferObject.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Suframa.FrameworkSuframa.ApplicationService.Services
{
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        // GET: api/<controller>
        private readonly PessoaBll _pessoaBll;

        public PessoaController(PessoaBll pessoaBll)
        {
            this._pessoaBll = pessoaBll;
        }

        [HttpGet]
        public IEnumerable<PessoaVM> Get()
        {
            return _pessoaBll.Listar(null);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public PessoaVM Get(int id)
        {
            return _pessoaBll.Listar(new PessoaVM { Id = id }).SingleOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public PessoaVM Post([FromBody]PessoaVM value)
        {
            return _pessoaBll.Salvar(value);
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
            _pessoaBll.Apagar(id);
        }
    }
}
