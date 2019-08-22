using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suframa.DemoSuframa.BusinessLogic;
using Suframa.Sciex.CrossCutting.DataTransferObject.ViewModel;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Suframa.DemoSuframa.ApplicationService.Services
{
    [Route("api/[controller]")]
    public class PaisDropDownController : Controller
    {
        private readonly PaisBll _paisBll;

        public PaisDropDownController(PaisBll paisBll)
        {
            _paisBll = paisBll;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<object> Get([FromQuery] PaisVM paisVM)
        {
            return _paisBll.ListarPaises(paisVM);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
