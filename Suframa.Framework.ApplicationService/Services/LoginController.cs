using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Suframa.DemoSuframa.ApplicationService.Services
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var xx = new HttpResponseMessage(HttpStatusCode.OK);
            xx.ReasonPhrase = generateToken();
            return xx;
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

        private string generateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30JTOdtVWJG8abWvB1GlOgJuQZdcF2Lasd/hccMw=="));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("SUFRAMA",
              "SUFRAMA",
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
