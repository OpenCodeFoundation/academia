using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Core.Entities;
using Academia.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Institute")]
    public class InstituteController : Controller
    {
        private readonly IAsyncRepository<Institute> _instituteRepository;

        public InstituteController(IAsyncRepository<Institute> instituteRepository)
        {
            _instituteRepository = instituteRepository;
        }

        // GET: api/Institute
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Institute/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Institute
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Institute/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
