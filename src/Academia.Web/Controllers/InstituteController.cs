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
            this._instituteRepository = instituteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Institute institute)
        {
            var newInstitute = await _instituteRepository.AddAsync(institute);
            return Ok(newInstitute);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listOfInstitutes = await _instituteRepository.ListAllAsync();
            return Ok(listOfInstitutes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var institute = await _instituteRepository.GetByIdAsync(id);
            return Ok(institute);
        }
    }
}